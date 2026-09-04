using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


namespace YouTube_Downloader.Services
{
    public class YouTubeVideo
    {
        public enum enStatus
        {
            Waiting,
            Downloading,
            Cancelled,
            Completed,
            Failed
        }

        private readonly string _exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "yt-dlp.exe");
        private CancellationTokenSource _cts;
        public event Action OnDownloadStarted;
        public event Action OnDownloadFinished;
        
        [JsonIgnore]
        public string VideoURL { get; private set; }

        [JsonInclude]
        public string Title { get; private set; }
        [JsonIgnore]
        public string Description { get; private set; }
        [JsonIgnore]
        public string ChannelTitle { get; private set; }
        [JsonIgnore]
        public TimeSpan? VideoLength { get; private set; }
        [JsonIgnore]
        public string ThumbnailURL { get; private set; }
        [JsonInclude]
        public string DownloadPath { get; private set; }

        [JsonInclude]
        public string Date { get; set; }

        private string _cachedJson;
        [JsonIgnore]
        public List<string> Qualities = new List<string>();

        private static readonly Regex _progressRegex = new Regex(@"(\d+(\.\d+)?)%", RegexOptions.Compiled);
        private string _progress = "0%";
        [JsonInclude]
        public string Progress
        {
            get { return _progress; }
            set
            {
                if (_progress != value)
                {
                    _progress = value;
                }
            }
        }

