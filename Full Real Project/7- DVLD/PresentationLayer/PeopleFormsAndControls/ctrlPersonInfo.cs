using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.PeopleFormsAndControls
{
    public partial class ctrlPersonInfo : UserControl
    {
        enum enGender { Male = 0, Female = 1 };
        public ctrlPersonInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int personID)
        {
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

            pbProfilePic.Image = Person.ImagePath == string.Empty ? Properties.Resources.ProfileTest : Image.FromFile(Person.ImagePath);
        }
        
    }
}
