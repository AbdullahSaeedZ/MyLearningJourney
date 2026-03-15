using BusinessLayer;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using PresentationLayer.DashboardControls;
using PresentationLayer.PeopleFormsAndControls;
using PresentationLayer.Properties;
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
            foreach (Guna2Button btn in pnlSideBar.Controls.OfType<Guna.UI2.WinForms.Guna2Button>())
            {
                string icon = btn.Tag.ToString();
                btn.FillColor = Color.Transparent;
                btn.ForeColor = Color.DimGray;
                btn.Image =
                    icon == "Overview" ? Properties.Resources.overviewNoFillThin :
                    icon == "Applications" ? Properties.Resources.applicationNoFillThin :
                    icon == "People" ? Properties.Resources.peopleNoFillThin :
                    icon == "Drivers" ? Properties.Resources.driversNoFillThin :
                    icon == "Users" ? Properties.Resources.usersNoFill :
                    icon == "Settings" ? Properties.Resources.settingNoFill : Properties.Resources.overviewNoFillThin;

            }

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
            ctrlAddEditUserPermissions n = new ctrlAddEditUserPermissions();
            pnlControlsContainer.Controls.Add(n);
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

            _UpdateButtons(sender);
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
