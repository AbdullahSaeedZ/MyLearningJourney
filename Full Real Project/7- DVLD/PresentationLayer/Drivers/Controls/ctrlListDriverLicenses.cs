using BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Drivers.Controls
{
    public partial class ctrlListDriverLicenses : UserControl
    {
        public int OuterBorderThickness
        {
            set
            {
                pnlOuterBorder.BorderThickness = value;
            }
            get
            {
                return pnlOuterBorder.BorderThickness;
            }
        }
        public Color OuterBorderColor
        {
            set
            {
                pnlOuterBorder.BorderColor = value;
            }
            get
            {
                return pnlOuterBorder.BorderColor;
            }
        }

        public int TabBorderThickness
        {
            set
            {
                pnlTabBorder.BorderThickness = value;
            }
            get
            {
                return pnlTabBorder.BorderThickness;
            }
        }
        public Color TabBorderColor
        {
            set
            {
                pnlTabBorder.BorderColor = value;
            }
            get
            {
                return pnlTabBorder.BorderColor;
            }
        }

        public int DGVBorderThickness
        {
            set
            {
                pnlDGVBorder.BorderThickness = value;
            }
            get
            {
                return pnlOuterBorder.BorderThickness;
            }
        }
        public Color DGVBorderColor
        {
            set
            {
                pnlDGVBorder.BorderColor = value;
            }
            get
            {
                return pnlDGVBorder.BorderColor;
            }
        }

        int _PersonID = -1;
        DataTable dtLocalLicenses;
        DataTable dtInternationalLicenses;

        public ctrlListDriverLicenses()
        {
            InitializeComponent();
        }

        public void LoadInfo(int PersonID) // personID will be provided by person control with valid person object, otherwise wont reach here
        {
            _PersonID = PersonID;
            if (_PersonID == -1)
            {
                lblNoLicensesIssued.Visible = true;
                return;
            }
            _LoadLocalLicenses();
        }
        private void btnShowInternationalLicenses_Click(object sender, EventArgs e)
        {
            _LoadInternationalLicenses();
        }

        private void btnShowLocalLicenses_Click(object sender, EventArgs e)
        {
            _LoadLocalLicenses();
        }

        private void _LoadLocalLicenses()
        {
            ToggleLicensesType();

            dtLocalLicenses = clsLicensesBusiness.GetAllLocalLicenses(_PersonID);
            if (dtLocalLicenses == null)
            {
                lblNoLicensesIssued.Visible = true;
                lblNumberOfRecords.Text = "0";
                return;
            }

            lblNoLicensesIssued.Visible = false;
            dgvLocalLicenses.DataSource = dtLocalLicenses;
            lblNumberOfRecords.Text = dgvLocalLicenses.RowCount.ToString();
        }
        private void _LoadInternationalLicenses()
        {
            ToggleLicensesType();

            dtInternationalLicenses = clsInternationalLicensesBusiness.GetAllInternationalLicensesByPersonID(_PersonID);
            if (dtInternationalLicenses == null)
            {
                lblNoLicensesIssued.Visible = true;
                lblNumberOfRecords.Text = "0";
                return;
            }

            lblNoLicensesIssued.Visible = false;
            dgvInternationalLicenses.DataSource = dtInternationalLicenses;
            lblNumberOfRecords.Text = dgvLocalLicenses.RowCount.ToString();

            
        }

        private void ToggleLicensesType()
        {
            dgvInternationalLicenses.Visible = !dgvLocalLicenses.Visible;
            dgvLocalLicenses.Visible = !dgvInternationalLicenses.Visible;

            btnShowLocalLicenses.Visible = !btnShowInternationalLicenses.Visible;
            btnShowInternationalLicenses.Visible = !btnShowLocalLicenses.Visible;

            lblLicenseTypeTitle.Text = dgvLocalLicenses.Visible ?   
                lblLicenseTypeTitle.Text.Replace("International", "Local"): lblLicenseTypeTitle.Text.Replace("Local", "International"); ;
        }
    }
}
