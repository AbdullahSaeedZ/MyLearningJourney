using PresentationLayer.MainForm;
using PresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Users.Forms
{
    public partial class frmChangePassword : Form
    {
        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumbFromChangePasswordForm;

        
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            ctrlUserCard1.delUpdateBreadcrumbFromUserCard += (se, ev) => delUpdateBreadcrumbFromChangePasswordForm(se, ev);
            ctrlUserCard1.LoadInfo(UserID);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Fill necessary fields with valid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlUserCard1.SelectedUser.Password = tbNewPassword.Text;

            if (ctrlUserCard1.SelectedUser.Save())
                MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Data was not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void tbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            // emptiness validation
            if (string.IsNullOrWhiteSpace(tbCurrentPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbCurrentPassword, "Field is required!");
                tbCurrentPassword.BorderColor = Color.Red;
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbCurrentPassword, null);
                tbCurrentPassword.BorderColor = Color.Silver;
            }

            // current password correct ?
            if (ctrlUserCard1.SelectedUser.Password != tbCurrentPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbCurrentPassword, "Password is not correct!");
                tbCurrentPassword.BorderColor = Color.Red;
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbCurrentPassword, null);
                tbCurrentPassword.BorderColor = Color.Silver;
            }
        }

        private void tbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            // emptiness validation
            if (string.IsNullOrWhiteSpace(tbNewPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNewPassword, "Field is required!");
                tbNewPassword.BorderColor = Color.Red;
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbNewPassword, null);
                tbNewPassword.BorderColor = Color.Silver;
            }

            // pattern validation
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

            // is matching new password?
            if (tbConfirmPassword.Text != tbNewPassword.Text)
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
        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            tbNewPassword.UseSystemPasswordChar = !tbNewPassword.UseSystemPasswordChar;
            tbConfirmPassword.UseSystemPasswordChar = !tbConfirmPassword.UseSystemPasswordChar;

            if (tbNewPassword.UseSystemPasswordChar)
            {
                btnShowHidePassword1.Image = Resources.hidePasswordEye;
                btnShowHidePassword2.Image = Resources.hidePasswordEye;
            }
            else
            {
                btnShowHidePassword1.Image = Resources.showPasswordEye;
                btnShowHidePassword2.Image = Resources.showPasswordEye;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
