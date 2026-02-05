using System;
using System.Data;
using System.Data.SqlClient;
using ContactsDataAccessLayer;

namespace ContactsBusinessLayer
{
    public class clsCountries
    {
        enum enMode { eAddNew = 0, eUpdate = 1};
        enMode Mode = enMode.eAddNew;

        public int ID { get; set; }
        public string CountryName { get; set; }

        public clsCountries()
        {
            this.ID = -1;
            this.CountryName = "";
            this.Mode = enMode.eAddNew;
        }

        clsCountries(int ID, string CountryName)
        {
            this.ID = ID;
            this.CountryName = CountryName;
            this.Mode = enMode.eUpdate;
        }


        public static clsCountries Find(int ID)
        {
            string CountryName = "";

            if (clsCountriesDataAccess.getCountryInfoByID(ID, ref CountryName))
            {
                return new clsCountries(ID, CountryName);
            }
            else
                return null;

        }

        bool _AddNewCountry()
        {
            this.ID = clsCountriesDataAccess.AddNewCountry(this.CountryName);
            return (this.ID != -1);
        }

        bool _UpdateCountry()
        {
            return clsCountriesDataAccess.UpdateCountry(this.ID, this.CountryName);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.eAddNew:
                    if (_AddNewCountry())
                    {
                        Mode = enMode.eUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.eUpdate:
                    return _UpdateCountry();

                default: return false;
            }
        }
            
        public static bool DeleteCountry(int ID)
        {
            return clsCountriesDataAccess.DeleteCountry(ID);
        }

        public static bool DoesExist(int ID)
        {
            return clsCountriesDataAccess.DoesExist(ID);
        }

        public static DataTable getAllCountries()
        {
            return clsCountriesDataAccess.getAllCountries();
        }

    }
}
