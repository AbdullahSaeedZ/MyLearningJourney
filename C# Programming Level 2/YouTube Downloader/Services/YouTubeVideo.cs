using System;
using YoutubeExplode;
using YoutubeExplode.Converter;
using System.Threading.Tasks;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode.Common;
using System.Collections.Generic;
using System.Threading;

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
            YoutubeExplode.Videos.Video videoInfo = await _YouTubeClient.Videos.GetAsync(URL);
            _manifest = await _YouTubeClient.Videos.Streams.GetManifestAsync(URL);
            PrepareVideoInfo(videoInfo);
        }

        public async Task DownloadVideoAsync(string selectedQuality, string downloadPath, IProgress<double> progress)
        {
            if (string.IsNullOrEmpty(selectedQuality))
                throw new ArgumentException("Selected quality cannot be null or empty.", nameof(selectedQuality));
            else if (string.IsNullOrEmpty(downloadPath))
                throw new ArgumentException("Download path cannot be null or empty.", nameof(downloadPath));
            else if (VideoURL == null)
                throw new ArgumentException("Video URL cannot be null or empty.", nameof(VideoURL));

            DownloadPath = downloadPath;
            PrepareSelectedStreams(selectedQuality);
            await _YouTubeClient.Videos.DownloadAsync(_selectedStreamsInfo,new ConversionRequestBuilder($"{Title}.mp4").Build(), progress, _cts.Token);
        }

        public void CancelDownload()
        {
            _cts?.Cancel();
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
                AvailableQualities.Add(vid.VideoQuality.Label);
            }
        }
        private void PrepareSelectedStreams(string selectedQuality)
        {
            AudioOnlyStreamInfo selectedAudioStream = (AudioOnlyStreamInfo)_audioOnlyStreams.GetWithHighestBitrate();
            VideoOnlyStreamInfo selectedVideoStream = null;
            foreach (VideoOnlyStreamInfo stream in _videoOnlyStreams)
            {
                if (stream.VideoQuality.Label == selectedQuality)
                {
                    selectedVideoStream = stream;
                    break;
                }
            }
            _selectedStreamsInfo = new IStreamInfo[] { selectedAudioStream, selectedVideoStream };
        }

    }
}
