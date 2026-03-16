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
        public int NationalityCountryID { get; set; }

        public clsCountriesBusiness CountryInfo;
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
            this.NationalityCountryID = -1;
            this.Phone = "";
            this.Email = "";
            this.Address = "";
            this.ImagePath = "";
            this._mode = enMode.eAddMode;
        }

        // for getting existing persons
        clsPeopleBusiness(int PersonID, string NationalID, string FirstName, string SecondName, string ThirdName, string LastName, byte Gender,
            int NationalityCountryID, string Phone, string Email, string Address, string ImagePath, DateTime BirthDate)
        {
            this.PersonID = PersonID;
            this.NationalID = NationalID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.BirthDate = BirthDate;
            this.NationalityCountryID = NationalityCountryID;
            this.CountryInfo = clsCountriesBusiness.GetCountry(NationalityCountryID);
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.ImagePath = ImagePath;
            _mode = enMode.eUpdateMode;
        }


      

        public static clsPeopleBusiness FindPerson(int PersonID)
        {
            int NationalityCountryID = -1;
            byte Gender = 0;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Phone = "", Email = "", Address = "", ImagePath = "", NationalID = "";
            DateTime BirthDate = DateTime.MinValue;

            if (clsPeopleDataAccess.FindPerson(PersonID, ref NationalID, ref FirstName, ref SecondName, ref ThirdName,
                ref LastName, ref Gender, ref NationalityCountryID, ref Phone, ref Email, ref Address, ref ImagePath, ref BirthDate))
            {
                return new clsPeopleBusiness(PersonID, NationalID, FirstName, SecondName, ThirdName,
                     LastName, Gender, NationalityCountryID, Phone, Email, Address, ImagePath, BirthDate);
            }
            else
                return null;
        }

        public static clsPeopleBusiness FindPerson(string NationalID)
        {
            int PersonID = -1, CountryID = -1;
            byte Gender = 0;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Phone = "", Email = "", Address = "", ImagePath = "";
            DateTime BirthDate = DateTime.MinValue;

            if (clsPeopleDataAccess.FindPerson(ref PersonID, NationalID, ref FirstName, ref SecondName, ref ThirdName,
                ref LastName, ref Gender, ref CountryID, ref Phone, ref Email, ref Address, ref ImagePath, ref BirthDate))
            {
                return new clsPeopleBusiness(PersonID, NationalID, FirstName, SecondName, ThirdName,
                     LastName, Gender, CountryID, Phone, Email, Address, ImagePath, BirthDate);
            }
            else
                return null;
        }

        private bool _AddNewPerson()
        {
            if (!clsBusinessSettings.CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eAddPerson))
                throw new UnauthorizedAccessException("You do not have permission to add People");

            this.PersonID = clsPeopleDataAccess.AddNewPerson(this.NationalID, this.FirstName, this.SecondName, this.ThirdName,
                     this.LastName, this.Gender, this.NationalityCountryID, this.Phone, this.Email, this.Address, this.ImagePath, this.BirthDate);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            if (!clsBusinessSettings.CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eUpdatePerson) && clsBusinessSettings.CurrentUser.PersonID != this.PersonID) // to allow user editing his own profile
                throw new UnauthorizedAccessException("You do not have permission to edit People");

            return clsPeopleDataAccess.UpdatePerson(this.PersonID, this.NationalID, this.FirstName, this.SecondName, this.ThirdName,
                     this.LastName, this.Gender, this.NationalityCountryID, this.Phone, this.Email, this.Address, this.ImagePath, this.BirthDate);
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
                    return _UpdatePerson();

                default: return false;
            }
        }

        public static bool DeletePerson(int PersonID)
        {
            if (!clsBusinessSettings.CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eDeletePerson))
                throw new UnauthorizedAccessException("You do not have permission to Add People");

            return clsPeopleDataAccess.DeletePerson(PersonID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPeopleDataAccess.GetAllPeople();
        }

        public static bool DoesPersonExist(int PersonID) 
        {
            return clsPeopleDataAccess.DoesPersonExist(PersonID);
        }
        public static bool DoesPersonExist(string NationalID) 
        {
            return clsPeopleDataAccess.DoesPersonExist(NationalID);
        }
    }
}
