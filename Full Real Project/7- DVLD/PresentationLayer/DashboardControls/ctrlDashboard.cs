using System;
using System.Windows.Forms;

namespace PresentationLayer.DashboardControls
{
    public partial class ctrlDashboard : UserControl
    {
        public ctrlDashboard()
        {
            InitializeComponent();
            lblTodayDate.Text = DateTime.Now.ToLongDateString() + "  |  " + DateTime.Now.ToShortTimeString();
            lblGoodMorningEvening.Text = "Good " + (DateTime.Now.Hour >= 12 ? "Evening, " : "Morning, ").ToString();
        }

       private void ButtonsHandler()
       {

       }
    }
}
