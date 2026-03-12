using BusinessLayer;
using Guna.UI2.HtmlRenderer.Adapters;
using Guna.UI2.WinForms;
using PresentationLayer.MainForm;
using PresentationLayer.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using static PresentationLayer.PeopleFormsAndControls.frmAddEditPerson;

namespace PresentationLayer.UsersFormsAndControls
{
    public partial class frmAddEditUser : Form
    {
        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumbFromAddEditUserForm;
        clsUserBusiness _user;

        private enum enMode { eAddNewMode, eUpdateMode };
        private enMode _mode;

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            ctrlPersonCardWithSearch1.delUpdateBreadcrumbFromCardWithFilter += (se, ev) => delUpdateBreadcrumbFromAddEditUserForm(se, ev);

            if (UserID == -1)
            {
                _user = new clsUserBusiness();
                _mode = enMode.eAddNewMode;
            }
            else
            {
                _user = clsUserBusiness.FindUser(UserID);
                if (_user == null)
                {
                    MessageBox.Show("User Does Not Exist, Form will close", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                _FillPersonInfoInForm();
                _mode = enMode.eUpdateMode;
            }
        }

        private void _FillPersonInfoInForm()
        {

            ctrlPersonCardWithSearch1.LoadInfo(_user.PersonID);
            ctrlPersonCardWithSearch1.FilterVisible = false;
            lblTitle.Text = lblTitle.Text = $"Edit User with ID = {_user.UserID}";
            lblUserID.Text = _user.PersonID.ToString();

            tbUsername.Text = _user.Username;
            tbPassword.Text = _user.Password;
            tbConfirmPassword.Text = tbPassword.Text;
            chbIsActive.Checked = _user.isActive;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithSearch1.PersonID == -1)
            {
                MessageBox.Show($"Please select a person to proceed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsUserBusiness.DoesUserExist(ctrlPersonCardWithSearch1.PersonID) && _mode == enMode.eAddNewMode)
            {
                MessageBox.Show($"Selected Person is already a user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ShowHideLoginInfoPanel();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _ShowHideLoginInfoPanel();
        }

        private void _ShowHideLoginInfoPanel()
        {
            pnlLoginInfo.Visible = !pnlLoginInfo.Visible;
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
            {
                _user.PersonID = ctrlPersonCardWithSearch1.PersonID; // will not reach here without a valid personID
                _user.Username = tbUsername.Text.Trim();
                _user.Password = tbPassword.Text.Trim();
                _user.isActive = chbIsActive.Checked;
            }
            else
            {
                // check password editing..
                _user.Username = tbUsername.Text.Trim();
                _user.isActive = chbIsActive.Checked;
            }

            if (_user.Save())
            {
                MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlPersonCardWithSearch1.FilterVisible = false;
                lblUserID.Text = _user.UserID.ToString();
                lblTitle.Text = $"Edit User with ID = {_user.UserID}";
                _mode = enMode.eUpdateMode; // to allow next button to proceed when updating a user
            }
            else
                MessageBox.Show("Data was not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        // login info validations
        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            // emptiness validation
            if (string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbUsername, "Field is required!");
                tbUsername.BorderColor = Color.Red;
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbUsername, null);
                tbUsername.BorderColor = Color.Silver;
            }

            // does username exist validation
            if (clsUserBusiness.DoesUsernameExist(tbUsername.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbUsername, "Username already exists!");
                tbUsername.BorderColor = Color.Red;
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbUsername, null);
                tbUsername.BorderColor = Color.Silver;
            }

        }
        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            // emptiness validation
            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPassword, "Field is required!");
                tbPassword.BorderColor = Color.Red;
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPassword, null);
                tbPassword.BorderColor = Color.Silver;
            }

            // password format validation


        }
        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            // emptiness validation
            if (string.IsNullOrWhiteSpace(tbConfirmPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbConfirmPassword, "Field is required!");
                tbConfirmPassword.BorderColor = Color.Red;
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbConfirmPassword, null);
                tbConfirmPassword.BorderColor = Color.Silver;
            }

            // password matching validation
            if (tbConfirmPassword.Text != tbPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbConfirmPassword, "Password does not match!");
                tbConfirmPassword.BorderColor = Color.Red;
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbConfirmPassword, null);
                tbConfirmPassword.BorderColor = Color.Silver;
            }
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
