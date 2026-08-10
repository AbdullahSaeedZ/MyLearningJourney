using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouTube_Downloader.Services;

namespace YouTube_Downloader
{
    public partial class Form1 : Form
    {
        private enum enStatus
        {
            Downloading,
            Cancelled,
            Completed,
        }
        private YouTubeVideo _youTubeVideo;
        private Progress<double> _progress;

        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.DefaultExt = ".mp4";
            saveFileDialog1.Title = "Save Video";
            saveFileDialog1.Filter = "MP4 Video (*.mp4)|*.mp4";
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _youTubeVideo = new YouTubeVideo();
            _progress = new Progress<double>(value =>
            {
                dgvDownloads.Rows[0].Cells[2].Value = $"{(int)(value * 100)}%";
            });
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

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            string selectedQuality = cbQualities.SelectedItem?.ToString();
            saveFileDialog1.FileName = _youTubeVideo.Title;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            dgvDownloads.Rows.Add(_youTubeVideo.Title, enStatus.Downloading, "0%", "5MB", DateTime.Now.ToShortDateString());
            pnlVidInfo.Visible = false;
            ResetInfoCard();
            try
            {
                await _youTubeVideo.DownloadVideoAsync(selectedQuality, saveFileDialog1.FileName, _progress);
            }
            catch (OperationCanceledException)
            {
                dgvDownloads.Rows[0].Cells[1].Value = enStatus.Cancelled;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Video: {_youTubeVideo.Title}\nException: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetInfoCard();
                pnlVidInfo.Visible = false;
                return;
            }
            
            dgvDownloads.Rows[0].Cells[1].Value = enStatus.Completed;
        }

        private void btnCloseVidInfo_Click(object sender, EventArgs e)
        {
            ResetInfoCard();
            pnlVidInfo.Visible = false;
            _youTubeVideo = null;
            _youTubeVideo = new YouTubeVideo();
        }

        private async Task StartFetchingInfo()
        {
            ShowHideLoadingIndicator();

            try
            {
                await _youTubeVideo.GetVideoDataAsync(tbURL.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetInfoCard();
                ShowHideLoadingIndicator();
                return;
            }
            
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
            cbQualities.Items.AddRange(_youTubeVideo.AvailableQualities.ToArray());
            cbQualities.SelectedIndex = 0;

            lblVidSize.Text = _youTubeVideo.GetFileSize(cbQualities.SelectedItem.ToString()) ?? "N/A";
        }

        private void ShowHideLoadingIndicator()
        {
            prgbarLoadingInfo.Enabled = !prgbarLoadingInfo.Enabled;
            prgbarLoadingInfo.Visible = !prgbarLoadingInfo.Visible;
            tbURL.Visible = !tbURL.Visible;
            btnGetVidInfo.Visible = !btnGetVidInfo.Visible;
        }

        private void ResetInfoCard()
        {
            tbURL.Text = string.Empty;
            lblVidTitle.Text = string.Empty;
            lblVidDescription.Text = string.Empty;
            lblChannelName.Text = string.Empty;
            lblVidDuration.Text = string.Empty;
            pbVidThumbnail.Image = null;
            cbQualities.Items.Clear();
        }

        private void cbQualities_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVidSize.Text = _youTubeVideo.GetFileSize(cbQualities.SelectedItem.ToString())?? "N/A";
        }
    }
}
