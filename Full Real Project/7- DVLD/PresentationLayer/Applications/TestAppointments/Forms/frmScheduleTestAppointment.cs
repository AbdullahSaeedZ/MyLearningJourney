using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Applications.TestAppointments.Forms
{
    public partial class frmScheduleTestAppointment : Form
    {
        public event Action delUpdateAppointmentsDGV;
        public clsLocalDrivingLicenseApplicationsBusiness ReceivedLocalApplication;

        public enum enMode { eAddNewAppointmentMode = 0, eAddRetakeAppointmentMode = 1, eUpdateMode = 2 };
        enMode _mode;

        clsTestTypesBusiness.enTestType _SelectedTestType; // this will determine which test type for the whole process
        clsTestAppointmentsBusiness TestAppointment;
        clsTestTypesBusiness TestTypeInfo;
        clsApplicationsBusiness RetakeTestApplication;
        clsApplicationTypesBusiness _RetakeTestApplicationTypeInfo;
        int _testAppointmentID;
        int _oldTestTrials = 0;



        public frmScheduleTestAppointment(clsTestTypesBusiness.enTestType SelectedTestType, enMode Mode)
        {
            InitializeComponent();
            _SelectedTestType = SelectedTestType;
            _mode = Mode;
        }

        public frmScheduleTestAppointment(int TestAppointmentID, clsTestTypesBusiness.enTestType SelectedTestType, enMode Mode)
        {
            InitializeComponent();
            _SelectedTestType = SelectedTestType;
            _testAppointmentID = TestAppointmentID;
            _mode = Mode;
        }

        private void frmScheduleTestAppointment_Load(object sender, EventArgs e)
        {
            if (ReceivedLocalApplication == null)
            {
                MessageBox.Show("Could not get Local Application Info of selected Appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            TestTypeInfo = clsTestTypesBusiness.FindTestType(_SelectedTestType); // to get updated data like fees
            
            _oldTestTrials = ReceivedLocalApplication.GetTotalTestTrialsPerTestType(_SelectedTestType);

            switch (_mode)
            {
                case enMode.eAddNewAppointmentMode:

                    _FillInfoFroNewAppointment();
                    TestAppointment = new clsTestAppointmentsBusiness();
                    break;

                case enMode.eAddRetakeAppointmentMode:

                    TestAppointment = new clsTestAppointmentsBusiness();
                    _RetakeTestApplicationTypeInfo = clsApplicationTypesBusiness.FindApplicationType(clsApplicationTypesBusiness.enApplicationTypes.eRetakeTest);
                    _FillInfoForRetakeTestAppointment();
                    break;

                case enMode.eUpdateMode:

                    TestAppointment = clsTestAppointmentsBusiness.FindByTestAppointmentID(_testAppointmentID);
                    if (TestAppointment == null)
                    {
                        MessageBox.Show("Could not get Info of selected Appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (TestAppointment.IsLocked)
                        _FillInfoForDeniedUpdate();
                    else
                        _FillInfoForUpdate();

                    break;
            }
        }


        private void _FillInfoFroNewAppointment()
        {
            lblTitle.Text = "Schedule " + _SelectedTestType.ToString() + " " + lblTitle.Text;
            lblLocalApplicationID.Text = ReceivedLocalApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseDrivingClass.Text = ReceivedLocalApplication.LicenseClassesInfo.ClassName;
            lblApplicantName.Text = ReceivedLocalApplication.ApplicantPersonInfo.FullName;
            lblTestFees.Text = TestTypeInfo.TestTypeFees.ToString();
            dtpAppointmentDate.MinDate = DateTime.Now;
            dtpAppointmentDate.Value = DateTime.Now;
            lblTestTrials.Text = _oldTestTrials.ToString();

            lblTotalFees.Text = TestTypeInfo.TestTypeFees.ToString();
            pnlRetakeAppInfo.Enabled = false;
        }
        private void _FillInfoForRetakeTestAppointment()
        {
            lblTitle.Text = "Schedule Retake " + lblTitle.Text;
            lblLocalApplicationID.Text = ReceivedLocalApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseDrivingClass.Text = ReceivedLocalApplication.LicenseClassesInfo.ClassName;
            lblApplicantName.Text = ReceivedLocalApplication.ApplicantPersonInfo.FullName;
            lblTestFees.Text = TestTypeInfo.TestTypeFees.ToString();
            dtpAppointmentDate.MinDate = DateTime.Now;
            dtpAppointmentDate.Value = DateTime.Now;
            lblTestTrials.Text = _oldTestTrials.ToString();

            pnlRetakeAppInfo.Enabled = true;
            lblRetakeAppFees.Text = _RetakeTestApplicationTypeInfo.ApplicationTypeFees.ToString();
            lblRetakeAppID.Text = "Not Assigned Yet";
            lblTotalFees.Text = (TestTypeInfo.TestTypeFees + _RetakeTestApplicationTypeInfo.ApplicationTypeFees).ToString();
        }
        private void _FillInfoForDeniedUpdate()
        {
            lblTitle.Text = "Update " + _SelectedTestType.ToString() + " " + lblTitle.Text;
            lblLocalApplicationID.Text = ReceivedLocalApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseDrivingClass.Text = ReceivedLocalApplication.LicenseClassesInfo.ClassName;
            lblApplicantName.Text = ReceivedLocalApplication.ApplicantPersonInfo.FullName;
            lblTestFees.Text = TestTypeInfo.TestTypeFees.ToString();
            lblTotalFees.Text = TestTypeInfo.TestTypeFees.ToString();
            lblTestTrials.Text = _oldTestTrials.ToString();

            lblDeniedUpdate.Visible = true;
            dtpAppointmentDate.Value = TestAppointment.AppointmentDate;
            dtpAppointmentDate.Enabled = false;
            btnSave.Enabled = false;
            pnlRetakeAppInfo.Enabled = false;

            // to show retake app info if application is of retake type
            if (TestAppointment.RetakeTestAppInfo != null)
            {
                pnlRetakeAppInfo.Enabled = true;
                lblRetakeAppFees.Text = TestAppointment.RetakeTestAppInfo.PaidFees.ToString();
                lblRetakeAppID.Text = TestAppointment.RetakeTestAppInfo.ApplicationID.ToString();
            }
        }

        private void _FillInfoForUpdate()
        {
            lblTitle.Text = "Update " + _SelectedTestType.ToString() + " " + lblTitle.Text;
            lblLocalApplicationID.Text = ReceivedLocalApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseDrivingClass.Text = ReceivedLocalApplication.LicenseClassesInfo.ClassName;
            lblApplicantName.Text = ReceivedLocalApplication.ApplicantPersonInfo.FullName;
            lblTestFees.Text = TestTypeInfo.TestTypeFees.ToString();
            dtpAppointmentDate.Value = TestAppointment.AppointmentDate;
            dtpAppointmentDate.MinDate = DateTime.Now;
            lblTestTrials.Text = _oldTestTrials.ToString();
            lblTotalFees.Text = TestTypeInfo.TestTypeFees.ToString();

            pnlRetakeAppInfo.Enabled = false;
            if (TestAppointment.RetakeTestAppInfo != null) // the appointment which is shown for update might be from a retake test application type
            {
                pnlRetakeAppInfo.Enabled = true;
                lblRetakeAppFees.Text = TestAppointment.RetakeTestAppInfo.PaidFees.ToString();
                lblRetakeAppID.Text = TestAppointment.RetakeTestAppInfo.ApplicationID.ToString();
                lblTotalFees.Text = (TestTypeInfo.TestTypeFees + TestAppointment.RetakeTestAppInfo.PaidFees).ToString();
            }
        }


        private bool _CreateRetakeTestApplication()
        {
            RetakeTestApplication = new clsApplicationsBusiness();

            RetakeTestApplication.ApplicationTypeID = clsApplicationTypesBusiness.enApplicationTypes.eRetakeTest;
            RetakeTestApplication.ApplicationStatus = clsApplicationsBusiness.enApplicationStatus.New;
            RetakeTestApplication.ApplicantPersonID = ReceivedLocalApplication.ApplicantPersonID;
            RetakeTestApplication.CreatedByUserID = clsBusinessSettings.CurrentUser.UserID;
            RetakeTestApplication.PaidFees = _RetakeTestApplicationTypeInfo.ApplicationTypeFees;
            
            return RetakeTestApplication.Save();
        }

        private void _HandleNewAppointmentInfo()
        {
            TestAppointment.LocalDrivingLicenseApplicationID = ReceivedLocalApplication.LocalDrivingLicenseApplicationID;
            TestAppointment.TestTypeID = _SelectedTestType;
            TestAppointment.AppointmentDate = dtpAppointmentDate.Value;
            TestAppointment.PaidFees = TestTypeInfo.TestTypeFees; // test appointment fees only
            TestAppointment.CreatedByUserID = clsBusinessSettings.CurrentUser.UserID;
            TestAppointment.IsLocked = false;
            TestAppointment.RetakeTestApplicationID = RetakeTestApplication == null ? -1 : RetakeTestApplication.ApplicationID;
        }
     

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_mode == enMode.eAddNewAppointmentMode)
                _HandleNewAppointmentInfo();


            if (_mode == enMode.eAddRetakeAppointmentMode)
            {
                if (_CreateRetakeTestApplication())
                {
                    _HandleNewAppointmentInfo();
                }
                else
                {
                    MessageBox.Show("Error: Could not create a new retake application. Appointment was not created.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }

            if (_mode == enMode.eUpdateMode)
            {
                TestAppointment.AppointmentDate = dtpAppointmentDate.Value;
            }


            if (TestAppointment.Save())
            {
                MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                delUpdateAppointmentsDGV?.Invoke();
                this.Close();
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
