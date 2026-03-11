using PresentationLayer.MainForm;
using System;
using System.Windows.Forms;

namespace PresentationLayer.UsersFormsAndControls
{
    public partial class frmAddEditUser : Form
    {
        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumbFromAddEditUserForm;

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            ctrlPersonCardWithSearch1.delUpdateBreadcrumbFromCardWithFilter += (se, ev) => delUpdateBreadcrumbFromAddEditUserForm(se, ev);
        }



        private void ControlBoxClose_Click(object sender, EventArgs e)
        {
            ctrlPersonCardWithSearch1.Dispose();
            this.Close();
        }
    }
}
