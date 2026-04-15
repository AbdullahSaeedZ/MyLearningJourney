using DataAccessLayer;
using System;
using System.Data;
using static BusinessLayer.clsApplicationTypesBusiness;
using static BusinessLayer.clsTestTypesBusiness;

namespace BusinessLayer
{
    public class clsLocalDrivingLicenseApplicationsBusiness : clsApplicationsBusiness
    {
        // hiding base _mode cuz when adding new application, the base mode will switch to update then sub Save method will go directly to update
        private new enMode _mode;

        public class clsTestsStatus
        {
            // will be fetched from DB then assigned here directly, no need for outside assignment
            public bool IsVisionTestPassed { get; private set; }
            public bool IsWrittenTestPassed { get; private set; }
            public bool IsStreetTestPassed { get; private set; }
            public int PassedTestsCount { get; private set; }

            public clsTestsStatus(bool Vision, bool Written, bool Street)
            {
                this.IsVisionTestPassed = Vision;
                this.IsWrittenTestPassed = Written;
                this.IsStreetTestPassed = Street;
                this.PassedTestsCount = IsStreetTestPassed? 3: IsWrittenTestPassed ? 2 : IsVisionTestPassed ? 1: 0;
            }
        }
        public clsTestsStatus TestsStatus { get; private set; }


        public int LocalDrivingLicenseApplicationID { get; private set; }
        public int LicenseClassID { get; set; }

        public clsLicenseClassesBusiness LicenseClassInfo;

        public clsLocalDrivingLicenseApplicationsBusiness()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;
            this._mode = enMode.eAddMode;
        }

        clsLocalDrivingLicenseApplicationsBusiness(int LocalApplicationID, int LicenseClassID, int ApplicationID, bool IsVisionTestPassed, bool IsWrittenTestPassed, bool IsStreetTestPassed,
            int ApplicantPersonID, DateTime ApplicationDate, enApplicationTypes ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
            : base(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
        {
            this.LocalDrivingLicenseApplicationID = LocalApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClassesBusiness.Find(LicenseClassID);
            this.TestsStatus = new clsTestsStatus(IsVisionTestPassed, IsWrittenTestPassed, IsStreetTestPassed);
            this._mode = enMode.eUpdateMode;
        }

        public static clsLocalDrivingLicenseApplicationsBusiness FindLocalLicenseApplicationByID(int LocalApplicationID)
        {
            int ApplicationID = -1, licenseClassID = -1;
            bool Vision = false, Written = false, Street = false;
            if (clsLocalDrivingLicenseApplicationsDataAccess.FindLocalLicenseApplicationByID(LocalApplicationID, ref ApplicationID, ref licenseClassID, ref Vision, ref Written, ref Street))
            {

                clsApplicationsBusiness baseApplication = clsApplicationsBusiness.FindBaseApplicationByID(ApplicationID);

                return new clsLocalDrivingLicenseApplicationsBusiness(LocalApplicationID, licenseClassID, ApplicationID, Vision, Written, Street, baseApplication.ApplicantPersonID, baseApplication.ApplicationDate,
                                                                      baseApplication.ApplicationTypeID, baseApplication.ApplicationStatus, baseApplication.LastStatusDate, baseApplication.PaidFees,
                                                                      baseApplication.CreatedByUserID);
            }
            else
                return null;
        }


        public static clsLocalDrivingLicenseApplicationsBusiness FindLocalLicenseApplicationByApplicationID(int ApplicationID)
        {
            int localApplicationID = -1, licenseClassID = -1;
            bool Vision = false, Written = false, Street = false;
            if (clsLocalDrivingLicenseApplicationsDataAccess.FindLocalLicenseApplicationByApplicationID(ref localApplicationID, ApplicationID, ref licenseClassID, ref Vision, ref Written, ref Street))
            {

                clsApplicationsBusiness baseApplication = clsApplicationsBusiness.FindBaseApplicationByID(ApplicationID);

                return new clsLocalDrivingLicenseApplicationsBusiness(localApplicationID, licenseClassID, ApplicationID, Vision, Written, Street, baseApplication.ApplicantPersonID, baseApplication.ApplicationDate,
                                                                      baseApplication.ApplicationTypeID, baseApplication.ApplicationStatus, baseApplication.LastStatusDate, baseApplication.PaidFees,
                                                                      baseApplication.CreatedByUserID);
            }
            else
                return null;
        }

       
        

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsDataAccess.AddLocalLicenseApplication(this.LicenseClassID, this.ApplicationID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.UpdateLocalLicenseApplication(this.LocalDrivingLicenseApplicationID, this.LicenseClassID);
        }

        //public static bool DeleteLocalDrivingLicenseApplication(int LocalLicenseApplicationID)
        //{

        //    if (clsLocalDrivingLicenseApplicationsDataAccess.DeleteLocalDrivingLicenseApplication(LocalLicenseApplicationID))
        //    {
        //        // local license has no tables connected to it so we delete it first then delete baseApplication (baseApplication will handle all tables connected to it)
        //        return clsApplicationsBusiness.DeleteApplicationByID(LocalLicenseApplicationID);
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
                switch (this._mode)
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
                        return _UpdateLocalDrivingLicenseApplication();

                    default: return false;
                }
            }
            else
                return false;
        }

        public static int GetActiveApplicationID(int ApplicantPersonID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetActiveApplicationID(ApplicantPersonID, LicenseClassID);
        }

        // if issuing license replacements is not linked to local driiving applications, then see where this method fits 
        public int IssueNewLicense(string Notes)
        {
            if (this.TestsStatus.PassedTestsCount < 3 || IsLicenseIssued())
                return -1;

            // we check if person is listed as driver, cuz person can be listed as driver only once in the system
            clsDriversBusiness NewDriver = clsDriversBusiness.FindByPersonID(this.ApplicantPersonID);

            if (NewDriver == null)
            {
                // adding driver record first, cuz new license record requires a driver id
                NewDriver = new clsDriversBusiness();
                NewDriver.PersonID = this.ApplicantPersonID;
                NewDriver.CreatedByUserID = clsBusinessSettings.CurrentUser.UserID;

                if (NewDriver.Save())
                {
                    clsLicensesBusiness NewLicense = new clsLicensesBusiness();

                    NewLicense.ApplicationID = this.ApplicationID;
                    NewLicense.DriverID = NewDriver.DriverID;
                    NewLicense.Notes = Notes;
                    NewLicense.CreatedByUserID = clsBusinessSettings.CurrentUser.UserID;
                    NewLicense.IssueReason = clsLicensesBusiness.enIssueReason.FirstTime;
                    NewLicense.IsActive = true;
                    NewLicense.LicenseClassID = this.LicenseClassID;
                    NewLicense.PaidFees = this.PaidFees; // this is the local driving application fees

                    if (NewLicense.Save())
                        return NewLicense.LicenseID;
                    else
                        return -1;
                }
                else
                    return -1;
            }
            else
                return -1;
        }


        public bool DoesHaveAnyAppointmentsRecords()
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.DoesHaveAnyAppointmentsRecords(this.LocalDrivingLicenseApplicationID);
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {
            return clsLicensesBusiness.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }

        public bool IsThereActiveTestAppointment(enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.IsThereActiveTestAppointment(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public clsTestsBusiness GetLastTestPerTestType(enTestType TestTypeID)
        {
            return clsTestsBusiness.FindLastTestPerPersonAndLicenseClass(this.ApplicantPersonID, this.LicenseClassID, TestTypeID);
        }

        public int GetTotalTestTrialsPerTestType(enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetTotalTestTrialsPerTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


    }
}
