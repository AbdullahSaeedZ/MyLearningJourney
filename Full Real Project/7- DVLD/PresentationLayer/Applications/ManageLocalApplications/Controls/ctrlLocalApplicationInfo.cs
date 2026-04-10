using BusinessLayer;
using PresentationLayer.Global_Classes;
using PresentationLayer.PeopleFormsAndControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Applications.ManageLocalApplications.Controls
{
    public partial class ctrlLocalApplicationInfo : UserControl
    {

        private int _LocalApplicationID;
        clsLocalDrivingLicenseApplicationsBusiness _LocalApplication;
        public clsLocalDrivingLicenseApplicationsBusiness SelectedLocalApplication { get { return _LocalApplication; } }

        public int DrivingLicenseApplicationBorderThickness
        {
            set
            {
                pnlLocalApplicationInfo.BorderThickness = value;
            }
            get
            {
                return pnlLocalApplicationInfo.BorderThickness;
            }
        }
        public Color DrivingLicenseApplicationBorderColor
        {
            set
            {
                pnlLocalApplicationInfo.BorderColor = value;
            }
            get
            {
                return pnlLocalApplicationInfo.BorderColor;
            }
        }


        public int BasicApplicationBorderThickness
        {
            set
            {
                pnlBaseApplicationInfo.BorderThickness = value;
            }
            get
            {
                return pnlBaseApplicationInfo.BorderThickness;
            }
        }
        public Color BasicApplicationBorderColor
        {
            set
            {
                pnlBaseApplicationInfo.BorderColor = value;
            }
            get
            {
                return pnlBaseApplicationInfo.BorderColor;
            }
        }

        public ctrlLocalApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int LocalDrivingLicenseApplicationID)
        {
            _LocalApplication = clsLocalDrivingLicenseApplicationsBusiness.FindLocalLicenseApplicationByID(LocalDrivingLicenseApplicationID);

            if (_LocalApplication == null)
            {
                MessageBox.Show($"Local Driving License Application ID = {LocalDrivingLicenseApplicationID} was not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillLocalApplicationInfo();
            _FillBaseApplicationInfo();
        }
     

        public void ResetApplicationInfo()
        {
            lblLocalApplicationID.Text = "";
            lblLicenseClassName.Text = "";
            lblPassedTests.Text = "";
            btnShowLicenseInfo.Enabled = false;

            lblBaseApplicationID.Text = "";
            lblApplicationStatus.Text = "";
            lblApplicationType.Text = "";
            lblApplicantFullName.Text = "";
            lblApplicationDate.Text = "";
            lblCreatedByUser.Text = "";
            btnShowPersonInfo.Enabled = false;
        }


        private void _FillLocalApplicationInfo()
        {
            lblLocalApplicationID.Text = _LocalApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClassName.Text = _LocalApplication.LicenseClassesInfo.ClassName;
            lblPassedTests.Text = _LocalApplication.TestsStatus.PassedTestsCount.ToString() + " out of 3";

            btnShowLicenseInfo.Enabled = _LocalApplication.IsLicenseIssued();
        }

        private void _FillBaseApplicationInfo()
        {
            lblBaseApplicationID.Text = _LocalApplication.ApplicationID.ToString();
            lblApplicationStatus.Text = _LocalApplication.ApplicationStatus.ToString();
            lblApplicationType.Text = _LocalApplication.PaidFees.ToString();
            lblApplicantFullName.Text = _LocalApplication.ApplicantPersonInfo.FullName;
            lblApplicationDate.Text = _LocalApplication.ApplicationDate.ToShortDateString();
            lblCreatedByUser.Text = _LocalApplication.CreatedByUserID.ToString();

            btnShowPersonInfo.Enabled = true;
        }

        private void btnShowLicenseInfo_Click(object sender, EventArgs e)
        {
            clsUtilities.AddToBreadcrumb("> License Info");
            
            clsUtilities.RemoveFromBreadcrumb("> License Info");
        }

        private void btnShowPersonInfo_Click(object sender, EventArgs e)
        {
            clsUtilities.AddToBreadcrumb("> Person Info");
            frmPersonInfo frmPersonInfo = new frmPersonInfo(_LocalApplication.ApplicantPersonID);
            frmPersonInfo.ShowDialog();
            clsUtilities.RemoveFromBreadcrumb("> Person Info");
        }
    }
}
