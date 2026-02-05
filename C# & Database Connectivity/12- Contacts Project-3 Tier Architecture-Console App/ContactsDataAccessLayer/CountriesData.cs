using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace ContactsDataAccessLayer
{
    public class clsCountriesDataAccess
    {

        public static bool getCountryInfo(int ID, ref string CountryName)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "select * from Countries where CountryID = @ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    CountryName = (string)reader["CountryName"];
                }

                reader.Close();
            }
            catch (Exception e)
            {
                //logs
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool getCountryInfo(string CountryName, ref int ID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "select * from Countries where CountryName = @Name;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", CountryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    ID = (int)reader["CountryID"];
                }

                reader.Close();
            }
            catch (Exception e)
            {
                //logs
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static int AddNewCountry(string CountryName)
        {
            int NewID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"insert into Countries
                             values (@CountryName);
                            select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int temp))
                {
                    NewID = temp;
                }
            }
            catch (Exception e)
            {
                // logs
            }
            finally
            {
                connection.Close();
            }
            return NewID;
        }

        public static bool UpdateCountry(int ID, string CountryName)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"update Countries
                             set CountryName = @Name
                             where CountryID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", CountryName);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // logs
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteCountry(int ID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"delete from Countries
                             where CountryID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // logs
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DoesExist(int ID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select found=1 from Countries
                             where CountryID = @ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                    IsFound = true;
            }
            catch (Exception e)
            {
                // logs
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool DoesExist(string CountryName)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select found=1 from Countries
                             where CountryName = @Name;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", CountryName);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                    IsFound = true;
            }
            catch (Exception e)
            {
                // logs
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static DataTable getAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "select * from Countries;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                else
                {
                    dt = null;
                }

                reader.Close();
            }
            catch (Exception e)
            {
                // logs
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }



}



