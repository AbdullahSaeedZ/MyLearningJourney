using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Applications.TestAppointments.Forms
{
    public partial class frmListTestAppointments : Form
    {
        private int _LocalApplicationID = -1;
        public clsTestTypesBusiness.enTestType _SelectedTestType; 
        public frmListTestAppointments(int LocalApplicationID, clsTestTypesBusiness.enTestType SelectedTestType)
        {
            InitializeComponent();
            _LocalApplicationID = LocalApplicationID;
            _SelectedTestType = SelectedTestType;
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            if (_LocalApplicationID == -1)
            {
                MessageBox.Show("Could not get Local Driving License Application ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            ctrlLocalApplicationInfo1.LoadInfo(_LocalApplicationID);
            lblTitle.Text = _SelectedTestType.ToString() + " " + lblTitle.Text;

        }
    }
}
