using BusinessLayer;
using PresentationLayer.MainForm;
using PresentationLayer.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PresentationLayer.PeopleFormsAndControls
{
    public partial class ctrlPersonCard : UserControl
    {
        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumbFromPersonCard;
        public event Action PersonCardUpdated; // custom event that will eventually update DGV in ctrlPeople if invoked

        // outside usage:  use loadInfo method then can use PersonID;
        enum enGender { Male = 0, Female = 1 };
        private int _personID = -1;
        public int PersonID { get { return _personID; } } // to use current personID outside the control
        private clsPeopleBusiness _person;
        public clsPeopleBusiness SelectedPersonInfo { get { return _person; } } // to get person info outside the control
        public int BorderThickness 
        {
            set
            {
                pnlFullBorder.BorderThickness = value;
            }        
            get
            {
                return pnlFullBorder.BorderThickness;
            }        
        }
        public Color BorderColor 
        {
            set
            {
                pnlFullBorder.BorderColor = value;
            }        
            get
            {
                return pnlFullBorder.BorderColor;
            }        
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
            btnEditInfo.Visible = false;
        }

        public void LoadInfo(int personID)
        {
            _person = clsPeopleBusiness.FindPerson(personID);
            
            if (_person == null)
            {
                MessageBox.Show( $"PersonID = {personID} was not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnEditInfo.Visible = true;
            PersonCardUpdated?.Invoke(); // after editPerson is done , this will eventually update DGV
            _FillPersonInfo();
        }

        public void LoadInfo(string NationalID)
        {
            _person = clsPeopleBusiness.FindPerson(NationalID);
            
            if (_person == null)
            {
                MessageBox.Show( $"PersonID = {NationalID} was not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnEditInfo.Visible = true;
            PersonCardUpdated?.Invoke();
            _FillPersonInfo();
        }

        public void ResetPersonInfo()
        {
            _personID = -1;
            lblName.Text = "NA";
            lblPersonID.Text = "NA";
            lblNationalID.Text = "NA";
            lblCountry.Text = "NA";
            lblEmail.Text = "NA";
            lblBirthDate.Text = "NA";
            lblAddress.Text = "NA";
            lblGender.Text = "NA";
            lblPhone.Text = "NA";
            pbProfilePic.Image = Resources.defaultMaleProfile;

        }



        private void _FillPersonInfo()
        {
            _personID = _person.PersonID;
            lblName.Text = _person.FirstName + " " + _person.SecondName + " " + _person.ThirdName + " " + _person.LastName;
            lblPersonID.Text = _person.PersonID.ToString();
            lblNationalID.Text = _person.NationalID.ToString();
            lblCountry.Text = _person.CountryInfo.CountryName;
            lblEmail.Text = _person.Email;
            lblBirthDate.Text = _person.BirthDate.ToShortDateString();
            lblAddress.Text = _person.Address;
            lblGender.Text = ((enGender)_person.Gender).ToString();
            lblPhone.Text = _person.Phone;
            _LoadPersonImage();
        }
        private void _LoadPersonImage()
        {
            if (string.IsNullOrEmpty(_person.ImagePath))
                pbProfilePic.Image = _person.Gender == (byte)enGender.Male ? Resources.defaultMaleProfile : Resources.defaultFemaleProfile;
            else
            {
                using (FileStream fs = new FileStream(_person.ImagePath, FileMode.Open, FileAccess.Read))
                {
                    pbProfilePic.Image = new Bitmap(fs);
                }
            }
        }
        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            delUpdateBreadcrumbFromPersonCard(sender, new frmMain.clsBreadcrumbData() { title = "> Edit Person Info", operationType = "Add" });

            frmAddEditPerson editPerson = new frmAddEditPerson(_personID);
            editPerson.OnUpdateDoneForPersonCard += LoadInfo;// to update info here in personCard when info is updated in AddEdit form
            editPerson.ShowDialog();

            delUpdateBreadcrumbFromPersonCard(sender, new frmMain.clsBreadcrumbData() { title = "> Edit Person Info", operationType = "Remove" });
        }
    }
}
