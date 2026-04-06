using System;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    public class clsLocalDrivingLicenseApplicationsDataAccess
    {
        public static bool FindLocalLicenseApplicationByID(int LocalApplicationID, ref int baseApplicationID, ref int licenseClassID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"select * from LocalDrivingLicenseApplications
                                 where LocalDrivingLicenseApplicationID = @ID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", LocalApplicationID);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            baseApplicationID = (int)reader["ApplicationID"];
                            licenseClassID = (int)reader["LicenseClassID"];
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

        public static bool FindLocalLicenseApplicationByApplicationID(ref int LocalApplicationID,  int baseApplicationID, ref int licenseClassID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"select * from LocalDrivingLicenseApplications
                                 where ApplicationID = @ID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", baseApplicationID);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            LocalApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                            licenseClassID = (int)reader["LicenseClassID"];
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

        public static int AddLocalLicenseApplication(int licenseClassID, int applicationID)
        {
            int newID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"insert into LocalDrivingLicenseApplications
                                     values ( @ApplicationID, @LicenseClassID);
                                     select scope_identity();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicationID", applicationID);
                        command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int id))
                            newID = id;
                    }
                }
            }
            catch (Exception e)
            {
                // logs
                throw;
            }
            return newID;
        }

        public static bool UpdateLocalLicenseApplication( int LocalApplicationID, int licenseClassID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"update LocalDrivingLicenseApplications
                                     set LicenseClassID = @LicenseClassID
                                     where LocalDrivingLicenseApplicationID = @ID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", LocalApplicationID);
                        command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);

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

    }
}
