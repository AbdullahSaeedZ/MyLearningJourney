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
        public string Code{ get; set; }
        public string PhoneCode { get; set; }

        public clsCountries()
        {
            this.ID = -1;
            this.CountryName = "";
            this.Code = "";
            this.PhoneCode = "";
            this.Mode = enMode.eAddNew;
        }

        clsCountries(int ID, string CountryName, string Code, string PhoneCode)
        {
            this.ID = ID;
            this.CountryName = CountryName;
            this.Code = Code;
            this.PhoneCode = PhoneCode;
            this.Mode = enMode.eUpdate;
        }


        public static clsCountries Find(int ID)
        {
            string CountryName = "", Code = "", PhoneCode = "";

            if (clsCountriesDataAccess.getCountryInfo(ID, ref CountryName, ref Code, ref PhoneCode))
            {
                return new clsCountries(ID, CountryName, Code, PhoneCode);
            }
            else
                return null;

        }
        public static clsCountries Find(string CountryName)
        {
            int ID = -1;
            string Code = "", PhoneCode = "";

            if (clsCountriesDataAccess.getCountryInfo(CountryName, ref ID, ref Code, ref PhoneCode))
            {
                return new clsCountries(ID, CountryName, Code, PhoneCode);
            }
            else
                return null;

        }

        bool _AddNewCountry()
        {
            this.ID = clsCountriesDataAccess.AddNewCountry(this.CountryName, this.Code, this.PhoneCode);
            return (this.ID != -1);
        }

        bool _UpdateCountry()
        {
            return clsCountriesDataAccess.UpdateCountry(this.ID, this.CountryName, this.Code, this.PhoneCode);
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
        public static bool DoesExist(string CountryName)
        {
            return clsCountriesDataAccess.DoesExist(CountryName);
        }

        public static DataTable getAllCountries()
        {
            return clsCountriesDataAccess.getAllCountries();
        }

    }
}
