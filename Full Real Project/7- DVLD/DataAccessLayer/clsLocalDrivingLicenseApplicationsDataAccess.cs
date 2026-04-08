using System;
using System.Data;
using System.Data.SqlClient;

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

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = "select * from LocalDrivingLicenseApplications_View order by ApplicationDate desc;";

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




        public static int GetActiveOrCompletedApplicationID(int ApplicantPersonID, int LicenseClassID)
        {
            int activeOrCompletedApplicationID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    // business requires that new application of same class is allowed if no NEW application or COMPLETED application in system
                    // so only allowed condition is when no license application of same class created, or license application is cancelled
                    // here we check if there is applications other than cancelled
                    string query = @"select LocalDrivingLicenseApplicationID
                                     from LocalDrivingLicenseApplications 
                                     inner join Applications on LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                                     where LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID and Applications.ApplicantPersonID = @ApplicantPersonID and Applications.ApplicationStatus <> 2;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                        command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int id))
                            activeOrCompletedApplicationID = id;
                    }
                }
            }
            catch (Exception e)
            {
                // logs
                throw;
            }
            return activeOrCompletedApplicationID;
        }

    }
}
