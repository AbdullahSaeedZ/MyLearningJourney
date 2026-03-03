using BusinessLayer;
using PresentationLayer.MainForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void frmPersonInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctrlPersonInfo1.Dispose();
        }
    }
}
