using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Applications.ManageLocalApplications.Forms
{
    public partial class frmIssueNewLocalDrivingLicense : Form
    {
        public event Action OnLicenseIssue;
        int _LocalApplicationID = -1;

        public frmIssueNewLocalDrivingLicense(int LocalApplicationID)
        {
            InitializeComponent();
            _LocalApplicationID = LocalApplicationID;
        }

        private void frmIssueNewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlLocalApplicationInfo1.LoadInfo(_LocalApplicationID);
            if (ctrlLocalApplicationInfo1.SelectedLocalApplication == null)
            {
                MessageBox.Show("Could not get selected Local Application Info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        private void btnIssueNewLicense_Click(object sender, EventArgs e)
        {
            int NewLicenseID = ctrlLocalApplicationInfo1.SelectedLocalApplication.IssueNewLicense(tbNotes.Text, clsBusinessSettings.CurrentUser.UserID);
            if (NewLicenseID != -1)
            {
                MessageBox.Show($"Data saved successfully, new local driving license with id {NewLicenseID} is issued and applicant now has a new driver record",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OnLicenseIssue?.Invoke();
                btnIssueNewLicense.Enabled = false;
                tbNotes.Enabled = false;
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
