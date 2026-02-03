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
            if (string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue(@"ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"ImagePath", ImagePath);

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

        public static bool UpdateContact(int ID, string FirstName, string LastName, string Email, string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"update Contacts
                            set FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Address = @Address, DateOfBirth = @DateOfBirth, CountryID = @CountryID, ImagePath = @ImagePath
                            where ContactID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue(@"ID", ID);
            command.Parameters.AddWithValue(@"FirstName", FirstName);
            command.Parameters.AddWithValue(@"LastName", LastName);
            command.Parameters.AddWithValue(@"Email", Email);
            command.Parameters.AddWithValue(@"Phone", Phone);
            command.Parameters.AddWithValue(@"Address", Address);
            command.Parameters.AddWithValue(@"DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue(@"CountryID", CountryID);
            if (string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue(@"ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue(@"ImagePath", ImagePath);

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

        public static bool DeleteContact(int ID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = @"delete from Contacts where ContactID = @ID";
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

        public static DataTable GetAllContacts()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "select * from Contacts;";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                // reader will open the connection, take records,and we print them then close connection and we are done with it. 
                // we use datatable to take all records from reader and keep the table with us even though reader and connection are closed. 
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader); // takes all rows from reader into data table
                }

                reader.Close();

            }
            catch (Exception e)
            {
                // logs
                dt = null;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool DoesExist(int ID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string query = "select found = 1 from Contacts where ContactID = @ID";   // found = 1 is just to avoid returning all columns, cuz i only need to know is there a record or not, not the data itself
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



    }
}
