using Guna.UI2.WinForms;
using PresentationLayer.Applications.DrivingLicenses;
using PresentationLayer.Applications.ManageApplicationTypes.Controls;
using PresentationLayer.Applications.ManageTestTypes.Controls;
using PresentationLayer.MainForm;
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
                case "Manage Local Applications":
                    pnlManageLocalApplications.ShadowDepth = 25;
                    break;
                case "Manage International Applications":
                    pnlManageInternationalApplications.ShadowDepth = 25;
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
                case "Manage Local Applications":
                    pnlManageLocalApplications.ShadowDepth = 0;
                    break;
                case "Manage International Applications":
                    pnlManageInternationalApplications.ShadowDepth = 0;
                    break;
                case "Manage Test Types":
                    pnlManageTestTypes.ShadowDepth = 0;
                    break;
                case "Manage Applications Types":
                    pnlManageApplicationsTypes.ShadowDepth = 0;
                    break;
            }
        }

        // buttons
        private void btnManageApplicationsTypes_Click(object sender, EventArgs e)
        {
            ctrlManageApplicationsTypes applicationsTypes = new ctrlManageApplicationsTypes();
            applicationsTypes.delRemoveFromMainFormContainer_AppTypes += delRemoveFromMainFormContainer;

            delAddToMainFormContainer?.Invoke(applicationsTypes);
            applicationsTypes.BringToFront();
        }
        private void btnManageTestTypes_Click(object sender, EventArgs e)
        {
            ctrlManageTestTypes testTypes = new ctrlManageTestTypes();
            testTypes.delRemoveFromMainFormContainer_TestTypes += delRemoveFromMainFormContainer;

            delAddToMainFormContainer?.Invoke(testTypes);
            testTypes.BringToFront();
        }

        private void btnDrivingLicensesServices_Click(object sender, EventArgs e)
        {
            ctrlDrivingLicensesServices drivingLicensesServices = new ctrlDrivingLicensesServices();
            drivingLicensesServices.delRemoveFromMainFormContainer_DrivingLicenses += delRemoveFromMainFormContainer;

            delAddToMainFormContainer?.Invoke(drivingLicensesServices);
            drivingLicensesServices.BringToFront();
        }

        private void btnManageLocalApplications_Click(object sender, EventArgs e)
        {

        }

        private void btnManageInternationalApplications_Click(object sender, EventArgs e)
        {

        }

        private void btnDetainLicenses_Click(object sender, EventArgs e)
        {

        }
    }
}
