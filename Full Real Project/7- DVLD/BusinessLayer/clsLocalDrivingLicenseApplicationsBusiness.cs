using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsLocalDrivingLicenseApplicationsBusiness : clsApplicationsBusiness
    {
        // hiding base _mode cuz when adding new application, the base mode will switch to update then sub Save method will go directly to update
        private new enMode _mode;

        private int _localDrivingLicenseApplicationID;
        public int LocalDrivingLicenseApplicationID
        {
            get
            {
                return _localDrivingLicenseApplicationID;
            }
            set
            {
                if (_localDrivingLicenseApplicationID == -1) // to prevent any modification
                    _localDrivingLicenseApplicationID = value;
            }
        }
        
        public int LicenseClassID { get; set; }
   

        public clsLicenseClassesBusiness LicenseClassesInfo;

        public clsLocalDrivingLicenseApplicationsBusiness()
        {
            this._localDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;
        }


        clsLocalDrivingLicenseApplicationsBusiness(int LocalApplicationID, int LicenseClassID, int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID) 
            : base (ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {
            this._localDrivingLicenseApplicationID = LocalApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassesInfo = clsLicenseClassesBusiness.Find(LicenseClassID); 
        }

        public static clsLocalDrivingLicenseApplicationsBusiness FindLocalLicenseApplicationByID(int LocalApplicationID)
        {
            int ApplicationID = -1, licenseClassID = -1;
            if (clsLocalDrivingLicenseApplicationsDataAccess.FindLocalLicenseApplicationByID(LocalApplicationID, ref ApplicationID, ref licenseClassID))
            {

                clsApplicationsBusiness baseApplication = clsApplicationsBusiness.FindBaseApplicationByID(ApplicationID);

                return new clsLocalDrivingLicenseApplicationsBusiness(LocalApplicationID, licenseClassID, ApplicationID, baseApplication.ApplicantPersonID, baseApplication.ApplicationDate,
                                                                      baseApplication.ApplicationTypeID, baseApplication.ApplicationStatus, baseApplication.LastStatusDate, baseApplication.PaidFees,
                                                                      baseApplication.CreatedByUserID);
            }
            else
                return null;
        }



        public static clsLocalDrivingLicenseApplicationsBusiness FindLocalLicenseApplicationByApplicationID(int ApplicationID)
        {
            int localApplicationID = -1, licenseClassID = -1;
            if (clsLocalDrivingLicenseApplicationsDataAccess.FindLocalLicenseApplicationByApplicationID(ref localApplicationID, ApplicationID, ref licenseClassID))
            {

                clsApplicationsBusiness baseApplication = clsApplicationsBusiness.FindBaseApplicationByID(ApplicationID);

                return new clsLocalDrivingLicenseApplicationsBusiness(localApplicationID, licenseClassID, ApplicationID, baseApplication.ApplicantPersonID, baseApplication.ApplicationDate,
                                                                      baseApplication.ApplicationTypeID, baseApplication.ApplicationStatus, baseApplication.LastStatusDate, baseApplication.PaidFees,
                                                                      baseApplication.CreatedByUserID);
            }
            else
                return null;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsDataAccess.AddLocalLicenseApplication( this.LicenseClassID,  this.ApplicationID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateNewLocalDrivingLicenseApplication()
        {
             return clsLocalDrivingLicenseApplicationsDataAccess.UpdateLocalLicenseApplication( this.LocalDrivingLicenseApplicationID, this.LicenseClassID);
        }

        //public static bool DeleteLocalDrivingLicenseApplication(int LocalLicenseApplicationID)
        //{
        //    clsLocalDrivingLicenseApplicationsBusiness localApplication = clsLocalDrivingLicenseApplicationsBusiness.FindLocalLicenseApplicationByID(LocalLicenseApplicationID);

        //    if (localApplication != null && clsLocalDrivingLicenseApplicationsDataAccess.DeleteLocalDrivingLicenseApplication(localApplication.LocalDrivingLicenseApplicationID))
        //    {
        //        // local license has no tables connected to it so we delete it first then delete baseApplication (baseApplication will handle all tables connected to it)
        //        return clsApplicationsBusiness.DeleteApplicationByID(localApplication.ApplicationID);
        //    }
        //    else
        //        return false;
        //}

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetAllLocalDrivingLicenseApplications();
        }

        public new bool Save() // hiding base Save method
        {
            if (base.Save()) // adding or updating the baseApplication first then do the derived application
            {
                switch (_mode)
                {
                    case enMode.eAddMode:
                        if (_AddNewLocalDrivingLicenseApplication())
                        {
                            this._mode = enMode.eUpdateMode;
                            return true;
                        }
                        else
                            return false;

                    case enMode.eUpdateMode:
                        return _UpdateNewLocalDrivingLicenseApplication();

                    default: return false;
                }
            }
            else
                return false;
        }

        public static int GetActiveOrCompletedApplicationID(int ApplicantPersonID, int LicenseClassID)
        {
            int activeOrCompletedApplicationID = clsLocalDrivingLicenseApplicationsDataAccess.GetActiveOrCompletedApplicationID(ApplicantPersonID, LicenseClassID);
            return activeOrCompletedApplicationID;
        }
    }
}
