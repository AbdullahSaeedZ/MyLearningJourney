using BusinessLayer;
using PresentationLayer.MainForm;
using System;
using System.Windows.Forms;

namespace PresentationLayer.PeopleFormsAndControls
{
    public partial class frmPersonInfo : Form
    {
        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumb2;
        frmMain.clsBreadcrumbData n = new frmMain.clsBreadcrumbData();
        public frmPersonInfo(int personID)
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            
            ctrlPersonInfo1.delUpdateBreadcrumb3 += (se, ev) => delUpdateBreadcrumb2(se, ev); // linking to frmMain breadcrumb method
            ctrlPersonInfo1.LoadInfo(personID);
        }
        public frmPersonInfo(string NationalNo)
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            
            ctrlPersonInfo1.delUpdateBreadcrumb3 += (se, ev) => delUpdateBreadcrumb2(se, ev); // linking to frmMain breadcrumb method
            ctrlPersonInfo1.LoadInfo(NationalNo);
        }

        private void frmPersonInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctrlPersonInfo1.Dispose(); // to remove bitmap object from ram when closing
        }
    }
}
