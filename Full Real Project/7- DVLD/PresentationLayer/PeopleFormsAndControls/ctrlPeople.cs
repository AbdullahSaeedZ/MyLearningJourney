using BusinessLayer;
using Guna.UI2.WinForms;
using PresentationLayer.DashboardControls;
using PresentationLayer.MainForm;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace PresentationLayer.PeopleFormsAndControls
{
    public partial class ctrlPeople : UserControl
    {
        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumb;
        private enum enGender { Male = 0, Female = 1 };
        public ctrlPeople()
        {
            InitializeComponent();
            RefreshDataGridView();
        }


        private void RefreshDataGridView()
        {
            DataTable dt = clsPeopleBusiness.GetAllPeople();
            dt.Columns.Add("Pic", typeof(byte[]));
            dt.Columns.Add("GenderString", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                // replace imagePath column with new column contain pic as bits
                row["Pic"] = File.ReadAllBytes(row["ImagePath"].ToString());

                string genderType = (byte)row["Gender"] == 0 ? "Male" : "Female";
                row["GenderString"] = genderType;
            }

            dgvPeople.DataSource = dt;
            dgvPeople.Columns["ImagePath"].Visible = false; //hide unneeded columns
            dgvPeople.Columns["Gender"].Visible = false;
            lblNumberOfRecords.Text = dgvPeople.RowCount.ToString();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            delUpdateBreadcrumb(sender,new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Add"});
            frmAddEditPerson addPersonForm = new frmAddEditPerson(-1);
            addPersonForm.ShowDialog();
            delUpdateBreadcrumb(sender, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Remove" });
        }

        private void _EditPerson()
        {
            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Add" });
            frmAddEditPerson addPersonForm = new frmAddEditPerson((int)dgvPeople.SelectedCells[0].Value);
            addPersonForm.ShowDialog();
            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Remove" });
        }

        private void AllToolStripMenuHandler_Click(object sender, EventArgs e)
        {
            ToolStripItem toolStripItem = (ToolStripItem)sender;

            switch (toolStripItem.Text)
            {
                case "Show Details":
                    frmPersonInfo personInfo = new frmPersonInfo((int)dgvPeople.SelectedCells[0].Value);
                    personInfo.ShowDialog();
                    break;

                case "Add New Person":
                    btnAddPerson_Click(sender, EventArgs.Empty);
                    break;

                case "Edit":
                    _EditPerson();
                    break;

                case "Delete":

                    break;
                default:
                    frmPersonInfo d = new frmPersonInfo(Convert.ToInt32(dgvPeople.SelectedCells[0].Value));
                    d.ShowDialog();
                    break;
            }
        }

        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            frmPersonInfo personInfo = new frmPersonInfo(Convert.ToInt32(dgvPeople.SelectedCells[0].Value));
            personInfo.ShowDialog();
        }



        // search people by..
        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbSearchBy.SelectedIndex)
            {
                case 0:
                    tbSearchPerson.Text = "";
                    tbSearchPerson.Enabled = false;
                    break;

                case 1:
                    tbSearchPerson.Text = "";
                    tbSearchPerson.Enabled = true;
                    break;

                case 2:

                    break;

                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:

                    break;
                case 8:

                    break;
                case 9:

                    break;
                case 10:

                    break;
                default:
                    tbSearchPerson.Text = "";
                    tbSearchPerson.Enabled = false;
                    break;
            }
        }

        private void tbSearchPerson_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
