using System;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsPeopleBusiness
    {
        enum enMode { eAddMode = 0, eUpdateMode = 1 };
        enMode _mode;

        public int PersonID { get; set; }
        public int NationalID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }

        // for adding new person
        clsPeopleBusiness()
        {
            this.PersonID = -1;
            this.NationalID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Gender = "";
            this.BirthDate = DateTime.Now;
            this.Country = "";
            this.Phone = "";
            this.Email = "";
            this.Address = "";
            this.ImagePath = "";
            this._mode = enMode.eAddMode;
        }

        // for updating existing persons
        clsPeopleBusiness(int PersonID, int NationalID, string FirstName, string SecondName, string ThirdName, string LastName, string Gender,
            string Country, string Phone, string Email, string Address, string ImagePath, DateTime BirthDate)
        {
            this.PersonID = PersonID;
            this.NationalID = NationalID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.BirthDate = BirthDate;
            this.Country = Country;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.ImagePath = ImagePath;
            _mode = enMode.eUpdateMode;
        }


        public static clsPeopleBusiness FindPersonByID(int PersonID)
        {
            int NationalID = -1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Gender = "", Country = "", Phone = "", Email = "", Address = "",ImagePath = "";
            DateTime BirthDate = DateTime.Now;

            if (clsPeopleDataAccess.FindPersonByID(PersonID, ref NationalID, ref FirstName, ref SecondName, ref ThirdName,
                ref LastName, ref Gender, ref Country, ref Phone, ref Email, ref Address, ref ImagePath, ref BirthDate))
            {
                return new clsPeopleBusiness(PersonID, NationalID, FirstName, SecondName, ThirdName,
                     LastName, Gender, Country, Phone, Email, Address, ImagePath, BirthDate);
            }
            else
                return new clsPeopleBusiness();
        }

        public static clsPeopleBusiness FindPersonByNationalID(int NationalID)
        {
            int PersonID = -1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Gender = "", Country = "", Phone = "", Email = "", Address = "", ImagePath = "";
            DateTime BirthDate = DateTime.Now;

            if (clsPeopleDataAccess.FindPersonByNationalID(ref PersonID, NationalID, ref FirstName, ref SecondName, ref ThirdName,
                ref LastName, ref Gender, ref Country, ref Phone, ref Email, ref Address, ref ImagePath, ref BirthDate))
            {
                return new clsPeopleBusiness(PersonID, NationalID, FirstName, SecondName, ThirdName,
                     LastName, Gender, Country, Phone, Email, Address, ImagePath, BirthDate);
            }
            else
                return new clsPeopleBusiness();
        }
    }
}
