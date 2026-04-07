using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsUserDataAccess
    {

        public static bool FindUser(string Username, string Password, ref int UserID, ref int PersonID, ref bool isActive, ref int Permissions)
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
                            Permissions = (int)reader["Permissions"];
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
        public static bool FindUser(int UserID, ref string Username, ref string Password, ref int PersonID, ref bool IsActive, ref int Permissions)
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
                            Permissions = (int)reader["Permissions"];
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
        public static int AddNewUser(int PersonID, string Username, string Password, bool IsActive, int Permissions)
        {
            int NewID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"insert into Users 
                                     values (@PersonID, @Username, @Password, @IsActive, @Permissions);
                                     select scope_identity();";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@Permissions", Permissions);

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

        public static bool UpdateUser(int UserID, string Username, string Password, bool IsActive, int Permissions)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"update Users 
                                     set UserName = @Username, Password = @Password, IsActive = @IsActive, Permissions = @Permissions
                                     where UserID = @ID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", UserID);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@Permissions", Permissions);

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

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"update Users 
                                     set Password = @NewPassword
                                     where UserID = @ID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", UserID);
                        command.Parameters.AddWithValue("@NewPassword", NewPassword);

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
                // referential integrity will cause exception
                return false;
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
                    string query = "select * from ListUsers_View;";
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
