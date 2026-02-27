using System;
using System.Data;
using System.Windows.Forms;
using PresentationLayer.MainForm;
using BusinessLayer;
using System.IO;


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
            delUpdateBreadcrumb(this,new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Add"});

            frmAddEditPerson addPersonForm = new frmAddEditPerson();
            addPersonForm.ShowDialog();

            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Remove" });

        }
    }
}
