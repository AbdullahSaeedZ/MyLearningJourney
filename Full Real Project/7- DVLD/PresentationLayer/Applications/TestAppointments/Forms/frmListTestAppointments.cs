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
        clsTestAppointmentsBusiness _SelectedAppointment;
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
                    // open new Add/EditAppointment
                    //allow a new appointment with mode: new application of retake test type and show the retake application info: RT.App ID , RT.App fees , then total fees as vision test fees + RT.App fees
                }
            }

            // if there is no old appointments, allow a new appointment with no RT.Application creation , and RT.Application info invisible
            // open new Add/EditAppointment form for new appointment


        }

        // toolstrip menu options
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _SelectedAppointment = clsTestAppointmentsBusiness.FindByTestAppointmentID((int)dgvTestAppointments.CurrentRow.Cells[0].Value);
            if (_SelectedAppointment == null)
            {
                MessageBox.Show("Could not get selected Test Appointment ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // this will make the menu close
            }
        }

        private void editAppointmentDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            // open new Add/EditAppointment form for editing appointment date only (no backward date allowed) (allowed to edit when unlocked)
            // Add/EditAppointment in edit mode

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // new test record will be created AFTER putting test result then pressing save in the take test form

            // send appointment id to the form to be able to create a test record
            // send localApplicationID to show info in the form also

            // once test is taken , set appointment to locked regardless of result 
            // if this option is called again with appointment locked, show the form but with no action allowed


            //this is a different form for taking tests
            
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
