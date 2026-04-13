using DataAccessLayer;
using System;
using System.Data;
using static BusinessLayer.clsApplicationTypesBusiness;

namespace BusinessLayer
{
    public class clsApplicationsBusiness
    {
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3}; 
        public enum enMode { eAddMode = 0, eUpdateMode = 1 };


        protected enMode _mode; // to use inside the derived class only
        public enApplicationStatus ApplicationStatus { set; get; } // will come from DB as numbers

        public int ApplicationID { get; private set; }

        private int _applicantPersonID;
        public int ApplicantPersonID
        {
            get
            {
                return _applicantPersonID;
            }
            set
            {
                if (_applicantPersonID == -1) // to prevent any modification and allow only new assignment from UI
                    _applicantPersonID = value;
            }
        }

        private enApplicationTypes _applicationTypeID;
        public enApplicationTypes ApplicationTypeID
        {
            get
            {
                return _applicationTypeID;
            }
            set
            {
                if (_applicationTypeID == 0) // to prevent any modification and allow only new assignment from UI
                    _applicationTypeID = value;
            }
        }

        private int _createdByUserID;
        public int CreatedByUserID
        {
            get
            {
                return _createdByUserID;
            }
            set
            {
                if (_createdByUserID == -1) // to prevent any modification and allow only new userID assignment
                    _createdByUserID = value;
            }
        }
        public DateTime LastStatusDate { get; private set; }
        public float PaidFees { get; set; }
        public DateTime ApplicationDate { get; private set; }

        public clsPeopleBusiness ApplicantPersonInfo;
        public clsApplicationTypesBusiness ApplicationTypeInfo;
        public clsUserBusiness CreatedByUserInfo;


        public clsApplicationsBusiness()
        {
            this.ApplicationID = -1;
            this._applicantPersonID = -1;
            this._applicationTypeID = 0;
            this.ApplicationDate = DateTime.MinValue;
            this.LastStatusDate = DateTime.MinValue;
            this.PaidFees = -1;
            this._createdByUserID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            _mode = enMode.eAddMode;
        }

        public clsApplicationsBusiness(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, enApplicationTypes ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this._applicantPersonID = ApplicantPersonID;
            this.ApplicantPersonInfo = clsPeopleBusiness.FindPerson(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this._applicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationTypesBusiness.FindApplicationType((enApplicationTypes)ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this._createdByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUserBusiness.FindUser(CreatedByUserID);
            _mode = enMode.eUpdateMode;
        }

        // this the base application, cuz will have derived applications of this 
        public static clsApplicationsBusiness FindBaseApplicationByID(int ApplicationID)
        {
            int applicantPersonID = -1, applicationTypeID = -1, createdByUserID = -1;
            byte applicationStatus = 1;
            DateTime applicationDate = DateTime.Now, lastStatusDate = DateTime.Now;
            float paidFees = -1;

            if (clsApplicationsDataAccess.FindApplicationByID(ApplicationID, ref applicantPersonID, ref applicationDate, ref applicationTypeID, ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID))
                return new clsApplicationsBusiness(ApplicationID, applicantPersonID, applicationDate, (enApplicationTypes)applicationTypeID, (enApplicationStatus)applicationStatus, lastStatusDate, paidFees, createdByUserID);
            else
                return null;
        }

        private bool _AddNewApplication()
        {
            // date of creating application is taken from Business layer (server) not the UI
            this.ApplicationID = clsApplicationsDataAccess.AddNewApplication(this.ApplicantPersonID, DateTime.Now, (int)this.ApplicationTypeID, (byte)this.ApplicationStatus, DateTime.Now, this.PaidFees, this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationsDataAccess.UpdateApplication(this.ApplicationID ,this.ApplicantPersonID, this.ApplicationDate, (int)this.ApplicationTypeID,
                                                                (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public static bool DeleteApplicationByID(int ApplicationID)
        {
            // must delete all related records in connected tables then delete the base application
            
            // logic 

            return clsApplicationsDataAccess.DeleteApplicationByID(ApplicationID);
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationsDataAccess.GetAllApplications();
        }


        public bool Save()
        {
            switch (_mode)
            {
                case enMode.eAddMode:
                    if (_AddNewApplication())
                    {
                        _mode = enMode.eUpdateMode;
                        return true;
                    }
                    else
                        return false;

                case enMode.eUpdateMode:
                    return _UpdateApplication();

                default: return false;
            }
        }



        public bool SetStatusToCancelled()
        {
            return clsApplicationsDataAccess.UpdateStatus(this.ApplicationID, (byte)enApplicationStatus.Cancelled, DateTime.Now);
        }

        public bool SetStatusToCompleted()
        {
            return clsApplicationsDataAccess.UpdateStatus(this.ApplicationID, (byte)enApplicationStatus.Completed, DateTime.Now);
        }


        

    }
}
