using BusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace PresentationLayer.Applications.DrivingLicenses.Forms
{
    public partial class frmAddEditLocalLicenseApplication : Form
    {
        public event Action OnUpdateDone;

        private int _localApplicationID = -1;
        clsLocalDrivingLicenseApplicationsBusiness _localApplication;
        clsApplicationTypesBusiness _localLicenseApplicationTypeInfo = clsApplicationTypesBusiness.FindApplicationType(1); 

        private enum enMode { eAddNewMode, eUpdateMode };
        private enMode _mode;

        public frmAddEditLocalLicenseApplication()
        {
            InitializeComponent();
            _mode = enMode.eAddNewMode;
        }
        public frmAddEditLocalLicenseApplication(int LocalApplicationID)
        {
            InitializeComponent();
            _localApplicationID = LocalApplicationID;
            _mode = enMode.eUpdateMode;
        }

        private void frmAddEditLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            _FillLicenseClassesComboBox();

            if (_mode == enMode.eAddNewMode)
            {
                _localApplication = new clsLocalDrivingLicenseApplicationsBusiness();
                _FillApplicationDefaultValues();
            }
            else
            {
               // _localApplication = clsLocalDrivingLicenseApplicationsBusiness.(_localApplicationID);
                if (_localApplication == null)
                {
                    MessageBox.Show("Application Does Not Exist, Form will close", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                _FillExistentApplicationInfoInForm();
            }
        }

        private void _FillLicenseClassesComboBox()
        {
            DataTable dt = clsLicenseClassesBusiness.GetAllLicenseClasses();

            foreach (DataRow row in dt.Rows)
            {
                cbLocalLicenseClasses.Items.Add(row["ClassName"]);
            }
        }
        private void _FillApplicationDefaultValues()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = _localLicenseApplicationTypeInfo.ApplicationTypeFees.ToString();
            lblCreatedByUser.Text = clsBusinessSettings.CurrentUser.Username;
            cbLocalLicenseClasses.SelectedIndex = 2;
        }
        private void _FillExistentApplicationInfoInForm()
        {
            lblTitle.Text =  $"Edit Local Driving License Application with ID = {_localApplication.LocalDrivingLicenseApplicationID}";
            ctrlPersonCardWithSearch1.LoadInfo(_localApplication.ApplicantPersonID);
            ctrlPersonCardWithSearch1.FilterVisible = false;

            lblApplicationID.Text = _localApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = _localApplication.ApplicationDate.ToShortDateString();
            lblApplicationFees.Text = _localApplication.PaidFees.ToString();
            lblCreatedByUser.Text = _localApplication.CreatedByUserInfo.Username.ToString();
            cbLocalLicenseClasses.SelectedItem = _localApplication.LicenseClassesInfo.ClassName;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithSearch1.PersonID == -1)
            {
                MessageBox.Show($"Please select a person to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithSearch1.FilterFocus();
                return;
            }
            _ShowHideApplicationInfoPanel();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _ShowHideApplicationInfoPanel();
        }

        private void _ShowHideApplicationInfoPanel()
        {
            pnlApplicationInfo.Visible = !pnlApplicationInfo.Visible;
            btnBack.Visible = !btnBack.Visible;
            btnSave.Visible = !btnSave.Visible;
            btnNext.Visible = !btnNext.Visible;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // text boxes validations
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Fill necessary fields with valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // prevent here if to be 2 application and both are same class and new status
            // so check if person id has other applications of same class with new status, and show that application id in message box
            // can have multiple applications with new status but of differenet classes

            if (_mode == enMode.eAddNewMode)
            {
                _localApplication.LicenseClassID = (clsLicenseClassesBusiness.Find(cbLocalLicenseClasses.Text)).LicenseClassID; 
                _localApplication.ApplicantPersonID = ctrlPersonCardWithSearch1.PersonID;
                _localApplication.ApplicationStatus = clsApplicationsBusiness.enApplicationStatus.New;
                _localApplication.ApplicationDate = DateTime.Now;
                _localApplication.LastStatusDate = DateTime.Now;
                _localApplication.PaidFees = _localLicenseApplicationTypeInfo.ApplicationTypeFees;
                _localApplication.ApplicationTypeID = _localLicenseApplicationTypeInfo.ApplicationTypeID;
                _localApplication.CreatedByUserID = clsBusinessSettings.CurrentUser.UserID;
            }

            if (_mode == enMode.eUpdateMode)
            {
                _localApplication.LicenseClassID = (clsLicenseClassesBusiness.Find(cbLocalLicenseClasses.Text)).LicenseClassID;
                _localApplication.LastStatusDate = DateTime.Now;
            }

            try
            {
                if (_localApplication.Save())
                {
                    MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _mode = enMode.eUpdateMode; // to allow next button to proceed when updating a user
                    ctrlPersonCardWithSearch1.FilterVisible = false;
                    lblApplicationID.Text = _localApplication.LocalDrivingLicenseApplicationID.ToString();
                    lblTitle.Text = $"Edit Local Driving License Application with ID = {_localApplication.LocalDrivingLicenseApplicationID}";

                    OnUpdateDone?.Invoke(); // to refresh dgv if Application info is updated
                }
                else
                    MessageBox.Show("Data was not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ControlBoxClose_Click(object sender, EventArgs e)
        {
            ctrlPersonCardWithSearch1.Dispose();
            this.Close();
        }
    }
}
