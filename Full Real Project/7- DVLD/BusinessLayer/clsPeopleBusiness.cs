using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsPeopleBusiness
    {
        enum enMode { eAddMode = 0, eUpdateMode = 1 };
        enMode _mode;
        enum enGender { Male = 0, Female = 1 };
        public int PersonID { get; set; }
        public string NationalID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public byte Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryID { get; set; }
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
            this.CountryID = -1;
            this.Phone = "";
            this.Email = "";
            this.Address = "";
            this.ImagePath = "";
            this._mode = enMode.eAddMode;
        }

        // for updating existing persons
        clsPeopleBusiness(int PersonID, string NationalID, string FirstName, string SecondName, string ThirdName, string LastName, byte Gender,
            int CountryID, string Phone, string Email, string Address, string ImagePath, DateTime BirthDate)
        {
            this.PersonID = PersonID;
            this.NationalID = NationalID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.BirthDate = BirthDate;
            this.CountryID = CountryID;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.ImagePath = ImagePath;
            _mode = enMode.eUpdateMode;
        }




        public static clsPeopleBusiness FindPerson(string ID, string Filter)
        {
            int PersonID = -1, CountryID = -1;
            byte Gender = 0;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Phone = "", Email = "", Address = "",ImagePath = "", NationalID = "";
            DateTime BirthDate = DateTime.MinValue;

            if (Filter == "PersonID")
                PersonID = int.Parse(ID);
            else
                NationalID = ID;

            if (clsPeopleDataAccess.FindPerson(Filter, ref PersonID, ref NationalID, ref FirstName, ref SecondName, ref ThirdName,
                ref LastName, ref Gender, ref CountryID, ref Phone, ref Email, ref Address, ref ImagePath, ref BirthDate))
            {
                return new clsPeopleBusiness(PersonID, NationalID, FirstName, SecondName, ThirdName,
                     LastName, Gender, CountryID, Phone, Email, Address, ImagePath, BirthDate);
            }
            else
                return new clsPeopleBusiness();
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPeopleDataAccess.AddNewPerson(this.NationalID, this.FirstName, this.SecondName, this.ThirdName,
                     this.LastName, this.Gender, this.CountryID, this.Phone, this.Email, this.Address, this.ImagePath, this.BirthDate);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPeopleDataAccess.UpdatePerson(this.PersonID, this.NationalID, this.FirstName, this.SecondName, this.ThirdName,
                     this.LastName, this.Gender, this.CountryID, this.Phone, this.Email, this.Address, this.ImagePath, this.BirthDate);
        }

        public bool Save()
        {
            switch (_mode)
            {
                case enMode.eAddMode:
                    if (_AddNewPerson())
                    {
                        _mode = enMode.eUpdateMode;
                        return true;
                    }
                    else
                        return false;

                case enMode.eUpdateMode:
                    if (_UpdatePerson())
                        return true;
                    else
                        return false;

                default: return false;
            }
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleDataAccess.DeletePerson(PersonID);
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
