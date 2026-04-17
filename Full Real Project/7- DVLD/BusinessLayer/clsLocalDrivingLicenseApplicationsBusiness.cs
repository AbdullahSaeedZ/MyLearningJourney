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

        public clsLicenseClassesBusiness LicenseClassInfo
        {
            get
            {
                return clsLicenseClassesBusiness.Find(LicenseClassID);
            }
        }

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

        // override incase of upcasting multiple applications in a list then do a loop (like in IT401)
        public override bool DeleteApplication()
        {
            if (this.ApplicationStatus != enApplicationStatus.New)
                return false;

            // if no records of other tables linked to this local application, then we delete it then delete baseApplication
            if (clsLocalDrivingLicenseApplicationsDataAccess.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID))
                return base.DeleteApplication();
            else
                return false;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetAllLocalDrivingLicenseApplications();
        }

        public override bool Save() // override base Save method
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

        public static int GetActiveLocalApplicationID(int ApplicantPersonID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetActiveLocalApplicationID(ApplicantPersonID, LicenseClassID);
        }

        // if issuing license replacements is not linked to local driiving applications, then see where this method fits 
        public int IssueNewLicense(string Notes, int CreatedByUserID)
        {
            if (this.TestsStatus.PassedTestsCount < 3 || IsLicenseIssued())
                return -1;

            // we check if person is listed as driver, cuz person can be listed as driver only once in the system
            // if person is already a driver, then use his driver id in the new license (licenses of different class for one driver)

            int DriverID = -1;
            clsDriversBusiness Driver = clsDriversBusiness.FindByPersonID(this.ApplicantPersonID);

            if (Driver == null)
            {
                // adding driver record first, cuz new license record requires a driver id
                Driver = new clsDriversBusiness();
                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID; 

                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                    return -1;
            }
            else
                DriverID = Driver.DriverID;

            clsLicensesBusiness NewLicense = new clsLicensesBusiness();

            NewLicense.ApplicationID = this.ApplicationID;
            NewLicense.DriverID = DriverID;
            NewLicense.Notes = Notes;
            NewLicense.CreatedByUserID = CreatedByUserID;
            NewLicense.IssueReason = clsLicensesBusiness.enIssueReason.FirstTime;
            NewLicense.IsActive = true;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.PaidFees = this.PaidFees; // this is the local driving application fees

            if (NewLicense.Save()) // DAL will auto set application status as complete
            {
                this.ApplicationStatus = enApplicationStatus.Completed; // this only for the object
                return NewLicense.LicenseID;
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
