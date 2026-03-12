using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsUserDataAccess
    {

        public static bool FindUser(string Username, string Password, ref int UserID, ref int PersonID, ref bool isActive)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = "select * from Users where UserName = @Username and Password = @Password;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            UserID = (int)reader["UserID"];
                            PersonID = (int)reader["PersonID"];
                            isActive = (bool)reader["IsActive"];
                            isFound = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // logs
                throw;
            }
            return isFound;
        }
        public static bool FindUser(int UserID, ref string Username, ref string Password, ref int PersonID, ref bool IsActive)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = "select * from Users where UserID = @ID ;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", UserID);
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            PersonID = (int)reader["PersonID"];
                            Username = (string)reader["UserName"];
                            Password = (string)reader["Password"];
                            IsActive = (bool)reader["IsActive"];
                            isFound = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // logs
                throw;
            }
            return isFound;
        }
        public static int AddNewUser(int PersonID, string Username, string Password, bool IsActive)
        {
            int NewID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"insert into Users 
                                     values (@PersonID, @Username, @Password, @IsActive);
                                     select scope_identity();";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int ID))
                            NewID = ID;
                    }
                }
            }
            catch (Exception e)
            {
                // logs
                throw;
            }
            return NewID;
        }

        public static bool UpdateUser(int UserID, string Username, string Password, bool IsActive)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"update Users 
                                     set UserName = @Username, Password = @Password, IsActive = @IsActive)
                                     where UserID = @ID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                // logs
                throw;
            }
            return (rowsAffected > 0);
        }

        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = "delete from Users where UserID = @ID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", UserID);
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                // logs
                throw;
            }
            return (rowsAffected > 0);
        }
        public static bool DoesUsernameExist(string Username)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = "select Found = 1 from Users where Username = @Username;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                            isFound = true;
                    }
                }
            }
            catch (Exception e)
            {
                // logs
                throw;
            }
            return isFound;
        }
        public static bool DoesUserExist(int PersonID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = "select Found = 1 from Users where PersonID = @ID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", PersonID);
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                            isFound = true;
                    }
                }
            }
            catch (Exception e)
            {
                // logs
                throw;
            }
            return isFound;
        }

        public static bool DoesUserExist(string NationalNo)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = "select Found = 1 from Users where NationalNo = @ID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", NationalNo);
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                            isFound = true;
                    }
                }
            }
            catch (Exception e)
            {
                // logs
                throw;
            }
            return isFound;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = "select * from viewListUsers;";
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
            }
            catch (Exception e)
            {
                // logs
                throw;
            }
            return dt;
        }


    }
}
