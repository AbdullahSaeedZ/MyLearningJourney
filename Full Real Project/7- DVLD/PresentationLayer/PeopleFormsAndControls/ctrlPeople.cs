using BusinessLayer;
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
                tbSearchPerson.Enabled = false;
                return;
            }

            tbSearchPerson.Enabled = true;
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


        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            delUpdateBreadcrumb(sender, new frmMain.clsBreadcrumbData() { title = "> Person Details", operationType = "Add" });

            frmPersonInfo personInfo = new frmPersonInfo((int)dgvPeople.SelectedCells[0].Value);
            personInfo.delUpdateBreadcrumb2 += (se, ev) => delUpdateBreadcrumb(se, ev);
            personInfo.ShowDialog();

            delUpdateBreadcrumb(sender, new frmMain.clsBreadcrumbData() { title = "> Person Details", operationType = "Remove" });
            RefreshDataGridView();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            delUpdateBreadcrumb(sender, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Add" });
            frmAddEditPerson addPersonForm = new frmAddEditPerson(-1);
            addPersonForm.ShowDialog();
            delUpdateBreadcrumb(sender, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Remove" });
            RefreshDataGridView();
        }


        // toolstrips menu
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.SelectedCells[0].Value;
            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Person Details", operationType = "Add" });
            frmPersonInfo personInfo = new frmPersonInfo(PersonID);
            personInfo.delUpdateBreadcrumb2 += (se, ev) => delUpdateBreadcrumb(se, ev);
            personInfo.ShowDialog();
            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Person Details", operationType = "Remove" });
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.SelectedCells[0].Value;
            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Add" });
            frmAddEditPerson addPersonForm = new frmAddEditPerson(PersonID);
            addPersonForm.ShowDialog();
            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Remove" });
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.SelectedCells[0].Value;
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
