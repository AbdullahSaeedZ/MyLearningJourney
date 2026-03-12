using PresentationLayer.MainForm;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Users.Forms
{
    public partial class frmUserInfo : Form
    {
        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumbFromUserInfoForm;
        public frmUserInfo(int UserID)
        {
            InitializeComponent();
            ctrlUserCard1.LoadInfo(UserID);
            ctrlUserCard1.delUpdateBreadcrumbFromUserCard += (se, ev) => delUpdateBreadcrumbFromUserInfoForm(se, ev);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
