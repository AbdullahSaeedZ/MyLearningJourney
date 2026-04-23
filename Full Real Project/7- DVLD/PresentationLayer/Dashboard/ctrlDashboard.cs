using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer.DashboardControls
{
    public partial class ctrlDashboard : UserControl
    {
        private string TimeNow;
        private string DateNow;
        private clsDashboardBusiness _Data;

        public ctrlDashboard()
        {
            InitializeComponent();
           
        }

        private void ctrlDashboard_Load(object sender, EventArgs e)
        {
            _Data = clsDashboardBusiness.GetDashboardData();
            if (_Data == null)
            {
                MessageBox.Show("Could not retrieve overview data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _StartTime();
            _FillData();
        }

        private void _StartTime()
        {
            DateNow = DateTime.Now.ToLongDateString();
            TimeNow = DateTime.Now.ToLongTimeString();
            timer1.Enabled = true;
        }
        private void _FillData()
        {
            lblTodayDate.Text = DateNow + "  |  " + TimeNow;
            lblGoodMorningEvening.Text = "Good " + (DateTime.Now.Hour >= 12 ? "Evening, " : "Morning, ") + clsBusinessSettings.CurrentUser.Username + " !";

            lblTotalExamxComplete.Text = _Data.TotalPassedTests.ToString();
            lblTotalApplicationsCompleted.Text = _Data.TotalApplicationsCompleted.ToString();
            lblTotalDrivers.Text = _Data.TotalDrivers.ToString();
            lblTotalUsers.Text = _Data.TotalUsers.ToString();
            lblTotalPeople.Text = _Data.TotalPeople.ToString();
            lblTotalLicenses.Text = _Data.TotalLicenses.ToString();
            lblTotalFeesThisMonth.Text = _Data.TotalPaidFeesThisMonth.ToString();
            lblTotalFeesAllTime.Text = _Data.TotalPaidFeesAllTime.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeNow = DateTime.Now.ToLongTimeString();
            lblTodayDate.Text = DateNow + "  |  " + TimeNow;
        }

        private void ctrlDashboard_Leave(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
