using BusinessLayer;
using PresentationLayer.Drivers.Forms;
using PresentationLayer.Global_Classes;
using System;
using System.Windows.Forms;
using static PresentationLayer.Applications.TestAppointments.ctrlScheduleTestAppointment;

namespace PresentationLayer.Applications.DrivingLicenses.Forms
{
    public partial class frmIssueInternationalLicense : Form
    {
        private int _NewInternationalLicenseID = -1;

        public frmIssueInternationalLicense()
        {
            InitializeComponent();
        }

        private void frmIssueInternationalLicense_Load(object sender, EventArgs e)
        {
            _FillApplicationDefaultInfo();
        }
        private void frmIssueInternationalLicense_Activated(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicenseInfoWithFilter1.FilterFocus();
        }
        private void _FillApplicationDefaultInfo()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = (clsApplicationTypesBusiness.FindApplicationType(clsApplicationTypesBusiness.enApplicationTypes.eNewInternationalLicense)).ApplicationTypeFees.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblCreatedByUser.Text = clsBusinessSettings.CurrentUser.Username;
        }


        private void ctrlLocalDrivingLicenseInfoWithFilter1_OnLicenseSelected()
        {
            if (ctrlLocalDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show($"Local License is expired, not allowed to proceed", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ctrlLocalDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show($"Local License is not active, not allowed to proceed", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLocalLicenseID.Text = ctrlLocalDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();
            btnShowLicensesHistory.Enabled = true;
            btnIssueLicense.Enabled = true;
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            // each person is allowed only one active international license
            int ActiveInternationalLicenseID = clsInternationalLicensesBusiness.GetActiveInterNationalLicenseIDByPersonID(ctrlLocalDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            if (ActiveInternationalLicenseID != -1)
            {
                MessageBox.Show($"Person already has an active International License with ID {ActiveInternationalLicenseID}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int NewInternationalApplicationID = _HandleCreatingInternationalLicenseApplication();
            if (NewInternationalApplicationID == -1)
            {
                MessageBox.Show("Failed to create new International Driving License Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _NewInternationalLicenseID = ctrlLocalDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.IssueInternationalLicense(NewInternationalApplicationID, clsBusinessSettings.CurrentUser.UserID);
            if (_NewInternationalLicenseID != -1)
            {
                MessageBox.Show($"International License is successfully issued with ID {_NewInternationalLicenseID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblInterLicenseID.Text = _NewInternationalLicenseID.ToString();
                btnShowLicenseInfo.Enabled = true;
            }
            else
                MessageBox.Show($"Data was not saved successfully", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int _HandleCreatingInternationalLicenseApplication()
        {
            
            clsApplicationsBusiness InternationalApplication = new clsApplicationsBusiness();

            InternationalApplication.ApplicationTypeID = clsApplicationTypesBusiness.enApplicationTypes.eNewInternationalLicense;
            InternationalApplication.ApplicationStatus = clsApplicationsBusiness.enApplicationStatus.New;
            InternationalApplication.ApplicantPersonID = ctrlLocalDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalApplication.CreatedByUserID = clsBusinessSettings.CurrentUser.UserID;
            InternationalApplication.PaidFees = Convert.ToSingle(lblFees.Text);

            if (InternationalApplication.Save())
            {
                lblInterApplicationID.Text = InternationalApplication.ApplicationID.ToString();
                return InternationalApplication.ApplicationID;
            }
            else
                return -1;
        }


        private void btnShowLicenseInfo_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo licensesInfo = new frmShowInternationalLicenseInfo(_NewInternationalLicenseID);
            clsUtilities.AddToBreadcrumb("> License Info");
            licensesInfo.ShowDialog();
            clsUtilities.RemoveFromBreadcrumb("> License Info");
        }

        private void btnShowLicensesHistory_Click(object sender, EventArgs e)
        {
            frmDriverLicensesHistory licensesHistory = new frmDriverLicensesHistory(ctrlLocalDrivingLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            clsUtilities.AddToBreadcrumb("> Licenses History");
            licensesHistory.ShowDialog();
            clsUtilities.RemoveFromBreadcrumb("> Licenses History");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
