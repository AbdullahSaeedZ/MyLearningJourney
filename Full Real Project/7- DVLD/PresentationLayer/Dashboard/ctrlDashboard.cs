using System;
using System.Windows.Forms;

namespace PresentationLayer.DashboardControls
{
    public partial class ctrlDashboard : UserControl
    {
        string TimeNow;
        string DateNow;

        public ctrlDashboard()
        {
            InitializeComponent();
           
        }

        private void ctrlDashboard_Load(object sender, EventArgs e)
        {
            // to be moved to separate method
            DateNow = DateTime.Now.ToLongDateString();
            TimeNow = DateTime.Now.ToLongTimeString();
            timer1.Enabled = true;

            lblTodayDate.Text = DateNow + "  |  " + TimeNow;
            lblGoodMorningEvening.Text = "Good " + (DateTime.Now.Hour >= 12 ? "Evening, " : "Morning, ").ToString();
        }

        private void ButtonsHandler()
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeNow = DateTime.Now.ToLongTimeString();
            lblTodayDate.Text = DateNow + "  |  " + TimeNow;
        }
    }
}
