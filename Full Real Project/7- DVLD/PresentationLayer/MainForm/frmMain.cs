using BusinessLayer;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using PresentationLayer.DashboardControls;
using PresentationLayer.LoginForm;
using PresentationLayer.PeopleFormsAndControls;
using PresentationLayer.Properties;
using PresentationLayer.Settings;
using PresentationLayer.Users.Controls;
using PresentationLayer.UsersFormsAndControls;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PresentationLayer.MainForm
{
    public partial class frmMain : Form
    {

        public class clsBreadcrumbData : EventArgs
        {
            public string title { get; set; }
            public string operationType { get; set; }
        }

        public frmMain()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);

            // to start app with overview
            btnOverview_Click(btnOverview, EventArgs.Empty);
            _LoadProfileInfo();
        }

        private void _LoadProfileInfo()
        {
            if (clsBusinessSettings.CurrentUser == null)
            {
                MessageBox.Show($"Could not find user account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (string.IsNullOrEmpty(clsBusinessSettings.CurrentUser.Person.ImagePath))
                pbProfilePic.Image = clsBusinessSettings.CurrentUser.Person.Gender == 0 ? Resources.defaultMaleProfile : Resources.defaultFemaleProfile;
            else
                using (FileStream fs = new FileStream(clsBusinessSettings.CurrentUser.Person.ImagePath, FileMode.Open, FileAccess.Read))
                {
                    pbProfilePic.Image = new Bitmap(fs);
                }

            lblProfilePersonName.Text = clsBusinessSettings.CurrentUser.Person.FirstName + " " + clsBusinessSettings.CurrentUser.Person.LastName;
            lblProfileUsername.Text = clsBusinessSettings.CurrentUser.Username;
        }
        public void _UpdateButtons(object sender)
        {
            Guna2Button selectedButten = (Guna2Button)sender;
            // to reset unchosen buttons color and icon
            btnOverview.FillColor = Color.Transparent;
            btnOverview.ForeColor = Color.DimGray;
            btnOverview.Image = Resources.overviewNoFillThin;

            btnApplications.FillColor = Color.Transparent;
            btnApplications.ForeColor = Color.DimGray;
            btnApplications.Image = Resources.applicationNoFillThin;

            btnPeople.FillColor = Color.Transparent;
            btnPeople.ForeColor = Color.DimGray;
            btnPeople.Image = Resources.peopleNoFillThin;

            btnDrivers.FillColor = Color.Transparent;
            btnDrivers.ForeColor = Color.DimGray;
            btnDrivers.Image = Resources.driversNoFillThin;

            btnUsers.FillColor = Color.Transparent;
            btnUsers.ForeColor = Color.DimGray;
            btnUsers.Image = Resources.usersNoFill;

            btnSettings.FillColor = Color.Transparent;
            btnSettings.ForeColor = Color.DimGray;
            btnSettings.Image = Resources.settingNoFill;

            // to highlight selected color
            selectedButten.FillColor = Color.White;
            selectedButten.Image = selectedButten.HoverState.Image;
            selectedButten.ForeColor = Color.Black;

            lblBreadcrumb.Text = selectedButten.Tag.ToString();
            pbBreadcrumb.Image = selectedButten.HoverState.Image;
        }
        private void _RefreshControlsContainer()
        {
            if (pnlControlsContainer.Controls.Count > 0)
                pnlControlsContainer.Controls.Clear();
        }
        private void UpdateBreadcrumb(object sender, clsBreadcrumbData Data)
        {
            if (Data.operationType == "Add")
                lblBreadcrumb.Text += $" {Data.title}";
            else
                lblBreadcrumb.Text = lblBreadcrumb.Text.Remove(lblBreadcrumb.Text.IndexOf(Data.title));
        }

        // menu buttons
        private void btnOverview_Click(object sender, EventArgs e)
        {
            _RefreshControlsContainer();
            ctrlDashboard dashboard = new ctrlDashboard();
            pnlControlsContainer.Controls.Add(dashboard);
            _UpdateButtons(sender);
        }
        private void btnApplications_Click(object sender, EventArgs e)
        {
            _RefreshControlsContainer();
          
            _UpdateButtons(sender);
        }
        private void btnPeople_Click(object sender, EventArgs e)
        {
            if (!clsBusinessSettings.CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eListPeople))
            {
                MessageBox.Show("Access Denied, contact your admin to get permission.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _RefreshControlsContainer();
            ctrlPeople People = new ctrlPeople();
            pnlControlsContainer.Controls.Add(People);
            People.delUpdateBreadcrumb += UpdateBreadcrumb;
            _UpdateButtons(sender);

        }
        private void btnDrivers_Click(object sender, EventArgs e)
        {
            _RefreshControlsContainer();

            _UpdateButtons(sender);
        }
        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (!clsBusinessSettings.CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eListUsers))
            {
                MessageBox.Show("Access Denied, contact your admin to get permission.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _RefreshControlsContainer();
            ctrlUsers Users = new ctrlUsers();
            pnlControlsContainer.Controls.Add(Users);
            Users.delUpdateBreadcrumbFromUserControl += UpdateBreadcrumb;
            _UpdateButtons(sender);
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            _RefreshControlsContainer();
            ctrlSettings settings = new ctrlSettings();
            pnlControlsContainer.Controls.Add(settings);
            _UpdateButtons(sender);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin login = new frmLogin();
            login.Show();
        }


        // PersonID Quick Search
        private void lblQuickSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbQuickSearch.Text , out int ID))
            {
                if (clsPeopleBusiness.DoesPersonExist(ID))
                {
                    frmPersonInfo Info = new frmPersonInfo(ID);
                    Info.ShowDialog();
                }
                else
                    MessageBox.Show($"Person With ID {ID} Does Not Exist", "Error", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Only Numbers Allowed", "Error", MessageBoxButtons.OK);
        }
        private void tbQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                lblQuickSearch_Click(sender, EventArgs.Empty);
        }
       

        // Closing the app
        private void ControlBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
    }
}
