using System;
using System.Collections.Generic;
using System.IO;
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
    internal class YouTubeVideo
    {
        private readonly YoutubeClient _YouTubeClient;
        private StreamManifest _manifest;
        private CancellationTokenSource _cts;

        private IEnumerable<AudioOnlyStreamInfo> _audioOnlyStreams;
        private IEnumerable<VideoOnlyStreamInfo> _videoOnlyStreams;
        private IStreamInfo[] _selectedStreamsInfo;

        public string VideoURL { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ChannelTitle { get; private set; }
        public TimeSpan? VideoLength { get; private set; }
        public string ThumbnailURL { get; private set; }

        public List<string> AvailableQualities { get; private set; }
        public string DownloadPath { get; private set; }



        public YouTubeVideo()
        {
            _YouTubeClient = new YoutubeClient();
            _cts = new CancellationTokenSource();
            AvailableQualities = new List<string>();
        }

        public async Task GetVideoDataAsync(string URL)
        {
            VideoURL = URL;

            VideoId? vidID = VideoId.TryParse(URL);
            if (vidID == null)
                throw new ArgumentException("Invalid YouTube video URL.", nameof(URL));

            Video videoInfo;
            try
            {
                videoInfo = await _YouTubeClient.Videos.GetAsync(URL);
            }
            catch (VideoUnavailableException)
            {
                throw new ArgumentException("This video is unavailable, private, or has been deleted.", nameof(URL));
            }

            _manifest = await _YouTubeClient.Videos.Streams.GetManifestAsync(URL);
            PrepareVideoInfo(videoInfo);
        }

        public async Task DownloadVideoAsync(string selectedQuality, string downloadPath, IProgress<double> progress)
        {
            DownloadPath = downloadPath;
            PrepareSelectedStreams(selectedQuality);

            string tempPath = Path.GetTempPath();
            string tempAudioFile = Path.Combine(tempPath, $"{Guid.NewGuid()}_audio.tmp");
            string tempVideoFile = Path.Combine(tempPath, $"{Guid.NewGuid()}_video.tmp");

            try
            {
                // downloading video and audio streams separately to be local temporary files for better ffmpeg merging
                Progress<double> videoProgress = new Progress<double>(p => progress.Report(p * 0.5));
                await _YouTubeClient.Videos.Streams.DownloadAsync(_selectedStreamsInfo[0], tempVideoFile, videoProgress, _cts.Token);

                Progress<double> audioProgress = new Progress<double>(p => progress.Report(0.5 + ( p * 0.4 )));
                await _YouTubeClient.Videos.Streams.DownloadAsync(_selectedStreamsInfo[1], tempAudioFile, audioProgress, _cts.Token);

                // ffmpeg merging both local temp file into final file
                progress.Report(0.95);

                IStreamInfo[] localStreams = new IStreamInfo[] { _selectedStreamsInfo[0], _selectedStreamsInfo[1] };
                await _YouTubeClient.Videos.DownloadAsync(localStreams, new ConversionRequestBuilder(downloadPath).Build(), null, _cts.Token);

                progress.Report(1.0);
            }
            catch (OperationCanceledException)
            {
                throw new OperationCanceledException("Download was cancelled.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DeleteFileIfExists(tempAudioFile);
                DeleteFileIfExists(tempVideoFile);
            }

        }
        public void CancelDownload()
        {
            _cts?.Cancel();
        }

        public string GetFileSize(string selectedQuality)
        {
            PrepareSelectedStreams(selectedQuality);
            return ((_selectedStreamsInfo[0].Size.Bytes + _selectedStreamsInfo[1].Size.Bytes) / (1024 * 1024)).ToString() + " MB";
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
       
        private void PrepareVideoInfo(YoutubeExplode.Videos.Video videoInfo)
        {
            Title = videoInfo.Title;
            Description = videoInfo.Description;
            ChannelTitle = videoInfo.Author.ChannelTitle;
            VideoLength = videoInfo.Duration;
            ThumbnailURL = videoInfo.Thumbnails.GetWithHighestResolution()?.Url;
            _audioOnlyStreams = _manifest.GetAudioOnlyStreams();
            _videoOnlyStreams = _manifest.GetVideoOnlyStreams();

            // it returns same quality in mp4 and webm , and some are duplicated
            foreach (VideoOnlyStreamInfo vid in _videoOnlyStreams)
            {
                if (!AvailableQualities.Contains(vid.VideoQuality.Label))
                {
                    AvailableQualities.Add(vid.VideoQuality.Label);
                }
            }
        }

        private void DeleteFileIfExists(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
            catch
            {
                return;
            }
        }

    }
}
