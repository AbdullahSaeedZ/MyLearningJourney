using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsCountriesBusiness
    {
        public static DataTable GetAllCountries()
        {
            return clsCountriesDataAccess.GetAllCountries();
        }
        
        public static string GetCountryNameByID(int CountryID)
        {
            return clsCountriesDataAccess.GetCountryNameByID(CountryID);
        }

    }
}
