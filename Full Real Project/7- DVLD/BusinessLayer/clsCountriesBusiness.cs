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
    }
}
