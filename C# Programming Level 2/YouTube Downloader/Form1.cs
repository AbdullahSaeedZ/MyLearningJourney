using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouTube_Downloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvDownloads.ScrollBars = ScrollBars.Vertical;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pnlVidInfo.Visible = true;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            dgvDownloads.Rows.Add("Video Title", "Video URL", "Download Status", "230 MB", "23/12/2023");
        }
    }
}
