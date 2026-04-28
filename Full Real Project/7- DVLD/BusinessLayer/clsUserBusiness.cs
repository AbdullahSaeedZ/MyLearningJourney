using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsUserBusiness
    {
        enum enMode { eAddMode = 0, eUpdateMode = 1 };
        enMode _mode;

        public int UserID { get; private set; }

        private int _personID;
        public int PersonID
        {
            get
            {
                return _personID;
            }
            set
            {
                if (_personID == -1) // to prevent any modification and allow only new assignment from ui
                    _personID = value;
            }
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }
        public int Permissions { get; set; }

        public clsPeopleBusiness Person
        {
            get
            {
                return clsPeopleBusiness.FindPerson(this.PersonID);
            }
        }

        public clsUserBusiness()
        {
            this.UserID = -1;
            this._personID = -1;
            this.Username = "";
            this.Password = "";
            this.isActive = false;
            this.Permissions = 0;
            this._mode = enMode.eAddMode;
        }

        clsUserBusiness(int UserID, int PersonID, string Username, string Password, bool isActive, int Permissions)
        {
            this.UserID = UserID;
            this._personID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.isActive = isActive;
            this.Permissions = Permissions;
            this._mode = enMode.eUpdateMode;
        }

        public bool HasPermission(clsBusinessSettings.enPermissions Permission)
        {
            return (((clsBusinessSettings.enPermissions)(this.Permissions)).HasFlag(Permission));
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserDataAccess.AddNewUser(this.PersonID, this.Username, this.Password, this.isActive, this.Permissions);

            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            return clsUserDataAccess.UpdateUser(this.UserID, this.Username, this.Password, this.isActive, this.Permissions);
        }

        public bool ChangePassword(string NewPassword, clsUserBusiness CurrentUser)
        {
            if (!CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eUpdateUser) && CurrentUser.UserID != this.UserID) // to allow user editing his own password
                throw new UnauthorizedAccessException("You do not have permission to edit users");

            return clsUserDataAccess.ChangePassword(this.UserID, NewPassword);
        }

        public static bool DeleteUser(int UserID, clsUserBusiness CurrentUser)
        {
            if (!CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eDeleteUser))
                throw new UnauthorizedAccessException("You do not have permission to delete users");

            return clsUserDataAccess.DeleteUser(UserID);
        }

        public static clsUserBusiness FindUser(string Username, string Password)
        {
            int UserID = -1, PersonID = -1, Permissions = 0;
            bool isActive = false;

            if (clsUserDataAccess.FindUser(Username, Password, ref UserID, ref PersonID, ref isActive, ref Permissions))
                return new clsUserBusiness( UserID, PersonID, Username, Password, isActive, Permissions);
            else
                return null;
        }

        public static clsUserBusiness FindUser(int UserID)
        {
            int PersonID = -1, Permissions = 0;
            string Username = "", Password = "";
            bool isActive = false;

            if (clsUserDataAccess.FindUser(UserID , ref Username, ref Password, ref PersonID, ref isActive, ref Permissions))
                return new clsUserBusiness( UserID, PersonID, Username, Password, isActive, Permissions);
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

        public bool Save(clsUserBusiness CurrentUser)
        {
            switch(_mode)
            {
                case enMode.eAddMode:

                    if (!CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eAddUser))
                        throw new UnauthorizedAccessException("You do not have permission to Add users");

                    if (_AddNewUser())
                    {
                        _mode = enMode.eUpdateMode;
                        return true;
                    }
                    else
                        return false;

                case enMode.eUpdateMode:

                    if (!CurrentUser.HasPermission(clsBusinessSettings.enPermissions.eUpdateUser) && CurrentUser.UserID != this.UserID) // to allow user editing his own profile
                        throw new UnauthorizedAccessException("You do not have permission to edit users");

                    return _UpdateUser();

                default: return false;
            }
        }

    }
}
