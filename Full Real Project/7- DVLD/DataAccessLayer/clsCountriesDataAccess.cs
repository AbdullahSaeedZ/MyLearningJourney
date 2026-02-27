using System;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class clsCountriesDataAccess
    {

        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = "select CountryName from Countries;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                            dt.Load(reader);
                        else
                            dt = null;
                    }
                }

            } catch (Exception e)
            {
                throw;
            }
            return dt;
        }

    }
}
