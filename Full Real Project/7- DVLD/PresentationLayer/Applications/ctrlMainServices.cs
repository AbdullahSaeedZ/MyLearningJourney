using Guna.UI2.WinForms;
using PresentationLayer.Applications.ManageApplicationTypes.Controls;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Applications
{
    public partial class ctrlMainServices : UserControl
    {
        public event Action<UserControl> delAddToMainFormContainer;
        public event Action<UserControl> delRemoveFromMainFormContainer;
        public ctrlMainServices()
        {
            InitializeComponent();
        }


        // to control the buttons shadow effect
        private void buttons_MouseEnter(object sender, EventArgs e)
        {
            string btnName = ((Guna2Button)sender).Tag.ToString();

            switch(btnName)
            {
                case "Detain Licenses":
                    pnlDetainLicenses.ShadowDepth = 25;
                    break;
                case "Driving Licenses Services":
                    pnlDrivingLicensesServices.ShadowDepth = 25;
                    break;
                case "Manage Applications":
                    pnlManageApplications.ShadowDepth = 25;
                    break;
                case "Manage Test Types":
                    pnlManageTestTypes.ShadowDepth = 25;
                    break;
                case "Manage Applications Types":
                    pnlManageApplicationsTypes.ShadowDepth = 25;
                    break;
            }
        }
        private void buttons_MouseLeave(object sender, EventArgs e)
        {
            string btnName = ((Guna2Button)sender).Tag.ToString();

            switch (btnName)
            {
                case "Detain Licenses":
                    pnlDetainLicenses.ShadowDepth = 0;
                    break;
                case "Driving Licenses Services":
                    pnlDrivingLicensesServices.ShadowDepth = 0;
                    break;
                case "Manage Applications":
                    pnlManageApplications.ShadowDepth = 0;
                    break;
                case "Manage Test Types":
                    pnlManageTestTypes.ShadowDepth = 0;
                    break;
                case "Manage Applications Types":
                    pnlManageApplicationsTypes.ShadowDepth = 0;
                    break;
            }
        }

        private void btnManageApplicationsTypes_Click(object sender, EventArgs e)
        {
            ctrlManageApplicationsTypes applicationsTypes = new ctrlManageApplicationsTypes();
            applicationsTypes.delRemoveFromMainFormContainer_AppTypes += delRemoveFromMainFormContainer;

            delAddToMainFormContainer?.Invoke(applicationsTypes);
            applicationsTypes.BringToFront();
        }
    }
}
