using BusinessLayer;
using PresentationLayer.Applications.DrivingLicenses.Forms;
using PresentationLayer.Applications.ManageLocalApplications.Forms;
using PresentationLayer.Applications.TestAppointments.Forms;
using PresentationLayer.Global_Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace PresentationLayer.Applications.ManageLocalApplications
{
    public partial class ctrlManageLocalApplications : UserControl
    {
        public event Action<UserControl> delRemoveFromMainFormContainer_ManageLocalApplications;
        private DataTable dt;
        private string _searchFilter; // to use in search filters and match DT and DB column names, not dgv names

        public ctrlManageLocalApplications()
        {
            InitializeComponent();
        }

        private void ctrlManageLocalApplications_Load(object sender, EventArgs e)
        {
            clsUtilities.AddToBreadcrumb("> Manage Local Licenses Applications");
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            if ((dt = clsLocalDrivingLicenseApplicationsBusiness.GetAllLocalDrivingLicenseApplications()) == null)
                return;

            dgvApplications.DataSource = dt;
            lblNumberOfRecords.Text = dgvApplications.RowCount.ToString();
        }


        // search Applications by..
        // controlling textBox based on comboBox option
        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // i will use this filter variable in the data table filter, and it has to match the DB column name not the one i used in combo box, the rest are ok
            _searchFilter = cbSearchBy.Text == "LDL.Application ID"? "LocalDrivingLicenseApplicationID" : cbSearchBy.Text.Replace(" ", "");

            if (_searchFilter == "None")
            {
                tbSearchApplication.Text = "";
                tbSearchApplication.Visible = false;
                cbStatus.Visible = false;
                lblNumberOfRecords.Text = dgvApplications.RowCount.ToString(); // to update number when switching to none after being filtered
                return;
            }

            if (_searchFilter == "Status")
            {
                tbSearchApplication.Visible = false;
                cbStatus.Visible = true;
                return;
            }

            cbStatus.Visible = false;
            tbSearchApplication.Visible = true;
            tbSearchApplication.Text = "";

            if (_searchFilter == "LocalDrivingLicenseApplicationID")
                tbSearchApplication.PlaceholderText = "Only numbers allowed";
            else
                tbSearchApplication.PlaceholderText = "Search..";

        }
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.Text == "All")
            {
                dt.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvApplications.RowCount.ToString();
                return;
            }

            dt.DefaultView.RowFilter = $"Status LIKE '{cbStatus.Text}'";
            lblNumberOfRecords.Text = dgvApplications.RowCount.ToString();
        }
        private void tbSearchApplication_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchApplication.Text))
            {
                dt.DefaultView.RowFilter = ""; // when deleting text
                lblNumberOfRecords.Text = dgvApplications.RowCount.ToString();
                return;
            }

            dt.DefaultView.RowFilter = $"Convert({_searchFilter}, 'System.String') LIKE '{tbSearchApplication.Text}%'";
            lblNumberOfRecords.Text = dgvApplications.RowCount.ToString();

            // filtering expression uses DataColumn Expression Language
            // it takes column names from dataTable that took them from Database, not header names in dgv
            //since like is for strings only and we might get int column, we cast column type to string using this method from DT special language
        }
        private void tbSearchApplication_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_searchFilter == "LDL.ApplicationID")
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back; // if Handled == true then will prevent any action
        }



        // using OnUpdate event below is to control WHEN to refresh, instead of refreshing once opened and closed the forms even if no update done
        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            if (!clsBusinessSettings.CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eAddPerson))
            {
                MessageBox.Show("Access Denied, contact your admin to get permission.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmAddEditLocalLicenseApplication addApplicationForm = new frmAddEditLocalLicenseApplication();
            addApplicationForm.OnUpdateDoneForDGV += RefreshDataGridView; // to update DGV here if new person added and updated in AddEdit form
            clsUtilities.AddToBreadcrumb("> Add-Edit Application");
            addApplicationForm.ShowDialog();
            clsUtilities.RemoveFromBreadcrumb("> Add-Edit Application");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            clsUtilities.RemoveFromBreadcrumb("> Manage Local Licenses Applications");
            delRemoveFromMainFormContainer_ManageLocalApplications?.Invoke(this);
        }

        private void dgvApplications_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showApplicationDetailsToolStripMenuItem_Click(sender, EventArgs.Empty);
        }

        //strip menu options

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int LocalLicenseApplicationID = (int)dgvApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplicationsBusiness _selectedApplication = clsLocalDrivingLicenseApplicationsBusiness.FindLocalLicenseApplicationByID(LocalLicenseApplicationID);
            if (_selectedApplication == null)
            {
                MessageBox.Show("Could not get application info from database.", "Connection Lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool AllTestsPassed = (_selectedApplication.TestsStatus.IsVisionTestPassed && _selectedApplication.TestsStatus.IsWrittenTestPassed && _selectedApplication.TestsStatus.IsStreetTestPassed);
            bool IsLicenseIssued = _selectedApplication.IsLicenseIssued();
            bool IsApplicationStatusNew = (_selectedApplication.ApplicationStatus == clsApplicationsBusiness.enApplicationStatus.New);


            // when license of same class is issued before , even if application is cancelled, it means applicant applied for another application and completed everything then issued a license
            showLicenseDetailsToolStripMenuItem.Enabled = IsLicenseIssued;

            // when application is new and not all tests passed
            editApplicationToolStripMenuItem.Enabled = !IsLicenseIssued && IsApplicationStatusNew; // can only edit applications with new status and no issued license
            deleteApplicationToolStripMenuItem.Enabled = IsApplicationStatusNew;// can only delete applications with new status
            cancelApplicationToolStripMenuItem.Enabled = IsApplicationStatusNew; // can only cancel applications with new status

            // when application is new but all tests passed and ready for license issuance
            // cuz might have cancelled application with issued license
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (AllTestsPassed && !IsLicenseIssued & IsApplicationStatusNew);
            ScheduleTestsToolStripMenuItem.Enabled = (!AllTestsPassed && IsApplicationStatusNew);

            if (ScheduleTestsToolStripMenuItem.Enabled)
            {
                // tests must be taken and completed in this order: vision then written then street
                scheduleVisionTestToolStripMenuItem.Enabled = (!_selectedApplication.TestsStatus.IsVisionTestPassed);
                scheduleWrittenTestToolStripMenuItem.Enabled = (_selectedApplication.TestsStatus.IsVisionTestPassed && !_selectedApplication.TestsStatus.IsWrittenTestPassed);
                scheduleStreetTToolStripMenuItem.Enabled = (_selectedApplication.TestsStatus.IsVisionTestPassed && _selectedApplication.TestsStatus.IsWrittenTestPassed
                                                            && !_selectedApplication.TestsStatus.IsStreetTestPassed);
            }
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUtilities.AddToBreadcrumb("> Application Info");
            frmLocalApplicationInfo frmLocalApplicationInfo = new frmLocalApplicationInfo((int)dgvApplications.CurrentRow.Cells[0].Value);
            frmLocalApplicationInfo.ShowDialog();
            clsUtilities.RemoveFromBreadcrumb("> Application Info");
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel this application ?", "Cancel Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                clsLocalDrivingLicenseApplicationsBusiness _selectedApplication = clsLocalDrivingLicenseApplicationsBusiness.FindLocalLicenseApplicationByID((int)dgvApplications.SelectedCells[0].Value);
                if (_selectedApplication != null)
                {
                    if (_selectedApplication.SetStatusToCancelled())
                    {
                        MessageBox.Show("Application is cancelled successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDataGridView();
                    }
                    else
                        MessageBox.Show("Could not cancel the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalApplicationID = (int)dgvApplications.CurrentRow.Cells[0].Value;

            clsUtilities.AddToBreadcrumb("> Vision Test Appointments");
            frmListTestAppointments testAppointments = new frmListTestAppointments(LocalApplicationID, clsTestTypesBusiness.enTestType.Vision);
            testAppointments.delUpdateLocalApplicationsDGV += RefreshDataGridView;
            testAppointments.ShowDialog();
            clsUtilities.RemoveFromBreadcrumb("> Vision Test Appointments");
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalApplicationID = (int)dgvApplications.CurrentRow.Cells[0].Value;

            clsUtilities.AddToBreadcrumb("> Written Test Appointments");
            frmListTestAppointments testAppointments = new frmListTestAppointments(LocalApplicationID, clsTestTypesBusiness.enTestType.Written);
            testAppointments.delUpdateLocalApplicationsDGV += RefreshDataGridView;
            testAppointments.ShowDialog();
            clsUtilities.RemoveFromBreadcrumb("> Written Test Appointments");
        }

        private void scheduleStreetTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalApplicationID = (int)dgvApplications.CurrentRow.Cells[0].Value;

            clsUtilities.AddToBreadcrumb("> Street Test Appointments");
            frmListTestAppointments testAppointments = new frmListTestAppointments(LocalApplicationID, clsTestTypesBusiness.enTestType.Street);
            testAppointments.delUpdateLocalApplicationsDGV += RefreshDataGridView;
            testAppointments.ShowDialog();
            clsUtilities.RemoveFromBreadcrumb("> Street Test Appointments");
        }



        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        
    }
}
