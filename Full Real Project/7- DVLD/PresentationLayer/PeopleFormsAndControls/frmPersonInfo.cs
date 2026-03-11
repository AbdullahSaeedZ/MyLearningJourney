using BusinessLayer;
using PresentationLayer.MainForm;
using System;
using System.Windows.Forms;

namespace PresentationLayer.PeopleFormsAndControls
{
    public partial class frmPersonInfo : Form
    {
        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumb2;
        public event Action PersonCardUpdatedInForm; // took refreshDGV method reference, to be invoked when personCard is updated
        public frmPersonInfo(int personID)
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            
            ctrlPersonCard1.delUpdateBreadcrumbFromPersonCard += (se, ev) => delUpdateBreadcrumb2(se, ev); // linking to frmMain breadcrumb method
            ctrlPersonCard1.LoadInfo(personID);
        }
        public frmPersonInfo(string NationalNo)
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            
            ctrlPersonCard1.delUpdateBreadcrumbFromPersonCard += (se, ev) => delUpdateBreadcrumb2(se, ev); // linking to frmMain breadcrumb method
            ctrlPersonCard1.LoadInfo(NationalNo);
        }



        private void frmPersonInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctrlPersonCard1.Dispose(); // to remove bitmap object from ram when closing
        }

        private void ctrlPersonCard1_PersonCardUpdated() // custom event made inside personCard
        {
            PersonCardUpdatedInForm?.Invoke();
        }
    }
}
