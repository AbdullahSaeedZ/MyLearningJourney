using BusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace PresentationLayer.Applications.TestAppointments.Forms
{
    public partial class frmListTestAppointments : Form
    {
        private int _LocalApplicationID = -1;
        public clsTestTypesBusiness.enTestType _SelectedTestType; // this will determine which test type for the whole process
        
        private DataTable dt;

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

            RefreshDataGridView();

        }

        private void RefreshDataGridView()
        {
            // method should be in localApplication class ?
            if ((dt = clsTestAppointmentsBusiness.GetAllTestAppointmentsByTestTypeID(_LocalApplicationID, _SelectedTestType)) == null)
                return;

            dgvTestAppointments.DataSource = dt;
            lblNumberOfRecords.Text = dgvTestAppointments.RowCount.ToString();
        }




        // Add/EditAppointment form modes:
        // 1- adding new appointment (2 modes covered in btnAddNewAppointment)
        // 2- editing date of unlocked appointment (covered in edit tool strip)
        // 3- editing a locked appointment, but gets rejected cuz it is locked regardless of result (covered in edit tool strip)

        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            // getting last appointment record of this type to do checks
            clsTestAppointmentsBusiness lastTestAppointment = clsTestAppointmentsBusiness.GetLastTestAppointmentByTestTypeID(_LocalApplicationID, _SelectedTestType);

            if (lastTestAppointment != null)
            {
                // active appointment not locked, test is not yet taken
                if (!lastTestAppointment.IsLocked)
                {
                    MessageBox.Show("This person already has an active appointment for this test, you can not add a new appointment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool WasTestPassed = clsTestsBusiness.IsTestPassedByAppointmentId(lastTestAppointment.TestAppointmentID);
                // if there is old appointment with passed test , reject new appointment
                if (lastTestAppointment.IsLocked && WasTestPassed)
                {
                    MessageBox.Show("This person already passed this test, you can not add a new appointment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // if there is old appointments with failed test , 
                if (lastTestAppointment.IsLocked && !WasTestPassed)
                {
                    // allow for new appointment as retake
                    // need testing after performing take test functionality
                    frmScheduleTestAppointment AddNewRetakeAppointment = new frmScheduleTestAppointment(_SelectedTestType, frmScheduleTestAppointment.enMode.eAddRetakeAppointmentMode);
                    AddNewRetakeAppointment.ReceivedLocalApplication = ctrlLocalApplicationInfo1.SelectedLocalApplication;
                    AddNewRetakeAppointment.delUpdateAppointmentsDGV += RefreshDataGridView;
                    AddNewRetakeAppointment.oldTestTrials = dgvTestAppointments.Rows.Count;
                    AddNewRetakeAppointment.ShowDialog();
                    return;
                }
            }

            // ----------------  done and tested 
            // if there is no old appointments, allow a new appointment with no RT.Application creation , and RT.Application info invisible
            frmScheduleTestAppointment AddNewAppointment = new frmScheduleTestAppointment(_SelectedTestType, frmScheduleTestAppointment.enMode.eAddNewAppointmentMode);
            AddNewAppointment.ReceivedLocalApplication = ctrlLocalApplicationInfo1.SelectedLocalApplication;
            AddNewAppointment.delUpdateAppointmentsDGV += RefreshDataGridView;
            AddNewAppointment.ShowDialog();


        }

        // toolstrip menu options
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dgvTestAppointments.Rows.Count == 0)
                return;
           // removed selected testAppointment from here cuz user might just trigger this event without selecting any options of the menu
        }

        // done and tested when locked and unlocked
        private void editAppointmentDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // (not allowed to edit when locked, only show info) (allowed to edit when unlocked)
            if (dgvTestAppointments.RowCount == 0)
                return; 

            int SelectedAppointmentID = (int)dgvTestAppointments.CurrentRow.Cells[0].Value;

            frmScheduleTestAppointment editScheduledTestAppointment = new frmScheduleTestAppointment(SelectedAppointmentID, _SelectedTestType, frmScheduleTestAppointment.enMode.eUpdateMode);
            editScheduledTestAppointment.ReceivedLocalApplication = ctrlLocalApplicationInfo1.SelectedLocalApplication;
            editScheduledTestAppointment.delUpdateAppointmentsDGV += RefreshDataGridView;
            editScheduledTestAppointment.oldTestTrials = dgvTestAppointments.Rows.Count;
            editScheduledTestAppointment.ShowDialog();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTestAppointments.RowCount == 0)
                return; 

            int SelectedAppointmentID = (int)dgvTestAppointments.CurrentRow.Cells[0].Value;


            // new test record will be created AFTER putting test result then pressing save in the take test form

            // send appointment id to the form to be able to create a test record
            // send localApplicationID to show info in the form also

            // once test is taken , set appointment to locked regardless of result 
            // if this option is called again with appointment locked, show the form but with no action allowed


            //this is a different form for taking tests

            frmTakeTest takeTest = new frmTakeTest();
            takeTest.ShowDialog();


            // update taken tests in application info once test is passed
            // also update dgv of local applications to show passed tests
            
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
