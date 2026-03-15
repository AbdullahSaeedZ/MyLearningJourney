using BusinessLayer;
using PresentationLayer.MainForm;
using PresentationLayer.Properties;
using System;
using System.Windows.Forms;

namespace PresentationLayer.LoginForm
{
    public partial class frmLogin : Form
    {
        
        private string _Username;
        private string _Password;
        private bool _wasRememberMeChecked = false;
        public frmLogin()
        {
            InitializeComponent();

            clsBusinessSettings.LoadLoginInfoFromFile(ref _Username, ref _Password, ref _wasRememberMeChecked);
            if (_wasRememberMeChecked)
            {
                tbUsername.Text = _Username;
                tbPassword.Text = _Password;
                chbRememberMe.Checked = _wasRememberMeChecked;
            }
        }

         // encryption

        private void _ShowWelcome()
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsBusinessSettings.CurrentUser = clsUserBusiness.FindUser(tbUsername.Text, tbPassword.Text);

            if (clsBusinessSettings.CurrentUser == null)
            {
                MessageBox.Show("Invalid Username/Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!clsBusinessSettings.CurrentUser.isActive)
            {
                MessageBox.Show("Your account is not active, please contact your admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            clsBusinessSettings.SaveLoginInfoToFile(tbUsername.Text, tbPassword.Text, chbRememberMe.Checked);
            frmMain main = new frmMain();
            main.Show();
            this.Hide();
        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !tbPassword.UseSystemPasswordChar;
            

            if (!tbPassword.UseSystemPasswordChar)
            {
                btnShowHidePassword1.Image = Resources.hidePasswordEye;
            }
            else
            {
                btnShowHidePassword1.Image = Resources.showPasswordEye;
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    } 
}
