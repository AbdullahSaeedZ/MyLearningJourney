using System;
using System.Data;
using System.Windows.Forms;
using PresentationLayer.MainForm;
using BusinessLayer;


namespace PresentationLayer.PeopleFormsAndControls
{
    public partial class ctrlPeople : UserControl
    {
        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumb;
        public ctrlPeople()
        {
            InitializeComponent();
           // RefreshDataGridView();
        }


        //private void RefreshDataGridView()
        //{
        //    DataTable dt = clsPeopleBusiness.GetAllPeople();
        //    dgvPeople.DataSource = dt;
        //    dgvPeople.Show();
        //}

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            delUpdateBreadcrumb(this,new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Add"});
            frmAddEditPerson addPersonForm = new frmAddEditPerson();
            addPersonForm.ShowDialog();
            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Remove" });
        }
    }
}
