using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouTube_Downloader.Services;

namespace YouTube_Downloader
{

    // active downloads dictionary
    // limit the number of active downloads to 5
    // serialize and deserialize the downloads list 
    // delete cms logic

    public partial class Form1 : Form
    {
        private BindingList<YouTubeVideo> _downloadsList;
        private Dictionary<string, YouTubeVideo> _activeDownloads;
        private YouTubeVideo _youTubeVideo;

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
            _downloadsList = new BindingList<YouTubeVideo>();
            _activeDownloads = new Dictionary<string, YouTubeVideo>();

            dgvDownloads.DataSource = _downloadsList;
        }


        private async void btnDownload_Click(object sender, EventArgs e)
        {
            string selectedQuality = cbQualities.SelectedItem?.ToString();
            saveFileDialog1.FileName = _youTubeVideo.Title;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            // to capture the current vid object with his context before resetting for next download
            YouTubeVideo downloadObj = _youTubeVideo;

            // to reset the youtube object to allow next download object to be captured in next context
            _youTubeVideo = new YouTubeVideo();
            pnlVidInfo.Visible = false;
            ResetInfoCard();

            _downloadsList.Add(downloadObj);

            if (downloadObj.VideoID != null)
                _activeDownloads[downloadObj.VideoID.ToString()] = downloadObj;

            try
            {
                await downloadObj.DownloadVideoAsync(selectedQuality, saveFileDialog1.FileName);
                _activeDownloads.Remove(downloadObj.VideoID.ToString());
            }
            catch (OperationCanceledException)
            {
                downloadObj = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Video: {downloadObj.Title}\nException: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void cmsVidItemOptions_Opening(object sender, CancelEventArgs e)
        {
            if (dgvDownloads.CurrentRow?.DataBoundItem is YouTubeVideo selectedVid)
            {
                if (selectedVid.Status != YouTubeVideo.enStatus.Downloading)
                    tsmCancel.Enabled = false;
                else
                    tsmCancel.Enabled = true;
            }
        }

        private void tsmCancel_Click(object sender, EventArgs e)
        {
            if (dgvDownloads.CurrentRow?.DataBoundItem is YouTubeVideo selectedVid)
                selectedVid.CancelDownload();
        }

        private void tsmOpenFolder_Click(object sender, EventArgs e)
        {
            if (dgvDownloads.CurrentRow?.DataBoundItem is YouTubeVideo selectedVid)
            {
                if (!string.IsNullOrEmpty(selectedVid.DownloadPath))
                {
                    string folderPath = System.IO.Path.GetDirectoryName(selectedVid.DownloadPath);
                    if (Directory.Exists(folderPath))
                        Process.Start("explorer.exe", folderPath);
                    else
                        MessageBox.Show("The download folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("The download path is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
