using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Applications.TestAppointments.Forms
{
    public partial class frmScheduleTestAppointment : Form
    {
        public event Action delUpdateAppointmentsDGV;
    
        private clsTestTypesBusiness.enTestType _SelectedTestType; // this will determine which test type for the whole process
        private int _testAppointmentID = -1;
        private int _LocalApplicationID = -1;

        public frmScheduleTestAppointment(int LocalApplicationID, clsTestTypesBusiness.enTestType SelectedTestType, int TestAppointmentID = 1)
        {
            InitializeComponent();
            _SelectedTestType = SelectedTestType;
            _testAppointmentID = TestAppointmentID;
            _LocalApplicationID = LocalApplicationID;
        }

        private void frmScheduleTestAppointment_Load(object sender, EventArgs e)
        {

            // control loadinfo()
        }

       
    }
}
