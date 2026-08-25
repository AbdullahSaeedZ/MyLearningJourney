using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouTube_Downloader.Services;

namespace YouTube_Downloader
{
    public partial class Form1 : Form
    {
        private BindingList<YouTubeVideo> _downloadsList;
        private YouTubeVideo _youTubeVideo;

        private int _activeDownloadsCount = 0;
        private readonly int _activeDownloadsLimit = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private async Task InitializeDownloadListAsync()
        {
            _downloadsList = await Serializer.LoadVideosAsync();

            if (_downloadsList == null)
                _downloadsList = new BindingList<YouTubeVideo>();

            dgvDownloads.AutoGenerateColumns = false;
            dgvDownloads.DataSource = _downloadsList;
            lblNoDownloadsYet.Visible = dgvDownloads.RowCount == 0;
        }
        private void InitializeFileDialog()
        {
            saveFileDialog1.DefaultExt = ".mp4";
            saveFileDialog1.Title = "Save Video";
            saveFileDialog1.Filter = "MP4 Video (*.mp4)|*.mp4";
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
        }
        private void HandleDownloadFinished()
        {
            _activeDownloadsCount--;
            if (_activeDownloadsCount < _activeDownloadsLimit)
            {
                lblDownloadsLimitReached.Visible = false;
                tbURL.Visible = true;
                btnGetVidInfo.Visible = true;
            }
        }
        private void HandleDownloadStarted()
        {
            _activeDownloadsCount++;
            if (_activeDownloadsCount >= _activeDownloadsLimit)
            {
                lblDownloadsLimitReached.Visible = true;
                tbURL.Visible = false;
                btnGetVidInfo.Visible = false;
            }
            lblNoDownloadsYet.Visible = dgvDownloads.RowCount == 0;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _youTubeVideo = new YouTubeVideo();
            _youTubeVideo.OnDownloadStarted += HandleDownloadStarted;
            _youTubeVideo.OnDownloadFinished += HandleDownloadFinished;

            InitializeFileDialog();
            await InitializeDownloadListAsync();
        }


        // buttons
        private async void btnGetVidInfo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbURL.Text))
            {
                MessageBox.Show("Please enter a valid YouTube video URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await StartFetchingInfoAsync();
        }
        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (!OpenSaveFileDialog())
                return;

            // to capture the current vid object with his context before resetting to allow next concurrent download
            YouTubeVideo downloadObj = _youTubeVideo;
            string selectedQuality = cbQualities.SelectedItem?.ToString();
            // to reset the youtube object to allow next download object to be captured in next context
            _youTubeVideo = new YouTubeVideo();
            pnlVidInfo.Visible = false;
            ResetInfoCard();

            await StartDownloadingVideoAsync(downloadObj, selectedQuality);

        }
        private void btnCloseVidInfo_Click(object sender, EventArgs e)
        {
            ResetInfoCard();
            pnlVidInfo.Visible = false;
            _youTubeVideo = null;
            _youTubeVideo = new YouTubeVideo();
        }



        private bool OpenSaveFileDialog()
        {
            saveFileDialog1.FileName = _youTubeVideo.Title;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return false;
            return true;
        }

        private async Task StartDownloadingVideoAsync(YouTubeVideo video, string selectedQuality)
        {
            try
            {
                _downloadsList.Add(video);
                await video.DownloadVideoAsync(selectedQuality, saveFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                video.Status = YouTubeVideo.enStatus.Failed;
            }
            finally
            {
                _ = Serializer.SerializeObjectAsync(video);
                video.Dispose();
            }
        }

        private async Task StartFetchingInfoAsync()
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

            pnlVidDuration.Invalidate();
            pbVidThumbnail.LoadAsync(_youTubeVideo.ThumbnailURL ?? string.Empty);
            cbQualities.DataSource = _youTubeVideo.QualitiesAndSizes.Keys.ToList();
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
            cbQualities.DataSource = null;
        }

        private void cbQualities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbQualities.SelectedItem != null) // cuz this event will be triggered when resetting the info card and setting the datasource to null
                lblVidSize.Text = _youTubeVideo.GetFileSize(cbQualities.SelectedItem.ToString())?? "N/A";
        }


        // context menu
        private void cmsVidItemOptions_Opening(object sender, CancelEventArgs e)
        {
            if (dgvDownloads.CurrentRow?.DataBoundItem is YouTubeVideo selectedVid)
            {
                if (selectedVid.Status != YouTubeVideo.enStatus.Downloading)
                {
                    tsmCancel.Enabled = false;
                    tsmDelete.Enabled = true;
                }
                else
                {
                    tsmCancel.Enabled = true;
                    tsmDelete.Enabled = false;
                }
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
                    string folderPath = Path.GetDirectoryName(selectedVid.DownloadPath);
                    if (Directory.Exists(folderPath))
                        Process.Start("explorer.exe", folderPath);
                    else
                        MessageBox.Show("The download folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("The download path is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void tsmDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this download from history?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            if (dgvDownloads.CurrentRow?.DataBoundItem is YouTubeVideo selectedVid)
            {
                _downloadsList.Remove(selectedVid);
                await Serializer.SerializeListAsync(_downloadsList);
            }

            lblNoDownloadsYet.Visible = dgvDownloads.RowCount == 0;
        }

      
    }
}
