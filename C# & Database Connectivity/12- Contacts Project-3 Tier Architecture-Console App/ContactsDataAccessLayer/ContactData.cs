using System;
using System.Data;
using System.Data.SqlClient;

namespace ContactsDataAccessLayer
{
    public class clsContactDataAccess
    {

        static public bool getContactInfoByID(int ID, ref string FirstName, ref string LastName, ref string Email, ref string Phone, ref string Address,
            ref DateTime DateOfBirth, ref int CountryID, ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"select * from Contacts where ContactID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["LastName"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    ImagePath = reader["ImagePath"] == DBNull.Value ? "Null" :(string)reader["ImagePath"];   // do this to all columns that allow null, otherwise it will throw exception.
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    CountryID = (int)reader["CountryID"];

                }

                reader.Close();
            }
            catch (Exception e)
            {
                // no printing here!!! this is data layer not presentation layer, here we save logs of errors in a log file, explained later.
                // Console.WriteLine("error " + e.Message);
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

    }
}
