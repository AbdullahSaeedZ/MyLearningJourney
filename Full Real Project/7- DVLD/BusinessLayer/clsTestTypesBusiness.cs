using DataAccessLayer;
using System.Data;


namespace BusinessLayer
{
    public class clsTestTypesBusiness
    {
        enum enMode { eAddMode = 0, eUpdateMode = 1 }; // no need for adding functionality for now, but might add later
        enMode _mode;

        private int _testTypeID = -1;
        public int TestTypeID
        {
            get
            {
                return _testTypeID;
            }

            set
            {
                if (_testTypeID == -1)
                    _testTypeID = value;
            }
        }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        clsTestTypesBusiness(int ID, string Title, string Description, decimal Fees)
        {
            this.TestTypeID = ID;
            this.TestTypeTitle = Title;
            this.TestTypeDescription = Description;
            this.TestTypeFees = Fees;
            _mode = enMode.eUpdateMode;
        }

        public static clsTestTypesBusiness FindTestType(int ID)
        {
            string TestTypeTitle = "", TestTypeDescription = "";
            decimal TestTypeFees = -1;

            if (clsTestTypesDataAccess.FindTestType(ID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
                return new clsTestTypesBusiness(ID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            else
                return null;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesDataAccess.GetAllTestTypes();
        }

        private bool _UpdateTestType()
        {
            return clsTestTypesDataAccess.UpdateTestType(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }

        public bool Save()
        {
            switch (_mode)
            {
                case enMode.eAddMode:
                    _mode = enMode.eUpdateMode;
                    return false; // to be added when needed

                case enMode.eUpdateMode:
                    return _UpdateTestType();

                default: return false;
            }
        }
    }
}
