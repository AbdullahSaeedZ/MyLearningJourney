using System;
using PresentationLayer.MainForm;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer.LoginForm
{
    public partial class frmLogin : Form
    {
        clsUserBusiness _User;
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
            _User = clsUserBusiness.FindUser(tbUsername.Text, tbPassword.Text);

            if (_User == null)
            {
                MessageBox.Show("Invalid Username/Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_User.isActive)
            {
                MessageBox.Show("Your account is not active, please contact your admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            clsBusinessSettings.SaveLoginInfoToFile(tbUsername.Text, tbPassword.Text, chbRememberMe.Checked);
            frmMain main = new frmMain();
            main.Show();
            this.Hide();

            
        }

        private void lblPasswordEye_Click(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !tbPassword.UseSystemPasswordChar;
        }
    } 
}
