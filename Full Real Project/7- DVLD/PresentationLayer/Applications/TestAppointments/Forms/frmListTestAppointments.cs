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
            if ((dt = clsTestAppointmentsBusiness.GetTestAppointmentsByTestTypeID(37, clsTestTypesBusiness.enTestType.Vision)) == null)
                return;

            dgvTestAppointments.DataSource = dt;
            lblNumberOfRecords.Text = dgvTestAppointments.RowCount.ToString();
        }



        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            // getting last appointment record to do checks
            clsTestAppointmentsBusiness lastTestAppointment = clsTestAppointmentsBusiness.GetLastTestAppointmentByTestTypeID(_LocalApplicationID, clsTestTypesBusiness.enTestType.Vision);

            if (lastTestAppointment != null)
            {
                // active appointment not locked, test is not yet taken
                if (lastTestAppointment != null && !lastTestAppointment.IsLocked)
                {
                    MessageBox.Show("This person already has an active appointment for this test, you can not add a new appointment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // if there is old appointment with passed test , reject new appointment
                if (lastTestAppointment != null && lastTestAppointment.IsLocked && clsTestsBusiness.IsTestPassedByAppointmentId(lastTestAppointment.TestAppointmentID))
                {
                    MessageBox.Show("This person already passed this test, you can not add a new appointment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // if there is no old appointments, or there is old appointments with failed test , allow a new appointment
            // open new appointment form
        }

        private void editAppointmentDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // need to get testAppointment object to get appointmentID
            clsTestAppointmentsBusiness selectedAppointment = clsTestAppointmentsBusiness.FindByTestAppointmentID((int)dgvTestAppointments.CurrentRow.Cells[0].Value);


        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // need to get testAppointment object to get appointmentID
            clsTestAppointmentsBusiness selectedAppointment = clsTestAppointmentsBusiness.FindByTestAppointmentID((int)dgvTestAppointments.CurrentRow.Cells[0].Value);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
