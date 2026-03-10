using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsUserBusiness
    {
        enum enMode { eAddMode = 0, eUpdateMode = 1 };
        enMode _mode;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }

        public clsPeopleBusiness Person;

        public clsUserBusiness()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.Username = "";
            this.Password = "";
            this.isActive = false;
            this._mode = enMode.eAddMode;
        }

        clsUserBusiness(int UserID, int PersonID, string Username, string Password, bool isActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.isActive = isActive;
            this.Person = clsPeopleBusiness.FindPerson(this.PersonID);
            this._mode = enMode.eUpdateMode;
        }

        public static clsUserBusiness FindUser(string Username, string Password)
        {
            int UserID = -1, PersonID = -1;
            bool isActive = false;

            if (clsUserDataAccess.FindUser(Username, Password, ref UserID, ref PersonID, ref isActive))
                return new clsUserBusiness( UserID, PersonID, Username, Password, isActive);
            else
                return null;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }

    }
}
