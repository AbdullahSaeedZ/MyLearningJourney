using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Applications.DrivingLicenses.Forms
{
    public partial class frmAddEditLocalLicenseApplication : Form
    {
        public event Action OnUpdateDone;

        private int _applicationID = -1;
        clsUserBusiness _application;

        private enum enMode { eAddNewMode, eUpdateMode };
        private enMode _mode;

        public frmAddEditLocalLicenseApplication()
        {
            InitializeComponent();
            _mode = enMode.eAddNewMode;
        }
        public frmAddEditLocalLicenseApplication(int ApplicationID)
        {
            InitializeComponent();
            _applicationID = ApplicationID;
            _mode = enMode.eUpdateMode;
        }

        private void frmAddEditLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            if (_mode == enMode.eAddNewMode)
                _application = new clsUserBusiness();
            else
            {
                _application = clsUserBusiness.FindUser(_applicationID);
                if (_application == null)
                {
                    MessageBox.Show("Application Does Not Exist, Form will close", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                _FillUserPersonInfoInForm();
            }
        }


        private void _FillUserPersonInfoInForm()
        {
            ctrlPersonCardWithSearch1.LoadInfo(_application.PersonID);
            ctrlPersonCardWithSearch1.FilterVisible = false;
         //   lblTitle.Text = lblTitle.Text = $"Edit Local Driving License Application with ID = {_application.ApplicationID}";
           // lblApplicationID.Text = _application.ApplicationID.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithSearch1.PersonID == -1)
            {
                MessageBox.Show($"Please select a person to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithSearch1.FilterFocus();
                return;
            }

            // prevent if already has not completed application
            //if (clsUserBusiness.DoesUserExist(ctrlPersonCardWithSearch1.PersonID) && _mode == enMode.eAddNewMode) // will proceed if update mode and user exists
            //{
            //    MessageBox.Show($"Selected Person is already a user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

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

            if (_mode == enMode.eAddNewMode)
                _application.PersonID = ctrlPersonCardWithSearch1.PersonID; // will not reach here without a valid personID

       


            try
            {
                if (_application.Save())
                {
                    MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _mode = enMode.eUpdateMode; // to allow next button to proceed when updating a user
                    ctrlPersonCardWithSearch1.FilterVisible = false;
                    lblApplicationID.Text = _application.UserID.ToString();
                  //  lblTitle.Text = lblTitle.Text = $"Edit Local Driving License Application with ID = {_user.UserID}";

                    OnUpdateDone?.Invoke(); // to refresh dgv if user info is updated
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


        // validations
       

        private void ControlBoxClose_Click(object sender, EventArgs e)
        {
            ctrlPersonCardWithSearch1.Dispose();
            this.Close();
        }

    }
}
