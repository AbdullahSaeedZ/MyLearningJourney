using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Applications.TestAppointments.Forms
{
    public partial class frmTakeTest : Form
    {
        public event Action<bool> OnTestPerformed;
        int _testAppointmentID;

        public clsLocalDrivingLicenseApplicationsBusiness ReceivedLocalApplication;
        clsTestAppointmentsBusiness TestAppointment;
        clsTestsBusiness Test;
        private int _oldTestTrials;

        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            _testAppointmentID = TestAppointmentID;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            TestAppointment = clsTestAppointmentsBusiness.FindByTestAppointmentID(_testAppointmentID);

            if (TestAppointment == null)
            {
                MessageBox.Show("Could not fetch Test Appointment data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _oldTestTrials = ReceivedLocalApplication.GetTotalTestTrialsPerTestType(TestAppointment.TestTypeID);

            if (TestAppointment.IsLocked)
            {
                Test = clsTestsBusiness.FindByTestID(TestAppointment.GetTestID());
                _FillOldTestInfo();
            }
            else
                _FillNewTestInfo();
        }

        private void _FillNewTestInfo()
        {
            lblTitle.Text = "Perform " + TestAppointment.TestTypeID.ToString() + " " + lblTitle.Text;
            lblLocalApplicationID.Text = ReceivedLocalApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseDrivingClass.Text = ReceivedLocalApplication.LicenseClassesInfo.ClassName;
            lblApplicantName.Text = ReceivedLocalApplication.ApplicantPersonInfo.FullName;
            lblTestFees.Text = TestAppointment.PaidFees.ToString();  // this is the test fees paid when scheduled appointment
            lblTestAppointmentDate.Text = TestAppointment.AppointmentDate.ToShortDateString();
            lblTestTrials.Text = _oldTestTrials.ToString();

            rbFail.Checked = true;
        }
        private void _FillOldTestInfo()
        {
            lblTitle.Text = "Show " + TestAppointment.TestTypeID.ToString() + " " + lblTitle.Text;
            lblLocalApplicationID.Text = ReceivedLocalApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseDrivingClass.Text = ReceivedLocalApplication.LicenseClassesInfo.ClassName;
            lblApplicantName.Text = ReceivedLocalApplication.ApplicantPersonInfo.FullName;
            lblTestFees.Text = TestAppointment.PaidFees.ToString();  // this is the test fees paid when scheduled appointment
            lblTestAppointmentDate.Text = TestAppointment.AppointmentDate.ToShortDateString();
            lblTestTrials.Text = _oldTestTrials.ToString();

            btnSave.Enabled = false;
            rbFail.Enabled = false;
            rbPass.Enabled = false;
            tbTestNotes.Enabled = false;

            lblDeniedUpdate.Visible = true;
            lblTestID.Text = Test.TestID.ToString();
            tbTestNotes.Text = Test.Notes;

            if (Test.TestResult)
                rbPass.Checked = true;
            else
                rbFail.Checked = true;
        }

        private void _ShowAfterSavingInfo()
        {
            lblTestTrials.Text = (++_oldTestTrials).ToString();
            lblTestID.Text = Test.TestID.ToString();

            lblDeniedUpdate.Visible = true;
            rbFail.Enabled = false;
            rbPass.Enabled = false;
            tbTestNotes.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to proceed with this test result? Test result cannot be changed later and appointment will be locked.", 
                                "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;

            Test = new clsTestsBusiness();
            Test.TestAppointmentID = TestAppointment.TestAppointmentID;
            Test.TestResult = rbPass.Checked ? true : false;
            Test.Notes = tbTestNotes.Text.Trim();
            Test.CreatedByUserID = clsBusinessSettings.CurrentUser.UserID;

            if (Test.Save())
            {
                // appointment is locked automatically once test record is added (see adding query)
                MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ShowAfterSavingInfo();
                OnTestPerformed?.Invoke(Test.TestResult);
            }
            else
                MessageBox.Show("Data was not saved successfully", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
