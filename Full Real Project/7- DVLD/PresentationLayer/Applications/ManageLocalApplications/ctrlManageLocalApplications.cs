using BusinessLayer;
using PresentationLayer.Applications.DrivingLicenses.Forms;
using PresentationLayer.Global_Classes;
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
            if ((dt = clsLocalDrivingLicenseApplicationsBusiness.GetAllApplications()) == null)
                return;

            dgvApplications.DataSource = dt;
            lblNumberOfRecords.Text = dgvApplications.RowCount.ToString();
        }


        // search Applications by..
        // controlling textBox based on comboBox option
        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _searchFilter = cbSearchBy.Text.Replace(" ", ""); // matching database names, not dgv. First Name in dgv, to be FirstName here to match DT & DB

            if (_searchFilter == "None")
            {
                tbSearchApplication.Text = "";
                tbSearchApplication.Visible = false;
                lblNumberOfRecords.Text = dgvApplications.RowCount.ToString(); // to update number when switching to none after being filtered
                return;
            }

            tbSearchApplication.Visible = true;
            tbSearchApplication.Text = "";

            if (_searchFilter == "PersonID" || _searchFilter == "Phone")
                tbSearchApplication.PlaceholderText = "Only numbers allowed";
            else
                tbSearchApplication.PlaceholderText = "Search..";

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
            // it takes column names from dataTable that took them from Database, not names in dgv
            //since like is for strings only and we might get int column, we cast column type to string using this method from DT special language
        }
        private void tbSearchApplication_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_searchFilter == "PersonID" || _searchFilter == "Phone")
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
            frmAddEditLocalLicenseApplication addApplicationForm = new frmAddEditLocalLicenseApplication(-1);
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
    }
}
