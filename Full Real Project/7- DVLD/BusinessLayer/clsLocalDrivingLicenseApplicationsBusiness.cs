using System;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsLocalDrivingLicenseApplicationsBusiness : clsApplicationsBusiness
    {
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
        

        private int _licenseClassID;
        public int LicenseClassID
        {
            get
            {
                return _licenseClassID;
            }
            set
            {
                if (_licenseClassID == -1) // to prevent any modification
                    _licenseClassID = value;
            }
        }

        public clsLicenseClassesBusiness LicenseClassesInfo;

        public clsLocalDrivingLicenseApplicationsBusiness()
        {
            this._localDrivingLicenseApplicationID = -1;
            this._licenseClassID = -1;
        }


        clsLocalDrivingLicenseApplicationsBusiness(int LocalApplicationID, int LicenseClassID, int BaseApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID) 
            : base (BaseApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {
            this._localDrivingLicenseApplicationID = LocalApplicationID;
            this._licenseClassID = LicenseClassID;
            this.LicenseClassesInfo = clsLicenseClassesBusiness.Find(_licenseClassID); 
        }

        public static clsLocalDrivingLicenseApplicationsBusiness FindLocalLicenseApplicationByID(int LocalApplicationID)
        {
            int baseApplicationID = -1, licenseClassID = -1;
            if (clsLocalDrivingLicenseApplicationsDataAccess.FindLocalLicenseApplicationByID(LocalApplicationID, ref baseApplicationID, ref licenseClassID))
            {

                clsApplicationsBusiness baseApplication = clsApplicationsBusiness.FindBaseApplicationByID(baseApplicationID);

                return new clsLocalDrivingLicenseApplicationsBusiness(LocalApplicationID, licenseClassID, baseApplicationID, baseApplication.ApplicantPersonID, baseApplication.ApplicationDate,
                                                                      baseApplication.ApplicationTypeID, baseApplication.ApplicationStatus, baseApplication.LastStatusDate, baseApplication.PaidFees,
                                                                      baseApplication.CreatedByUserID);
            }
            else
                return null;
        }

        public static clsLocalDrivingLicenseApplicationsBusiness FindLocalLicenseApplicationByApplicationID(int BaseApplicationID)
        {
            int localApplicationID = -1, licenseClassID = -1;
            if (clsLocalDrivingLicenseApplicationsDataAccess.FindLocalLicenseApplicationByApplicationID(ref localApplicationID, BaseApplicationID, ref licenseClassID))
            {

                clsApplicationsBusiness baseApplication = clsApplicationsBusiness.FindBaseApplicationByID(BaseApplicationID);

                return new clsLocalDrivingLicenseApplicationsBusiness(localApplicationID, licenseClassID, BaseApplicationID, baseApplication.ApplicantPersonID, baseApplication.ApplicationDate,
                                                                      baseApplication.ApplicationTypeID, baseApplication.ApplicationStatus, baseApplication.LastStatusDate, baseApplication.PaidFees,
                                                                      baseApplication.CreatedByUserID);
            }
            else
                return null;
        }

    }
}
