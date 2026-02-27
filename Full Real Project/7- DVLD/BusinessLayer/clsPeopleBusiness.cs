using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsPeopleBusiness
    {
        enum enMode { eAddMode = 0, eUpdateMode = 1 };
        enMode _mode;

        public int PersonID { get; set; }
        public string NationalID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public byte Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }

        // for adding new person
        public clsPeopleBusiness()
        {
            this.PersonID = -1;
            this.NationalID = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Gender = 0;
            this.BirthDate = DateTime.Now;
            this.Country = "";
            this.Phone = "";
            this.Email = "";
            this.Address = "";
            this.ImagePath = "";
            this._mode = enMode.eAddMode;
        }

        // for updating existing persons
        clsPeopleBusiness(int PersonID, string NationalID, string FirstName, string SecondName, string ThirdName, string LastName, byte Gender,
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




        public static clsPeopleBusiness FindPerson(string ID, string Filter)
        {
            int PersonID = -1;
            byte Gender = 0;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Country = "", Phone = "", Email = "", Address = "",ImagePath = "", NationalID = "";
            DateTime BirthDate = DateTime.MinValue;

            if (Filter == "PersonID")
                PersonID = int.Parse(ID);
            else
                NationalID = ID;

            if (clsPeopleDataAccess.FindPerson(Filter, ref PersonID, ref NationalID, ref FirstName, ref SecondName, ref ThirdName,
                ref LastName, ref Gender, ref Country, ref Phone, ref Email, ref Address, ref ImagePath, ref BirthDate))
            {
                return new clsPeopleBusiness(PersonID, NationalID, FirstName, SecondName, ThirdName,
                     LastName, Gender, Country, Phone, Email, Address, ImagePath, BirthDate);
            }
            else
                return new clsPeopleBusiness();
        }


        public static DataTable GetAllPeople()
        {
            return clsPeopleDataAccess.GetAllPeople();
        }


        public static bool DoesExist(int ID, string Filter )
        {
            return clsPeopleDataAccess.DoesExist(ID, Filter);
        }
    }
}
