using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsUserBusiness
    {
        enum enMode { eAddMode = 0, eUpdateMode = 1 };
        enMode _mode;

        private int _userID;
        public int UserID { get { return _userID; } }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }

        public clsPeopleBusiness Person;

        public clsUserBusiness()
        {
            this._userID = -1;
            this.PersonID = -1;
            this.Username = "";
            this.Password = "";
            this.isActive = false;
            this._mode = enMode.eAddMode;
        }

        clsUserBusiness(int UserID, int PersonID, string Username, string Password, bool isActive)
        {
            this._userID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.isActive = isActive;
            this.Person = clsPeopleBusiness.FindPerson(this.PersonID);
            this._mode = enMode.eUpdateMode;
        }

        private bool _AddNewUser()
        {
            this._userID = clsUserDataAccess.AddNewUser(this.PersonID, this.Username, this.Password, this.isActive);

            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            return false;
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

        public static clsUserBusiness FindUser(int UserID)
        {
            int PersonID = -1;
            string Username = "", Password = "";
            bool isActive = false;

            if (clsUserDataAccess.FindUser(UserID , ref Username, ref Password, ref PersonID, ref isActive))
                return new clsUserBusiness( UserID, PersonID, Username, Password, isActive);
            else
                return null;
        }

        public static bool DoesUsernameExist(string Username)
        {
            return clsUserDataAccess.DoesUsernameExist(Username);
        }

        public static bool DoesUserExist(int PersonID)
        {
            return clsUserDataAccess.DoesUserExist(PersonID);
        }

        public static bool DoesUserExist(string NationalNo)
        {
            return clsUserDataAccess.DoesUserExist(NationalNo);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }

        public bool Save()
        {
            switch(_mode)
            {
                case enMode.eAddMode:
                    if (_AddNewUser())
                    {
                        _mode = enMode.eUpdateMode;
                        return true;
                    }
                    else
                        return false;

                case enMode.eUpdateMode:
                    return _UpdateUser();

                default: return false;
            }
        }

    }
}
