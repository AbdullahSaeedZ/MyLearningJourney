using DataAccessLayer;
using System;
using System.Data;

namespace BusinessLayer
{
    public class clsLicensesBusiness
    {
        enum enMode { eAddMode = 0, eUpdateMode = 1 };
        public enum enIssueReason { FirstTime = 1, Renew = 2 , ReplacementForDamaged = 3, ReplacementForLost = 4};

        enMode _mode;
        

        public int LicenseID { get; private set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        

        public clsLicensesBusiness()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.Notes = "";
            this.PaidFees = - 1;
            this.IsActive = false;
            this.IssueReason = 0;
            this.CreatedByUserID = -1;
            this._mode = enMode.eAddMode;
        }

        clsLicensesBusiness(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate, 
            string Notes, float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            this._mode = enMode.eUpdateMode;
        }

        public static clsLicensesBusiness FindByLicenseID(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            byte IssueReason = 0;
            DateTime IssueDate = DateTime.MinValue, ExpirationDate = DateTime.MinValue;
            string Notes = "";
            float PaidFees = -1;
            bool IsActive = false;

            if (clsLicensesDataAccess.FindByLicenseID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate,
                                              ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicensesBusiness( LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate,
                                                Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            else
                return null;
        }


        private bool _AddNewLicense()
        {

            int LicenseValidityLength = (int)(clsLicenseClassesBusiness.Find(this.LicenseClassID)).DefaultValidityLength;

            this.LicenseID = clsLicensesDataAccess.AddNewLicense( this.ApplicationID, this.DriverID, this.LicenseClassID, DateTime.Now, this.IssueDate.AddYears(LicenseValidityLength),
            this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }
        private bool _UpdateLicense()
        {
            return clsLicensesDataAccess.UpdateLicense(this.LicenseID ,this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate,
            this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicensesDataAccess.GetAllLicenses();
        }

        public bool Save()
        {
            switch (_mode)
            {
                case enMode.eAddMode:
                    if (_AddNewLicense())
                    {
                        _mode = enMode.eUpdateMode;
                        return true;
                    }
                    else
                        return false;

                case enMode.eUpdateMode:
                    return _UpdateLicense();

                default: return false;
            }
        }



        public static bool DoesLicenseExist(int LicenseID)
        {
            return clsLicensesDataAccess.DoesLicenseExist(LicenseID);
        }
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicensesDataAccess.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }

        public static bool DoesPersonHaveActiveLicense(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }

    }
}
