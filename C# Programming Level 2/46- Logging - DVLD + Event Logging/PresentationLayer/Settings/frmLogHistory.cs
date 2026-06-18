using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Settings
{
    public partial class frmLogHistory : Form
    {
        private string _logHistoryText;
        public frmLogHistory()
        {
            InitializeComponent();
            
        }

        private void frmLogHistory_Load(object sender, EventArgs e)
        {
            _logHistoryText = clsBusinessSettings.GetLogHistory();

            if (string.IsNullOrWhiteSpace(_logHistoryText))
                _logHistoryText = "No Data Available";

            tbLogText.Text = _logHistoryText;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_logHistoryText))
                Clipboard.SetText(_logHistoryText);
        }
        
    }
}
