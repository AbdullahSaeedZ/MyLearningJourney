using BusinessLayer;
using PresentationLayer.MainForm;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.PeopleFormsAndControls
{
    public partial class ctrlPersonCardWithSearch : UserControl
    {
        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumbFromCardWithFilter;

        public int FilterBorderThickness
        {
            set
            {
                pnlFilter.BorderThickness = value;
            }
            get
            {
                return pnlFilter.BorderThickness;
            }
        }
        public Color FilterBorderColor
        {
            set
            {
                pnlFilter.BorderColor = value;
            }
            get
            {
                return pnlFilter.BorderColor;
            }
        }
        public int CardBorderThickness
        {
            set
            {
                pnlCard.BorderThickness = value;
            }
            get
            {
                return pnlCard.BorderThickness;
            }
        }
        public Color CardBorderColor
        {
            set
            {
                pnlCard.BorderColor = value;
            }
            get
            {
                return pnlCard.BorderColor;
            }
        }

        public int PersonID { get { return ctrlPersonCard1.PersonID; } } // to use current personID outside the control

        public ctrlPersonCardWithSearch()
        {
            InitializeComponent();
            ctrlPersonCard1.delUpdateBreadcrumbFromPersonCard += (se, ev) => delUpdateBreadcrumbFromCardWithFilter(se, ev);
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            delUpdateBreadcrumbFromCardWithFilter(sender, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Add" });

            frmAddEditPerson addEditPerson = new frmAddEditPerson(-1);
            addEditPerson.OnNewPersonAdded += AddEditPerson_OnNewPersonAdded;
            addEditPerson.ShowDialog();

            delUpdateBreadcrumbFromCardWithFilter(sender, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Remove" });
        }
        private void AddEditPerson_OnNewPersonAdded(int PersonID) // triggered when new person added
        {
            ctrlPersonCard1.LoadInfo(PersonID);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                MessageBox.Show($"Please fill needed data", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch(cbSearchBy.Text)
            {
                case "Person ID":

                    int ID = int.Parse(tbSearch.Text.Trim());
                    if (clsPeopleBusiness.DoesPersonExist(ID))
                        ctrlPersonCard1.LoadInfo(ID);
                    else
                        MessageBox.Show($"PersonID {ID} was not found", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        break;
                case "National No":

                    string NationalNo = tbSearch.Text.Trim();
                    if (clsPeopleBusiness.DoesPersonExist(NationalNo))
                        ctrlPersonCard1.LoadInfo(NationalNo);
                    else
                        MessageBox.Show($"National No {NationalNo} was not found", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;

                default:
                    MessageBox.Show($"Please select a filter then fill needed data", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchBy.Text == "None")
            {
                tbSearch.Text = "";
                tbSearch.Visible = false;
                return;
            }

            tbSearch.Text = "";
            tbSearch.Visible = true;
        }
        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back; // if Handled == true then will prevent any action
        }
    }
}
