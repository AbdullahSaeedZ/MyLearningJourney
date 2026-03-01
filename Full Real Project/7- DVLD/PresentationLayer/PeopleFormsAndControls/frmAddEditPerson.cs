using BusinessLayer;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace PresentationLayer.PeopleFormsAndControls
{
    public partial class frmAddEditPerson : Form
    {
        clsPeopleBusiness person;
        private const string _defaultMalePic = @"D:\defaultMaleProfile.png";
        private const string _defaultFemalePic = @"D:\defaultFemaleProfile.png";
        private const string _defaultComboBoxCountry = "Saudi Arabia";
        private DateTime _defaultMaxAllowedAge = DateTime.Now.AddYears(-18);


        public frmAddEditPerson(int personID)
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            _FillCountriesComboBox();
            rbMale.Checked = true;
            dtpBirthDate.MaxDate = _defaultMaxAllowedAge;

            if (personID == -1)
            {
                person = new clsPeopleBusiness();
            }
            else 
            {
                person = clsPeopleBusiness.FindPerson(personID.ToString(), "PersonID");
                if (person == null)
                {
                    MessageBox.Show("Person Does Not Exist, Form will close", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                _FillPersonInfoInForm();
            }
        }

        private void _FillCountriesComboBox()
        {
            DataTable dt = clsCountriesBusiness.GetAllCountries();

            foreach (DataRow row in dt.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
            cbCountry.SelectedItem = _defaultComboBoxCountry;
        }
        private void _FillPersonInfoInForm()
        {

            lblPersonID.Text = person.PersonID.ToString();
            lblFormTitle.Text = $"Edit person with ID = {person.PersonID}";

            tbNationalNumber.Text = person.NationalID;
            tbFirstName.Text = person.FirstName;
            tbSecondName.Text = person.SecondName;
            tbThirdName.Text = person.ThirdName;
            tbLastName.Text = person.LastName;
            tbEmail.Text = person.Email;
            dtpBirthDate.Value = person.BirthDate;
            tbPhone.Text = person.Phone;
            tbAddress.Text = person.Address;
            cbCountry.SelectedIndex = person.CountryID - 1; //////

            if (person.Gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            if (!string.IsNullOrEmpty(person.ImagePath))
            {
                pbImage.Image = Image.FromFile(person.ImagePath);

                if(person.ImagePath != _defaultMalePic && person.ImagePath != _defaultFemalePic)
                btnRemoveImage.Visible = true;
            }
        }

        private bool AreAllFieldsFilled()
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text) || string.IsNullOrWhiteSpace(tbSecondName.Text) || string.IsNullOrWhiteSpace(tbLastName.Text) ||
                string.IsNullOrWhiteSpace(tbAddress.Text) || string.IsNullOrWhiteSpace(tbPhone.Text) || string.IsNullOrWhiteSpace(tbNationalNumber.Text) ||
                !(rbMale.Checked || rbFemale.Checked))
                return false;
            else
                return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!AreAllFieldsFilled())
            {
                MessageBox.Show("Fields with * must be filled first", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            person.NationalID = tbNationalNumber.Text;
            person.FirstName = tbFirstName.Text;
            person.SecondName = tbSecondName.Text;
            person.ThirdName = string.IsNullOrEmpty(tbThirdName.Text) ? "" : tbThirdName.Text;
            person.LastName = tbLastName.Text;
            person.Email = tbEmail.Text;
            person.BirthDate = dtpBirthDate.Value;
            person.Phone = tbPhone.Text;
            person.Address = tbAddress.Text;
            person.CountryID = cbCountry.SelectedIndex + 1;
            person.Gender = rbMale.Checked ? (byte)0 : (byte)1;

            if (btnRemoveImage.Visible == false)// set default if pic not added
            {
                pbImage.Image = rbMale.Checked ? Image.FromFile(_defaultMalePic) : Image.FromFile(_defaultFemalePic);
                person.ImagePath = rbMale.Checked ? _defaultMalePic : _defaultFemalePic;
            }
                  
            if (person.Save())
            {
                MessageBox.Show($"Data Saved Successfully, PersonID {person.PersonID}","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                lblPersonID.Text = person.PersonID.ToString();
                lblFormTitle.Text = $"Edit person with ID = {person.PersonID}";
            }
            else
            {
                MessageBox.Show("Data Was Not Saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"D:\"; // which folder or place to show when dialog opens
            openFileDialog1.Title = "Choose a Profile Picture";
            openFileDialog1.DefaultExt = "png"; // default extension of file to be saved, user just enters file name then .txt will be attached to it
            openFileDialog1.Filter = "png (*.png)|*.png";
            openFileDialog1.FilterIndex = 1; //which extension to be default when dialog opens.(starts from 1)

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbImage.Image = Image.FromFile(openFileDialog1.FileName);
                person.ImagePath = openFileDialog1.FileName;
                btnRemoveImage.Visible = true;
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            btnRemoveImage.Visible = false;
            person.ImagePath = string.Empty;
            pbImage.Image = rbMale.Checked ? Image.FromFile(_defaultMalePic) : Image.FromFile(_defaultFemalePic);
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (btnRemoveImage.Visible == false) // set default if pic not added
                pbImage.Image = rbMale.Checked ? Image.FromFile(_defaultMalePic) : Image.FromFile(_defaultFemalePic);
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (btnRemoveImage.Visible == false) // set default if pic not added
                pbImage.Image = rbMale.Checked ? Image.FromFile(_defaultMalePic) : Image.FromFile(_defaultFemalePic);
        }


        // errorsProvider validation
        private void tbNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((Guna2TextBox)sender).Text))
            {
                errorProvider1.SetError((Guna2TextBox)sender, "This field is required");
                return;
            }
            else
                errorProvider1.SetError((Guna2TextBox)sender, "");


            if (clsPeopleBusiness.DoesExist(tbNationalNumber.Text, "NationalNo"))
                errorProvider1.SetError(tbNationalNumber, "Person Exists with this NationalNo");
            else
                errorProvider1.SetError(tbNationalNumber, "");
        }

        // multiple textBoxes subscribed to this event
        private void EmptyTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((Guna2TextBox)sender).Text))
                errorProvider1.SetError((Guna2TextBox)sender, "This field is required");
            else
                errorProvider1.SetError((Guna2TextBox)sender, "");
        }


        // not required, but if email entered, needs validation
        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            string Email = tbEmail.Text.Trim(); // if user forgets space in the end, it will give false
            bool isFormatValid = Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]+$",RegexOptions.IgnoreCase); //RegularExpressions same as Java

            if (!string.IsNullOrWhiteSpace(tbEmail.Text) && !isFormatValid)
                errorProvider1.SetError((Guna2TextBox)sender, "Invalid Email Format");
            else
                errorProvider1.SetError((Guna2TextBox)sender, "");
        }
    }
}
