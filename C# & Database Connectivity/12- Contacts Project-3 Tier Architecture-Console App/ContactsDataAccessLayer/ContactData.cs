using System;
using System.Data;
using System.Data.SqlClient;


// all methods here to be static, so we can call them with no objects


namespace ContactsDataAccessLayer
{
    public class clsContactDataAccess
    {

        public static bool getContactInfoByID(int ID, ref string FirstName, ref string LastName, ref string Email, ref string Phone, ref string Address,
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



        public static int AddNewContact(string FirstName, string LastName, string Email, string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            int NewID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"insert into Contacts
                             values(@FirstName, @LastName, @Email, @Phone, @Address, @DateOfBirth, @CountryID, @ImagePath);
                            select scope_identity();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue(@"FirstName", FirstName);
            command.Parameters.AddWithValue(@"LastName", LastName);
            command.Parameters.AddWithValue(@"Email", Email);
            command.Parameters.AddWithValue(@"Phone", Phone);
            command.Parameters.AddWithValue(@"Address", Address);
            command.Parameters.AddWithValue(@"DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue(@"CountryID", CountryID);

            // this column allows null, so if it is empty in adding phase, we send it to DB as null value.
            if (ImagePath != "")
                command.Parameters.AddWithValue(@"ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue(@"ImagePath", DBNull.Value);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int temp))
                    NewID = temp;

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

    }
}
