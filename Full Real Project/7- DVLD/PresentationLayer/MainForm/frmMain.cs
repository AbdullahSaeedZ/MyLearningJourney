using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PresentationLayer.DashboardControls;
using PresentationLayer.PeopleFormsAndControls;

namespace PresentationLayer.MainForm
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            // to start app with overview
            MainOptionsButtonHandler_Click(btnOverview, EventArgs.Empty);
        }

        private void _RefreshControlsContainer()
        {
            if (pnlControlsContainer.Controls.Count > 0)
                pnlControlsContainer.Controls.Clear();
        }

        private void MainOptionsButtonHandler_Click(object sender, EventArgs e)
        {
            _RefreshControlsContainer();
            Guna2Button selectedButten = (Guna2Button)sender;
            
            switch (selectedButten.Tag.ToString())
            {
                case "Overview":
                    ctrlDashboard dashboard = new ctrlDashboard();
                    pnlControlsContainer.Controls.Add(dashboard);
                    break;

                case "Applications":

                    break;

                case "People":
                    ctrlPeople People = new ctrlPeople();
                    pnlControlsContainer.Controls.Add(People);
                    break;

                case "Drivers":

                    break;

                case "Users":

                    break;

                case "Settings":

                    break;

                default:
                    ctrlDashboard ct = new ctrlDashboard();
                    pnlControlsContainer.Controls.Add(ct);
                    break;
            }

            UpdateButtons(selectedButten);
        }

        private void UpdateButtons(Guna2Button selectedButten)
        {
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
            selectedButten.FillColor = Color.WhiteSmoke;
            selectedButten.Image = selectedButten.HoverState.Image;
            selectedButten.ForeColor = Color.Black;

            lblBreadcrumb.Text = selectedButten.Tag.ToString();
            pbBreadcrumb.Image = selectedButten.HoverState.Image;
        }

        // PersonID Quick Search
        private void lblQuickSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbQuickSearch.Text , out int ID))
            {
                _FindPerson(ID);
            }
            else
            {
                MessageBox.Show("No Valid Value Entered", "Error", MessageBoxButtons.OK);
            }
            
        }
        private void tbQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                lblQuickSearch_Click(sender, EventArgs.Empty);
            }
        }
        private void _FindPerson(int ID)
        {
            MessageBox.Show("find person");
        }

        // Closing the app
        private void ControlBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
