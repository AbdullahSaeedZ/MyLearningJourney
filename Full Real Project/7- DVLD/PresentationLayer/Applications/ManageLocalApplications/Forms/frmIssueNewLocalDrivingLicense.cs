using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Applications.ManageLocalApplications.Forms
{
    public partial class frmIssueNewLocalDrivingLicense : Form
    {
        public event Action OnLicenseIssue;
        int _LocalApplicationID = -1;
        clsLicensesBusiness NewLicense;

        public frmIssueNewLocalDrivingLicense(int LocalApplicationID)
        {
            InitializeComponent();
            _LocalApplicationID = LocalApplicationID;
        }

        private void frmIssueNewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            if (_LocalApplicationID == -1)
            {
                MessageBox.Show("Could not get selected Local Application Info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlLocalApplicationInfo1.LoadInfo(_LocalApplicationID);
        }

        private void btnIssueNewLicense_Click(object sender, EventArgs e)
        {
            NewLicense = new clsLicensesBusiness();

            NewLicense.ApplicationID = ctrlLocalApplicationInfo1.SelectedLocalApplication.ApplicationID;
            //NewLicense.DriverID  make as private set, driver record automatically added once license issued
            NewLicense.Notes = tbNotes.Text; // check is if null is handled in data access layer
            NewLicense.CreatedByUserID = clsBusinessSettings.CurrentUser.UserID;
            NewLicense.IssueReason = clsLicensesBusiness.enIssueReason.FirstTime;
            NewLicense.IsActive = true;
            NewLicense.LicenseClassID = ctrlLocalApplicationInfo1.SelectedLocalApplication.LicenseClassID;
            NewLicense.PaidFees = ctrlLocalApplicationInfo1.SelectedLocalApplication.PaidFees; // it is the local driving application

            if (NewLicense.Save())
            {
                MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnLicenseIssue?.Invoke();
                btnIssueNewLicense.Enabled = false;
            }
            else
                MessageBox.Show("Data was not saved successfully", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
