using System;
using System.Data;
using DataAccessLayer;

// do local license classes then do the local licenses applications layers -----------------------------------------------------------------------------------------------

namespace BusinessLayer
{
    public class clsApplicationsBusiness
    {
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3}; 
        enum enMode { eAddMode = 0, eUpdateMode = 1 };


        enMode _mode;
        public enApplicationStatus ApplicationStatus { set; get; } // will come from DB as numbers


        private int _applicationID;
        public int ApplicationID 
        {
            get
            {
                return _applicationID;
            }
            set
            {
                if (_applicationID == -1) // to prevent any modification and allow only new application creation
                    _applicationID = value;
            }
        }


        private int _applicantPersonID;
        public int ApplicantPersonID
        {
            get
            {
                return _applicantPersonID;
            }
            set
            {
                if (_applicantPersonID == -1) // to prevent any modification and allow only new application person ID assignment
                    _applicantPersonID = value;
            }
        }

        public clsPeopleBusiness ApplicantPersonInfo;


        private int _applicationTypeID;
        public int ApplicationTypeID
        {
            get
            {
                return _applicationTypeID;
            }
            set
            {
                if (_applicationTypeID == -1) // to prevent any modification and allow only new application type assignment
                    _applicationTypeID = value;
            }
        }
        public clsApplicationTypesBusiness ApplicationTypeInfo;

       

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
        public clsUserBusiness CreatedByUserInfo;

        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public DateTime ApplicationDate { get; set; }


        public clsApplicationsBusiness()
        {
            this._applicationID = -1;
            this._applicantPersonID = -1;
            this._applicationTypeID = -1;
            this.ApplicationDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            _mode = enMode.eAddMode;
        }

        clsApplicationsBusiness(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this._applicationID = ApplicationID;
            this._applicantPersonID = ApplicantPersonID;
            this.ApplicantPersonInfo = clsPeopleBusiness.FindPerson(_applicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this._applicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationTypesBusiness.FindApplicationType(_applicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUserBusiness.FindUser(CreatedByUserID);
            _mode = enMode.eUpdateMode;
        }

        public static clsApplicationsBusiness FindApplicationByID(int ApplicationID)
        {
            int applicantPersonID = -1, applicationTypeID = -1, createdByUserID = -1;
            byte applicationStatus = 1;
            DateTime applicationDate = DateTime.Now, lastStatusDate = DateTime.Now;
            float paidFees = -1;

            if (clsApplicationsDataAccess.FindApplicationByID(ApplicationID, ref applicantPersonID, ref applicationDate, ref applicationTypeID, ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID))
                return new clsApplicationsBusiness(ApplicationID, applicantPersonID, applicationDate, applicationTypeID, (enApplicationStatus)applicationStatus, lastStatusDate, paidFees, createdByUserID);
            else
                return null;
        }

        private bool AddNewApplication()
        {
            int newID = clsApplicationsDataAccess.AddNewApplication(this._applicantPersonID, this.ApplicationDate, this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return (newID != -1);
        }

        private bool UpdateApplication()
        {
            return clsApplicationsDataAccess.UpdateApplication(this.ApplicationID ,this._applicantPersonID, this.ApplicationDate, this.ApplicationTypeID,
                                                                (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public static bool DeleteApplicationByID(int ApplicationID)
        {
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
                    if (AddNewApplication())
                    {
                        _mode = enMode.eUpdateMode;
                        return true;
                    }
                    else
                        return false;

                case enMode.eUpdateMode:
                    return UpdateApplication();

                default: return false;
            }
        }

    }
}
