using BusinessLayer;
using PresentationLayer.MainForm;
using PresentationLayer.PeopleFormsAndControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.UsersFormsAndControls
{
    public partial class ctrlUsers : UserControl
    {

        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumb;
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


        // search people by..
        // controlling textBox based on comboBox option
        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _searchFilter = cbSearchBy.Text.Replace(" ", ""); // matching database names, not dgv. First Name in dgv, to be FirstName here to match DT & DB

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

        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            delUpdateBreadcrumb(sender, new frmMain.clsBreadcrumbData() { title = "> User Details", operationType = "Add" });

            frmPersonInfo personInfo = new frmPersonInfo((int)dgvUsers.SelectedCells[0].Value);
            personInfo.delUpdateBreadcrumb2 += (se, ev) => delUpdateBreadcrumb(se, ev);
            personInfo.ShowDialog();

            delUpdateBreadcrumb(sender, new frmMain.clsBreadcrumbData() { title = "> User Details", operationType = "Remove" });
            RefreshDataGridView();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            delUpdateBreadcrumb(sender, new frmMain.clsBreadcrumbData() { title = "> Add-Edit User", operationType = "Add" });
            frmAddEditPerson addPersonForm = new frmAddEditPerson(-1);
            addPersonForm.ShowDialog();
            delUpdateBreadcrumb(sender, new frmMain.clsBreadcrumbData() { title = "> Add-Edit User", operationType = "Remove" });
            RefreshDataGridView();
        }


        // toolstrips menu
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvUsers.SelectedCells[0].Value;
            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Person Details", operationType = "Add" });
            frmPersonInfo personInfo = new frmPersonInfo(PersonID);
            personInfo.delUpdateBreadcrumb2 += (se, ev) => delUpdateBreadcrumb(se, ev);
            personInfo.ShowDialog();
            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Person Details", operationType = "Remove" });
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvUsers.SelectedCells[0].Value;
            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Add" });
            frmAddEditPerson addPersonForm = new frmAddEditPerson(PersonID);
            addPersonForm.ShowDialog();
            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Remove" });
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvUsers.SelectedCells[0].Value;
            if (MessageBox.Show($"Are you sure to delete person wIth ID{PersonID}?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
            {
                if (clsPeopleBusiness.DeletePerson(PersonID))
                {
                    MessageBox.Show($"Person with ID {PersonID} was successfully deleted.", "Success", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show($"Person with ID{PersonID} CAN NOT be deleted due to linked data to be deleted first.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
