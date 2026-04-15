using BusinessLayer;
using PresentationLayer.Properties;
using System.IO;
using System.Drawing;

using System.Windows.Forms;

namespace PresentationLayer.Applications.DrivingLicenses.Controls
{
    public partial class ctrlLocalDrivingLicenseInfo : UserControl
    {
        public int BorderThickness
        {
            set
            {
                pnlCardBorder.BorderThickness = value;
            }
            get
            {
                return pnlCardBorder.BorderThickness;
            }
        }
        public Color BorderColor
        {
            set
            {
                pnlCardBorder.BorderColor = value;
            }
            get
            {
                return pnlCardBorder.BorderColor;
            }
        }

        clsLicensesBusiness _License;
        public clsLicensesBusiness SelectedLocalLicense { get { return _License; } }

        public ctrlLocalDrivingLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int LicenseID)
        {
            _License = clsLicensesBusiness.FindByLicenseID(LicenseID);
            if (_License == null)
            {
                MessageBox.Show($"Could not load info of LicenseID = {LicenseID}, data was not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillLicenseInfo();
        }

        private void _FillLicenseInfo()
        {
            lblLicenseClass.Text = _License.LicenseCLassInfo.ClassName;
            lblName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalID;
            lblBirthDate.Text = _License.DriverInfo.PersonInfo.BirthDate.ToShortDateString();
            lblGender.Text = _License.DriverInfo.PersonInfo.Gender.ToString();
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblIssueReason.Text = _License.GetIssueReasonText();
            lblNotes.Text = _License.Notes;
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblIsDetained.Text = _License.IsLicenseDetained() ? "Yes" : "No";
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToShortDateString();
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();

            _LoadPersonImage();
        }

        private void _LoadPersonImage()
        {
            if (string.IsNullOrEmpty(_License.DriverInfo.PersonInfo.ImagePath))
                pbPersonPic.Image = _License.DriverInfo.PersonInfo.Gender == clsPeopleBusiness.enGender.Male ? Resources.defaultMaleProfile : Resources.defaultFemaleProfile;
            else
            {
                using (FileStream fs = new FileStream(_License.DriverInfo.PersonInfo.ImagePath, FileMode.Open, FileAccess.Read))
                {
                    pbPersonPic.Image = new Bitmap(fs);
                }
            }
        }

    }
}
