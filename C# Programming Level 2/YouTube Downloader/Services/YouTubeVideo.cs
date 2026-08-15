using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Converter;
using YoutubeExplode.Exceptions;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace YouTube_Downloader.Services
{
    public class YouTubeVideo : INotifyPropertyChanged
    {
        public enum enStatus
        {
            Downloading,
            Cancelled,
            Completed,
            Failed
        }

        private readonly YoutubeClient _YouTubeClient;
        private StreamManifest _manifest;
        private CancellationTokenSource _cts;

        private IEnumerable<AudioOnlyStreamInfo> _audioOnlyStreams;
        private IEnumerable<VideoOnlyStreamInfo> _videoOnlyStreams;
        private IStreamInfo[] _selectedStreamsInfo;

        public event PropertyChangedEventHandler PropertyChanged;
        public event Action OnDownloadStarted;
        public event Action OnDownloadFinished;

        [JsonIgnore]
        public VideoId? VideoID { get; private set; }
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

        [JsonIgnore]
        public List<string> AvailableQualities { get; private set; }
        [JsonInclude]
        public string DownloadPath { get; private set; }

        
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
        private enStatus _status = enStatus.Downloading;
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
        public string Size { get; set; }

        public YouTubeVideo()
        {
            _YouTubeClient = new YoutubeClient();
            _cts = new CancellationTokenSource();
            AvailableQualities = new List<string>();
        }

        public async Task GetVideoDataAsync(string URL)
        {
            VideoURL = URL;

            VideoID = VideoId.TryParse(URL);
            if (VideoID == null)
                throw new ArgumentException("Invalid YouTube video URL.", nameof(URL));

            Video videoInfo;
            try
            {
                videoInfo = await _YouTubeClient.Videos.GetAsync(URL);
                _manifest = await _YouTubeClient.Videos.Streams.GetManifestAsync(URL);
                PrepareVideoInfo(videoInfo);
            }
            catch (VideoUnavailableException)
            {
                throw new ArgumentException("This video is unavailable, private, or has been deleted.", nameof(URL));
            }
            catch (Exception ex)
            {
               throw new Exception($"Fetching Error: {ex.Message}", ex);
            }
        }

        public async Task DownloadVideoAsync(string selectedQuality, string downloadPath)
        {
            DownloadPath = downloadPath;
            Date = DateTime.Now.ToShortDateString();
            PrepareSelectedStreams(selectedQuality);

            try
            {
                OnDownloadStarted?.Invoke();
                var Progress = new Progress<double>(p =>
                {
                    this.Progress = $"{(int)( p * 100 )}%";
                });

                await _YouTubeClient.Videos.DownloadAsync(_selectedStreamsInfo, new ConversionRequestBuilder(downloadPath).Build(), Progress, _cts.Token);
                this.Status = enStatus.Completed;
            }
            catch (OperationCanceledException)
            {
                this.Status = enStatus.Cancelled;
                throw;
            }
            catch (NotSupportedException ex)
            {
                // this is a bug where youtube explode throws an exception when cleaning up after FFmpeg finishes
                // but the file is already downloaded and muxed and ready,
                if (File.Exists(downloadPath) && new FileInfo(downloadPath).Length > 0)
                {
                    this.Progress = "100%";
                    this.Status = enStatus.Completed;
                    return;
                }

                this.Status = enStatus.Failed;
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                this.Status = enStatus.Failed;
                throw new Exception(ex.Message);
            }
            finally
            {
                OnDownloadFinished?.Invoke();
            }

        }

        public void CancelDownload()
        {
            _cts?.Cancel();
        }

        public string GetFileSize(string selectedQuality)
        {
            PrepareSelectedStreams(selectedQuality);
            if (_selectedStreamsInfo[0] == null || _selectedStreamsInfo[1] == null)
                return "N/A";

            double totalBytes = _selectedStreamsInfo[0].Size.Bytes + _selectedStreamsInfo[1].Size.Bytes;
            return this.Size = $"{( totalBytes / ( 1024 * 1024 ) ):F2} MB";
        }

        private void PrepareSelectedStreams(string selectedQuality)
        {
            AudioOnlyStreamInfo selectedAudioStream = (AudioOnlyStreamInfo)_audioOnlyStreams.GetWithHighestBitrate();
            VideoOnlyStreamInfo selectedVideoStream = null;

            foreach (VideoOnlyStreamInfo stream in _videoOnlyStreams)
            {
                // to prioritize mp4 over webm if both are available for the same quality
                if (stream.VideoQuality.Label == selectedQuality)
                {
                    if (selectedVideoStream == null)
                        selectedVideoStream = stream;
                    else if (stream.Container.Name.Equals("mp4", StringComparison.OrdinalIgnoreCase))
                    {
                        selectedVideoStream = stream;
                    }
                }
            }
            _selectedStreamsInfo = new IStreamInfo[] { selectedVideoStream, selectedAudioStream };
        }

        private void PrepareVideoInfo(Video videoInfo)
        {
            Title = videoInfo.Title;
            Description = videoInfo.Description;
            ChannelTitle = videoInfo.Author.ChannelTitle;
            VideoLength = videoInfo.Duration;
            ThumbnailURL = videoInfo.Thumbnails.GetWithHighestResolution()?.Url;
            _audioOnlyStreams = _manifest.GetAudioOnlyStreams();
            _videoOnlyStreams = _manifest.GetVideoOnlyStreams();

            foreach (VideoOnlyStreamInfo vid in _videoOnlyStreams)
            {
                // it returns same quality in mp4 and webm , and some are duplicated
                if (!AvailableQualities.Contains(vid.VideoQuality.Label))
                {
                    AvailableQualities.Add(vid.VideoQuality.Label);
                }
            }
        }
    }
}