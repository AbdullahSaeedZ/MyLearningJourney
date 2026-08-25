using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


namespace YouTube_Downloader.Services
{
    public class YouTubeVideo : INotifyPropertyChanged, IDisposable
    {
        public enum enStatus
        {
            Waiting,
            Downloading,
            Cancelled,
            Completed,
            Failed
        }

      
        private CancellationTokenSource _cts;
        public event PropertyChangedEventHandler PropertyChanged;
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress)));
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
                }
            }
        }

        [JsonInclude]
        public string Date { get; set; }

        [JsonInclude]
        public string Size { get; set; } = "0 MB";

        [JsonIgnore]
        public Dictionary<string, long> QualitiesAndSizes = new Dictionary<string, long>();
        [JsonIgnore]
        private long _maxAudioBytes = 0;

        public YouTubeVideo()
        {
            _cts = new CancellationTokenSource();
            QualitiesAndSizes = new Dictionary<string, long>();
        }

        public async Task GetVideoDataAsync(string URL)
        {
            VideoURL = URL;
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "yt-dlp.exe");

            ProcessStartInfo fetchingInfo = new ProcessStartInfo()
            {
                // args and flags for yt-dlp
                FileName = exePath,
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

                PrepareVideoInfo(output);
            }
        }

        public async Task DownloadVideoAsync(string selectedQuality, string fullDownloadPath)
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "yt-dlp.exe");
            selectedQuality = selectedQuality.Replace("P", "");
            Date = DateTime.Now.ToShortDateString();
            Status = enStatus.Downloading;
            DownloadPath = fullDownloadPath;

            ProcessStartInfo downloadInfo = new ProcessStartInfo()
            {
                // args and flags for yt-dlp
                FileName = exePath,
                Arguments = $"--no-playlist --force-overwrites --merge-output-format mp4 -f \"bv*[height<={selectedQuality}]+ba/b[height<={selectedQuality}]/best\" -o \"{fullDownloadPath}\" --newline \"{VideoURL}\"",

                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            OnDownloadStarted?.Invoke();
            await StartDownloadProcessAsync(downloadInfo);
            OnDownloadFinished?.Invoke();
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
                    return;
                }

                if (downloadProcess.ExitCode != 0)
                {
                    Status = enStatus.Failed;
                    throw new Exception($"Downloading {Title} failed.\nError: {errorMessege.ToString()}");
                }

                Status = enStatus.Completed;
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

                    if (File.Exists(DownloadPath))
                        File.Delete(DownloadPath);
                }
            }
            catch // incase the process has already exited right before the kill command, we just ignore
            {
            }
        }

        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data) && e.Data.StartsWith("[download]"))
            {
                Match match = _progressRegex.Match(e.Data);
                if (match.Success)
                    Progress = match.Value;
            }    
        }

        private void OnErrorReceived(object sender, DataReceivedEventArgs e, StringBuilder errorMessege)
        {
            if (!string.IsNullOrEmpty(e.Data))
                errorMessege.Append(e.Data);
        }

        public void CancelDownload()
        {
            _cts?.Cancel();
        }




        public string GetFileSize(string selectedQuality)
        {
            long selectedVideoSize = QualitiesAndSizes[selectedQuality];
            return this.Size = $"{( selectedVideoSize + _maxAudioBytes ) / ( 1024 * 1024 )} MB";
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
            if (!jsonDoc.RootElement.TryGetProperty("formats", out JsonElement formats) || formats.ValueKind != JsonValueKind.Array)
                return;

            foreach (JsonElement format in formats.EnumerateArray())
            {
                string vidStream = format.TryGetProperty("vcodec", out JsonElement vcodec) ? vcodec.GetString() : null;
                string audStream = format.TryGetProperty("acodec", out JsonElement acodec) ? acodec.GetString() : null;

                // if this is an audio stream, just track largest audio stream size, cuz eventually all vid streams will have same largest audio size
                if (vidStream == "none" && audStream != "none" && audStream != null)
                {
                    long audioSize = GetFormatSize(format);
                    if (audioSize > _maxAudioBytes)
                        _maxAudioBytes = audioSize;
                    continue; 
                }

                // to get the quality if it is a vid stream, and store its size
                if (vidStream != "none" && vidStream != null)
                {
                    if (format.TryGetProperty("height", out JsonElement heightElement) && heightElement.TryGetInt32(out int height) && height > 0)
                    {
                        string quality = $"{height}p";
                        long videoSize = GetFormatSize(format);

                        if (!QualitiesAndSizes.ContainsKey(quality) || videoSize > QualitiesAndSizes[quality])
                            QualitiesAndSizes[quality] = videoSize;
                    }
                }
            }
        }
        private long GetFormatSize(JsonElement format)
        {
            if (format.TryGetProperty("filesize", out var fs) && fs.TryGetInt64(out long size) && size > 0)
                return size;

            if (format.TryGetProperty("filesize_approx", out var fsa) && fsa.TryGetInt64(out long approxSize) && approxSize > 0)
                return approxSize;

            return 0;
        }

        public void Dispose()
        {
            _cts?.Dispose();
        }
    }
}