        [JsonIgnore]
        private enStatus _status = enStatus.Waiting;
        [JsonInclude]
        public enStatus Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                }
            }
        }

        [JsonIgnore]
        private string _size = "0 MB";
        [JsonInclude]
        public string Size 
        {
            get { return _size; }
            set
            {
                if (_size != value)
                {
                    _size = value;
                }
            }

        }
      

        public YouTubeVideo()
        {
            _cts = new CancellationTokenSource();
            Qualities = new List<string>();
        }

        public async Task GetVideoDataAsync(string URL)
        {
            VideoURL = URL;

            ProcessStartInfo fetchingInfo = new ProcessStartInfo()
            {
                // args and flags for yt-dlp
                FileName = _exePath,
                Arguments = $"--dump-json --no-playlist --skip-download \"{URL}\"",

                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using( Process fetchingProcess = new Process() { StartInfo = fetchingInfo })
            {
                fetchingProcess.Start();
                string output = await fetchingProcess.StandardOutput.ReadToEndAsync();
                string error = await fetchingProcess.StandardError.ReadToEndAsync();

                // to wait for the process to exit and get the exit code to make sure all went good
                await Task.Run(() => fetchingProcess.WaitForExit());
                if (fetchingProcess.ExitCode != 0 || string.IsNullOrEmpty(output))
                {
                    throw new Exception($"Fetching {Title} data failed.\nError: {error}");
                }

                // cash the json file to run offline download simulation to get file size for the selected quality
                _cachedJson = output;
                PrepareVideoInfo(output);
            }
        }

        public async Task DownloadVideoAsync(string selectedQuality, string fullDownloadPath)
        {
            
            selectedQuality = selectedQuality.Replace("p", "");
            Date = DateTime.Now.ToShortDateString();
            Status = enStatus.Downloading;
            DownloadPath = fullDownloadPath;

            ProcessStartInfo downloadInfo = new ProcessStartInfo()
            {
                // args and flags for yt-dlp
                FileName = _exePath,
                Arguments = $"--no-playlist --force-overwrites --merge-output-format mp4 -f \"bv*[height<={selectedQuality}]+ba/b[height<={selectedQuality}]/best\" -o \"{fullDownloadPath}\" --newline \"{VideoURL}\"",

                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            OnDownloadStarted?.Invoke();
            try
            {
                await StartDownloadProcessAsync(downloadInfo);
            }
            finally
            {
                OnDownloadFinished?.Invoke();
            }
        }

        private async Task StartDownloadProcessAsync(ProcessStartInfo downloadInfo)
        {
            using (Process downloadProcess = new Process() { StartInfo = downloadInfo })
            {
                downloadProcess.OutputDataReceived += OnDataReceived;
                StringBuilder errorMessege = new StringBuilder();
                downloadProcess.ErrorDataReceived += (sender, e) => OnErrorReceived(sender, e, errorMessege);
                CancellationTokenRegistration cancellationRegistration = _cts.Token.Register(() => OnCancellationRequested(downloadProcess));

                try
                {
                    downloadProcess.Start();
                    downloadProcess.BeginOutputReadLine();
                    downloadProcess.BeginErrorReadLine();
                    // to wait for the process to exit and get the exit code to make sure all went good
                    await Task.Run(() => downloadProcess.WaitForExit(), _cts.Token);
                }
                // will only throw if the token was already canceled when passed to the lambda
                // other than that, the cancellation will be handled by the OnCancellationRequested event
                catch (OperationCanceledException)
                {
                    Status = enStatus.Cancelled;
                    return;
                }
                catch (Exception ex)
                {
                    Status = enStatus.Failed;
                    throw new Exception($"Downloading {Title} failed.\nError: {ex.Message}");
                }
                finally
                {
                    cancellationRegistration.Dispose();
                }

                if (_cts.Token.IsCancellationRequested)
                {
                    Status = enStatus.Cancelled;
                    CleanupTempFiles(DownloadPath);
                    return;
                }

                if (downloadProcess.ExitCode != 0)
                {
                    Status = enStatus.Failed;
                    throw new Exception($"Downloading {Title} failed.\nError: {errorMessege.ToString()}");
                }

                Status = enStatus.Completed;
                SetRealFileSize();
                _cts?.Dispose();
            }
        }

        private void OnCancellationRequested(Process downloadProcess)
        {
            try
            {
                if (downloadProcess != null && !downloadProcess.HasExited)
                {
                    // /F = Force, /T = Tree (kills all child processes which is ffmpeg when merging)
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "taskkill",
                        Arguments = $"/F /T /PID {downloadProcess.Id}",
                        CreateNoWindow = true,
                        UseShellExecute = false
                    })?.WaitForExit();
                }
            }
            catch // incase the process has already exited right before the kill command, we just ignore
            {
            }
        }
        public void CancelDownload()
        {
            _cts?.Cancel();
        }

        [JsonIgnore]
        private int _currentStream = 0; // 1 = Vid, 2 = Aud

        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data))
                return;

            // when yl-dlp finishes a stream, it shows a destination line for the next stream
            if (e.Data.StartsWith("[download] Destination:"))
            {
                _currentStream++;
                return;
            }

            // updating progress bassed on current stream being downloaded
            if (e.Data.StartsWith("[download]") && _progressRegex.Match(e.Data) is Match match)
            {
                double newPercent = 0;
                if (double.TryParse(match.Groups[1].Value, out double recievedPercent))
                {
                    // scaling from 0 to 85% for video stream, 85% to 100% for audio stream
                    if (_currentStream <= 1)
                        newPercent = ( recievedPercent / 100 ) * 85.00;
                    else
                        newPercent = 85 + (( recievedPercent / 100 ) * 15.00);
                }

                Progress = $"{Math.Min(100, Math.Round(newPercent, 1))}%";
            }

        }
        private void OnErrorReceived(object sender, DataReceivedEventArgs e, StringBuilder errorMessege)
        {
            if (!string.IsNullOrEmpty(e.Data))
                errorMessege.Append(e.Data);
        }
       

        private void CleanupTempFiles(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return;
            
            string baseFileName = Path.GetFileNameWithoutExtension(path);
            // to get all files in the same directory that start with the base file name
            string[] tempFiles = Directory.GetFiles(Path.GetDirectoryName(path), $"{baseFileName}*");

            try
            {
                foreach (string file in tempFiles)
                {
                    File.Delete(file);
                }
            }
            catch (Exception)
            {
            }
        }

        public async Task<string> GetAproxFileSize(string selectedQuality)
        {
            if (string.IsNullOrEmpty(_cachedJson))
                return "Unknown";

            selectedQuality = selectedQuality.Replace("p", "");
            ProcessStartInfo simulationInfo = new ProcessStartInfo()
            {
                FileName = _exePath,
                // using the cached json for offline simulation
                Arguments = $"--load-info-json - --simulate --print \"%(filesize,filesize_approx)s\" -f \"bv*[height<={selectedQuality}]+ba/b[height<={selectedQuality}]/best\"",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process queryProcess = new Process { StartInfo = simulationInfo })
            {
                queryProcess.Start();

                // we pass the cached json to yt-dlp through standard input of the process
                using (StreamWriter writer = queryProcess.StandardInput)
                {
                    await writer.WriteAsync(_cachedJson);
                }

                string output = await queryProcess.StandardOutput.ReadToEndAsync();
                await Task.Run(() => queryProcess.WaitForExit());

                // simulation output will return the file size in bytes, we need to parse
                string[] lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                long totalBytes = 0;

                foreach (string line in lines)
                {
                    if (long.TryParse(line.Trim(), out long bytes))
                        totalBytes += bytes;
                }

                if (totalBytes > 0)
                {
                    double mb = totalBytes / ( 1024.0 * 1024.0 );
                    this.Size = $"{Math.Round(mb, 1)} MB";
                    return "~" + this.Size;
                }
            }

            return "Unknown";
        }
        private void SetRealFileSize()
        {
            if (string.IsNullOrEmpty(DownloadPath) || !File.Exists(DownloadPath))
                return;
            try
            {
                var fileInfo = new FileInfo(DownloadPath);
                double mb = fileInfo.Length / ( 1024.0 * 1024.0 );
                this.Size = $"{mb:F2} MB";
            }
            catch
            {
            }
        }

        private void PrepareVideoInfo(string jsonContent)
        {
            using (JsonDocument jsonDoc = JsonDocument.Parse(jsonContent))
            {
                Title = jsonDoc.RootElement.GetProperty("title").GetString();
                Description = jsonDoc.RootElement.TryGetProperty("description", out JsonElement visdescription) ? visdescription.GetString() : "No Description Found";
                ChannelTitle = jsonDoc.RootElement.TryGetProperty("uploader", out JsonElement channelTitle) ? channelTitle.GetString() : "No Channel Title Found";
                ThumbnailURL = jsonDoc.RootElement.TryGetProperty("thumbnail", out JsonElement thumbnailUrl) ? thumbnailUrl.GetString() : "No Thumbnail URL Found";

                if (jsonDoc.RootElement.TryGetProperty("duration", out JsonElement vidLength))
                    VideoLength = TimeSpan.FromSeconds(vidLength.GetDouble());
                // qualities
                PrepareQualities(jsonDoc);
            }
        }
        private void PrepareQualities(JsonDocument jsonDoc)
        {
            Qualities.Clear();
            if (!jsonDoc.RootElement.TryGetProperty("formats", out JsonElement formats) || formats.ValueKind != JsonValueKind.Array)
                return;

            foreach (JsonElement f in formats.EnumerateArray())
            {
                if (f.TryGetProperty("vcodec", out JsonElement vcodec))
                {
                    string vidStream = vcodec.GetString();
                    if (vidStream != "none" && vidStream != null)
                    {
                        if (f.TryGetProperty("height", out JsonElement hElem) && hElem.ValueKind == JsonValueKind.Number 
                            && hElem.TryGetInt32(out int height) && height > 0 && !Qualities.Contains($"{height}p"))
                        {
                                Qualities.Add($"{height}p");
                        }
                    }
                }
            }
        }
    }
}