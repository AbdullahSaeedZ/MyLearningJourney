using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouTube_Downloader.Services;

namespace YouTube_Downloader
{
    public partial class Form1 : Form
    {
        private YouTubeVideo _youTubeVideo;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _youTubeVideo = new YouTubeVideo();
        }

        private async void btnGetVidInfo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbURL.Text))
            {
                MessageBox.Show("Please enter a valid YouTube video URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ = StartFetchingInfo();
        }

        private async Task StartFetchingInfo()
        {
            ShowHideLoadingIndicator();

            await _youTubeVideo.GetVideoDataAsync(tbURL.Text.Trim());
            ShowHideLoadingIndicator();
            FillInfoCard();
            pnlVidInfo.Visible = true;
        }

        private void FillInfoCard()
        {
            lblVidTitle.Text = _youTubeVideo.Title ?? "N/A";
            lblVidDescription.Text = _youTubeVideo.Description ?? "N/A";
            lblChannelName.Text = _youTubeVideo.ChannelTitle ?? "N/A";
            lblVidDuration.Text = _youTubeVideo.VideoLength?.ToString(@"hh\:mm\:ss") ?? "N/A";
            pbVidThumbnail.LoadAsync(_youTubeVideo.ThumbnailURL ?? string.Empty);
            pnlVidDuration.Invalidate();
            // remove duplicate qualities
            cbQualities.Items.AddRange(_youTubeVideo.AvailableQualities.ToArray());
        }

        private void ShowHideLoadingIndicator()
        {
            prgbarLoadingInfo.Enabled = !prgbarLoadingInfo.Enabled;
            prgbarLoadingInfo.Visible = !prgbarLoadingInfo.Visible;
            tbURL.Visible = !tbURL.Visible;
            btnGetVidInfo.Visible = !btnGetVidInfo.Visible;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            dgvDownloads.Rows.Add("Video Title", "Video URL", "Download Status", "230 MB", "23/12/2023");
        }

        private void btnCloseVidInfo_Click(object sender, EventArgs e)
        {
            ResetVidInfoPanel();
            tbURL.Text = string.Empty;
            pnlVidInfo.Visible = false;
        }

        private void ResetVidInfoPanel()
        {
            lblVidTitle.Text = string.Empty;
            lblVidDescription.Text = string.Empty;
            lblChannelName.Text = string.Empty;
            lblVidDuration.Text = string.Empty;
            pbVidThumbnail.Image = null;
            cbQualities.Items.Clear();
        }
    }
}
