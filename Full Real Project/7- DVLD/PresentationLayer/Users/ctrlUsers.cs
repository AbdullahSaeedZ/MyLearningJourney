using BusinessLayer;
using Microsoft.VisualBasic.ApplicationServices;
using PresentationLayer.MainForm;
using PresentationLayer.PeopleFormsAndControls;
using PresentationLayer.Users.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace PresentationLayer.UsersFormsAndControls
{
    public partial class ctrlUsers : UserControl
    {

        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumbFromUserControl;
        private DataTable dt;
        private string _searchFilter; // to use in search filters and match DT and DB column names, not dgv names

        public ctrlUsers()
        {
            InitializeComponent();
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            if ((dt = clsUserBusiness.GetAllUsers()) == null)
                return;

            dgvUsers.DataSource = dt;
            lblNumberOfRecords.Text = dgvUsers.RowCount.ToString();
        }


        // search User by..
        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _searchFilter = cbSearchBy.Text.Replace(" ", ""); // matching database names, not dgv. User ID in dgv, to be UserID here to match DT & DB

            if (_searchFilter == "None")
            {
                tbSearchUsers.Text = "";
                dt.DefaultView.RowFilter = "";
                tbSearchUsers.Visible = false;
                cbIsActive.Visible = false;
                return;
            }

            if (_searchFilter == "IsActive")
            {
                tbSearchUsers.Visible = false;
                cbIsActive.Visible = true;
                return;
            }
         

            cbIsActive.Visible = false;
            tbSearchUsers.Visible = true;
            tbSearchUsers.Text = "";

            if (_searchFilter == "PersonID" || _searchFilter == "UserID")
                tbSearchUsers.PlaceholderText = "Only numbers allowed";
            else
                tbSearchUsers.PlaceholderText = "Search..";
        }
        private void tbSearchUsers_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchUsers.Text))
            {
                dt.DefaultView.RowFilter = ""; // when deleting text
                lblNumberOfRecords.Text = dgvUsers.RowCount.ToString();
                return;
            }

            dt.DefaultView.RowFilter = $"Convert({_searchFilter}, 'System.String') LIKE '{tbSearchUsers.Text}%'";
            lblNumberOfRecords.Text = dgvUsers.RowCount.ToString();

            // filtering expression uses DataColumn Expression Language
            // it takes column names from dataTable that took them from Database, not names in dgv
            //since like is for strings only and we might get int column, we cast column type to string using this method from DT special language
        }
        private void tbSearchUsers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_searchFilter == "PersonID" || _searchFilter == "UserID")
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back; // if Handled == true then will prevent any action
        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsActive.Text == "All")
            {
                dt.DefaultView.RowFilter = "";
                return;
            }

            byte filter = cbIsActive.Text == "No" ? (byte)0 : (byte)1;
            dt.DefaultView.RowFilter = $"IsActive = {filter}";
            lblNumberOfRecords.Text = dgvUsers.RowCount.ToString();
        }


        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!clsBusinessSettings.CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eAddUser))
            {
                MessageBox.Show("Access Denied, contact your admin to get permission.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            delUpdateBreadcrumbFromUserControl(this, new frmMain.clsBreadcrumbData() { title = "> Add-Edit User", operationType = "Add" });

            frmAddEditUser addUserForm = new frmAddEditUser(-1);
            addUserForm.delUpdateBreadcrumbFromAddEditUserForm += (se, ev) => delUpdateBreadcrumbFromUserControl(se, ev);
            addUserForm.ShowDialog();

            delUpdateBreadcrumbFromUserControl(this, new frmMain.clsBreadcrumbData() { title = "> Add-Edit User", operationType = "Remove" });
            RefreshDataGridView();
        }
        private void dgvUsers_DoubleClick(object sender, EventArgs e)
        {
            delUpdateBreadcrumbFromUserControl(sender, new frmMain.clsBreadcrumbData() { title = "> User Details", operationType = "Add" });

            
            frmUserInfo UserInfo = new frmUserInfo((int)dgvUsers.SelectedCells[0].Value);
            UserInfo.delUpdateBreadcrumbFromUserInfoForm += (se, ev) => delUpdateBreadcrumbFromUserControl(se, ev);
            UserInfo.ShowDialog();

            delUpdateBreadcrumbFromUserControl(sender, new frmMain.clsBreadcrumbData() { title = "> User Details", operationType = "Remove" });
        }


        // toolstrips menu
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delUpdateBreadcrumbFromUserControl(sender, new frmMain.clsBreadcrumbData() { title = "> User Details", operationType = "Add" });

            frmUserInfo UserInfo = new frmUserInfo((int)dgvUsers.SelectedCells[0].Value);
            UserInfo.delUpdateBreadcrumbFromUserInfoForm += (se, ev) => delUpdateBreadcrumbFromUserControl(se, ev);
            UserInfo.ShowDialog();

            delUpdateBreadcrumbFromUserControl(sender, new frmMain.clsBreadcrumbData() { title = "> User Details", operationType = "Remove" });
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsBusinessSettings.CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eUpdateUser))
            {
                MessageBox.Show("Access Denied, contact your admin to get permission.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            delUpdateBreadcrumbFromUserControl(this, new frmMain.clsBreadcrumbData() { title = "> Edit User", operationType = "Add" });

            frmAddEditUser EditUserForm = new frmAddEditUser((int)dgvUsers.SelectedCells[0].Value);
            EditUserForm.delUpdateBreadcrumbFromAddEditUserForm += (se, ev) => delUpdateBreadcrumbFromUserControl(se, ev);
            EditUserForm.OnUpdateDone += RefreshDataGridView;
            EditUserForm.ShowDialog();

            delUpdateBreadcrumbFromUserControl(this, new frmMain.clsBreadcrumbData() { title = "> Edit User", operationType = "Remove" });
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsBusinessSettings.CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eUpdateUser))
            {
                MessageBox.Show("Access Denied, contact your admin to get permission.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            delUpdateBreadcrumbFromUserControl(this, new frmMain.clsBreadcrumbData() { title = "> Change User Password", operationType = "Add" });

            frmChangePassword changePassword = new frmChangePassword((int)dgvUsers.SelectedCells[0].Value);
            changePassword.delUpdateBreadcrumbFromChangePasswordForm += (se, ev) => delUpdateBreadcrumbFromUserControl(se, ev);
            changePassword.ShowDialog();

            delUpdateBreadcrumbFromUserControl(this, new frmMain.clsBreadcrumbData() { title = "> Change User Password", operationType = "Remove" });
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsBusinessSettings.CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eDeleteUser))
            {
                MessageBox.Show("Access Denied, contact your admin to get permission.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int UserID = (int)dgvUsers.SelectedCells[0].Value;
            try
            {
                if (MessageBox.Show($"Are you sure to delete User wIth ID {UserID}?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (clsUserBusiness.DeleteUser(UserID))
                    {
                        MessageBox.Show($"User with ID {UserID} was successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDataGridView();
                    }
                    else
                        MessageBox.Show($"User with ID {UserID} CAN NOT be deleted due to linked data to be deleted first.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
