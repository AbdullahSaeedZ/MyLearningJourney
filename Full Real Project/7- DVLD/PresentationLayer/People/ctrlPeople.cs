using BusinessLayer;
using Microsoft.VisualBasic.ApplicationServices;
using PresentationLayer.MainForm;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace PresentationLayer.PeopleFormsAndControls
{
    public partial class ctrlPeople : UserControl
    {

        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumb;
        private enum enGender { Male = 0, Female = 1 };
        private DataTable dt;
        private string _searchFilter; // to use in search filters and match DT and DB column names, not dgv names

        public ctrlPeople()
        {
            InitializeComponent();
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            if ((dt = clsPeopleBusiness.GetAllPeople()) == null)
                return;
            
            dgvPeople.DataSource = dt;
            lblNumberOfRecords.Text = dgvPeople.RowCount.ToString();
        }
 

        // search people by..
        // controlling textBox based on comboBox option
        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _searchFilter = cbSearchBy.Text.Replace(" ", ""); // matching database names, not dgv. First Name in dgv, to be FirstName here to match DT & DB

            if (_searchFilter == "None")
            {
                tbSearchPerson.Text = "";
                tbSearchPerson.Visible = false;
                return;
            }

            tbSearchPerson.Visible = true;
            tbSearchPerson.Text = "";

            if (_searchFilter == "PersonID" || _searchFilter == "Phone")
                tbSearchPerson.PlaceholderText = "Only numbers allowed";
            else
                tbSearchPerson.PlaceholderText = "Search..";
        }
        private void tbSearchPerson_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchPerson.Text))
            {
                dt.DefaultView.RowFilter = ""; // when deleting text
                lblNumberOfRecords.Text = dgvPeople.RowCount.ToString();
                return;
            }

            dt.DefaultView.RowFilter = $"Convert({_searchFilter}, 'System.String') LIKE '{tbSearchPerson.Text}%'";
            lblNumberOfRecords.Text = dgvPeople.RowCount.ToString();

            // filtering expression uses DataColumn Expression Language
            // it takes column names from dataTable that took them from Database, not names in dgv
            //since like is for strings only and we might get int column, we cast column type to string using this method from DT special language
        }
        private void tbSearchPerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_searchFilter == "PersonID" || _searchFilter == "Phone")
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back; // if Handled == true then will prevent any action
        }


    
        // using OnUpdate event below is to control WHEN to refresh, instead of refreshing once opened and closed the forms even if no update done
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            if (!clsBusinessSettings.CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eAddPerson))
            {
                MessageBox.Show("Access Denied, contact your admin to get permission.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            delUpdateBreadcrumb(sender, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Add" });

            frmAddEditPerson addPersonForm = new frmAddEditPerson(-1);
            addPersonForm.OnUpdateDoneForDGV += RefreshDataGridView; // to update DGV here if new person added and updated in AddEdit form
            addPersonForm.ShowDialog();

            delUpdateBreadcrumb(sender, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Remove" });         
        }


        // toolstrips menu
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Person Details", operationType = "Add" });

            int PersonID = (int)dgvPeople.SelectedCells[0].Value;
            frmPersonInfo personInfo = new frmPersonInfo(PersonID);
            personInfo.delUpdateBreadcrumb2 += (se, ev) => delUpdateBreadcrumb(se, ev);
            personInfo.PersonCardUpdatedInForm += RefreshDataGridView; // to refresh dgv only if person card that is in person info form gets updated
            personInfo.ShowDialog();

            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Person Details", operationType = "Remove" });
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsBusinessSettings.CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eUpdatePerson))
            {
                MessageBox.Show("Access Denied, contact your admin to get permission.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int PersonID = (int)dgvPeople.SelectedCells[0].Value;
            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Add" });

            frmAddEditPerson EditPersonForm = new frmAddEditPerson(PersonID);
            EditPersonForm.OnUpdateDoneForDGV += RefreshDataGridView;
            EditPersonForm.ShowDialog();

            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Remove" });
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsBusinessSettings.CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eDeletePerson))
            {
                MessageBox.Show("Access Denied, contact your admin to get permission.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int PersonID = (int)dgvPeople.SelectedCells[0].Value;
            try
            {
                if (MessageBox.Show($"Are you sure to delete person wIth ID{PersonID}?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (clsPeopleBusiness.DeletePerson(PersonID))
                    {
                        MessageBox.Show($"Person with ID {PersonID} was successfully deleted.", "Success", MessageBoxButtons.OK);
                        RefreshDataGridView();
                    }
                    else
                        MessageBox.Show($"Person with ID{PersonID} CAN NOT be deleted due to linked data to be deleted first.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
