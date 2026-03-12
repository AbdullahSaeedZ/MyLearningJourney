using BusinessLayer;
using PresentationLayer.MainForm;
using PresentationLayer.Properties;
using System;
using System.Windows.Forms;

namespace PresentationLayer.UsersFormsAndControls
{
    public partial class frmAddEditUser : Form
    {
        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumbFromAddEditUserForm;
        clsUserBusiness _user;

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            ctrlPersonCardWithSearch1.delUpdateBreadcrumbFromCardWithFilter += (se, ev) => delUpdateBreadcrumbFromAddEditUserForm(se, ev);

            if (UserID == -1)
            {
                _user = new clsUserBusiness();
            }
            else
            {
                _user = clsUserBusiness.FindUser(UserID);
                if (_user == null)
                {
                    MessageBox.Show("User Does Not Exist, Form will close", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

     

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithSearch1.PersonID == -1)
            {
                MessageBox.Show($"Please select a person to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsUserBusiness.DoesUserExist(ctrlPersonCardWithSearch1.PersonID))
            {
                MessageBox.Show($"Selected Person is already a user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ShowLoginInfoPanel();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _ShowLoginInfoPanel();
        }

        private void _ShowLoginInfoPanel()
        {
            pnlLoginInfo.Visible = !pnlLoginInfo.Visible;
            btnBack.Visible = !btnBack.Visible;
            btnSave.Visible = !btnSave.Visible;
            btnNext.Visible = !btnNext.Visible;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // text boxes validations

            _user.PersonID = ctrlPersonCardWithSearch1.PersonID; // will not reach here without a valid personID
            _user.Username = tbUsername.Text;
            _user.Password = tbPassword.Text;
            _user.isActive = chbIsActive.Checked;

            if (_user.Save())
            {
                MessageBox.Show("Data saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pnlLoginInfo.Enabled = false;
                // disable search filter
                // 
            }
            else
                MessageBox.Show("Data was not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnShowHidePassword2_Click(object sender, EventArgs e)
        {
            if (tbConfirmPassword.UseSystemPasswordChar)
            {
                tbConfirmPassword.UseSystemPasswordChar = false;
                btnShowHidePassword2.Image = Resources.hidePasswordEye;
            }
            else
            {
                tbConfirmPassword.UseSystemPasswordChar = true;
                btnShowHidePassword2.Image = Resources.showPasswordEye;
            }    
        }

        private void btnShowHidePassword1_Click(object sender, EventArgs e)
        {
            if (tbPassword.UseSystemPasswordChar)
            {
                tbPassword.UseSystemPasswordChar = false;
                btnShowHidePassword1.Image = Resources.hidePasswordEye;
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
                btnShowHidePassword1.Image = Resources.showPasswordEye;
            }
        }

        private void ControlBoxClose_Click(object sender, EventArgs e)
        {
            ctrlPersonCardWithSearch1.Dispose();
            this.Close();
        }
    }
}
