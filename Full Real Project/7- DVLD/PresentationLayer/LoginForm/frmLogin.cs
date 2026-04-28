using BusinessLayer;
using PresentationLayer.Global_Classes;
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
        public frmLogin()
        {
            InitializeComponent();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
           _LoadCredentials();
        }
      
 
        private void _LoadCredentials()
        {
            if (clsBusinessSettings.LoadLoginInfoFromFile(ref _Username, ref _Password))
            {
                tbUsername.Text = _Username;
                tbPassword.Text = _Password;
                chbRememberMe.Checked = true;
            }
            else
            {
                tbUsername.Text = "";
                tbPassword.Text = "";
                chbRememberMe.Checked = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = clsUserBusiness.FindUser(tbUsername.Text.Trim(), tbPassword.Text.Trim());

            if (clsGlobal.CurrentUser == null)
            {
                MessageBox.Show("Invalid Username/Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUsername.Focus();
                return;
            }

            if (clsGlobal.CurrentUser.Person == null)
            {
                MessageBox.Show("could not fetch person Info for this user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUsername.Focus();
                return;
            }

            if (chbRememberMe.Checked)
                clsBusinessSettings.SaveLoginInfoToFile(tbUsername.Text.Trim(), tbPassword.Text.Trim());
            else
                clsBusinessSettings.SaveLoginInfoToFile("", "");

            if (!clsGlobal.CurrentUser.isActive)
            {
                MessageBox.Show("Your account is not active, please contact your admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmMain main = new frmMain();
            this.Hide();
            main.ShowDialog(); // dialog to wait for main form to close then continue to next line
            this.Show(); // once logged out from Main form, this will unhide instead of new object created in memory
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

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            tbUsername.Text = "";
            tbPassword.Text = "";

            if (!chbRememberMe.Checked)
                return;

            _LoadCredentials();
        }
    } 
}
