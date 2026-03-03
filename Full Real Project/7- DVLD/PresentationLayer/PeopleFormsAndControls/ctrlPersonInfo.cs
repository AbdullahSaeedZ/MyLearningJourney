using BusinessLayer;
using PresentationLayer.MainForm;
using PresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.PeopleFormsAndControls
{
    public partial class ctrlPersonInfo : UserControl
    {
        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumb3;
        
        enum enGender { Male = 0, Female = 1 };
        private int _personID;
        public ctrlPersonInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int personID)
        {
            _personID = personID;
            clsPeopleBusiness Person = clsPeopleBusiness.FindPerson(personID.ToString(), "PersonID");
            lblName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
            lblPersonID.Text = Person.PersonID.ToString();
            lblNationalID.Text = Person.NationalID.ToString();
            lblCountry.Text = clsCountriesBusiness.GetCountryNameByID(Person.CountryID);
            lblEmail.Text = Person.Email;
            lblBirthDate.Text = Person.BirthDate.ToShortDateString();
            lblAddress.Text = Person.Address;
            lblGender.Text = ((enGender)Person.Gender).ToString();
            lblPhone.Text = Person.Phone;

            if (string.IsNullOrEmpty(Person.ImagePath))
                pbProfilePic.Image = Person.Gender == (byte)enGender.Male ? Resources.defaultMaleProfile : Resources.defaultFemaleProfile;
            else
            {
                using (FileStream fs = new FileStream(Person.ImagePath, FileMode.Open, FileAccess.Read))
                {
                    pbProfilePic.Image = new Bitmap(fs);
                }
            }

        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            delUpdateBreadcrumb3(sender, new frmMain.clsBreadcrumbData() { title = "> Edit Person Info", operationType = "Add" });
            frmAddEditPerson editPerson = new frmAddEditPerson(_personID);
            editPerson.ShowDialog();
            delUpdateBreadcrumb3(sender, new frmMain.clsBreadcrumbData() { title = "> Edit Person Info", operationType = "Remove" });

            LoadInfo(_personID); // load updated info
        }
    }
}
