using System;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class clsDetainedLicensesDataAccess
    {
        public static bool FindByDetainID(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref float FineFees, ref int CreatedByUserID, ref bool IsReleased, 
                         ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = "select * from DetainedLicenses where DetainID = @ID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", DetainID);
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            LicenseID = (int)reader["LicenseID"];
                            DetainDate = (DateTime)reader["DetainDate"];
                            FineFees = Convert.ToSingle(reader["FineFees"]);
                            CreatedByUserID = reader["CreatedByUserID"] == DBNull.Value ? -1 : (int)reader["CreatedByUserID"]; 
                            IsReleased = Convert.ToBoolean(reader["IsReleased"]);
                            ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ReleaseDate"];
                            ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? -1 : (int)reader["ReleasedByUserID"];
                            ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? -1 : (int)reader["ReleaseApplicationID"];
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
        public static bool FindByLicenseID(ref int DetainID, int LicenseID, ref DateTime DetainDate, ref float FineFees, ref int CreatedByUserID, ref bool IsReleased,
                         ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = "select * from DetainedLicenses where LicenseID = @ID ;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", LicenseID);
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            LicenseID = (int)reader["LicenseID"];
                            DetainDate = (DateTime)reader["DetainDate"];
                            FineFees = Convert.ToSingle(reader["FineFees"]);
                            CreatedByUserID = reader["CreatedByUserID"] == DBNull.Value ? -1 : (int)reader["CreatedByUserID"];
                            IsReleased = Convert.ToBoolean(reader["IsReleased"]);
                            ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)reader["ReleaseDate"];
                            ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? -1 : (int)reader["ReleasedByUserID"];
                            ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? -1 : (int)reader["ReleaseApplicationID"];
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


        public static int AddNewDetainLicense(int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID, bool IsReleased,
                         DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int NewID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"insert into DetainedLicenses 
                                     values (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, 0, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID)
                                     select scope_identity();";
                                     
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", LicenseID);
                        command.Parameters.AddWithValue("@DetainDate", DetainDate);
                        command.Parameters.AddWithValue("@FineFees", FineFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@IsReleased", IsReleased);

                        if (ReleaseDate == DateTime.MinValue)
                            command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);

                        if (ReleasedByUserID == -1)
                            command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReleaseDate", ReleasedByUserID);

                        if (ReleaseApplicationID == -1)
                            command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReleaseDate", ReleaseApplicationID);

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


        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID, bool IsReleased,
                         DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"update DetainedLicenses 
                                     set LicenseID = @LicenseID, DetainDate = @DetainDate, FineFees = @FineFees, CreatedByUserID = @CreatedByUserID, 
                                     IsReleased = @IsReleased, ReleaseDate = @ReleaseDate, ReleasedByUserID = @ReleasedByUserID, ReleaseApplicationID = @ReleaseApplicationID
                                     where DetainID = @ID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", LicenseID);
                        command.Parameters.AddWithValue("@DetainDate", DetainDate);
                        command.Parameters.AddWithValue("@FineFees", FineFees);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@IsReleased", IsReleased);

                        if (ReleaseDate == DateTime.MinValue)
                            command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);

                        if (ReleasedByUserID == -1)
                            command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReleaseDate", ReleasedByUserID);

                        if (ReleaseApplicationID == -1)
                            command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReleaseDate", ReleaseApplicationID);

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

        public static bool ReleaseDetainedLicense(int LicenseID, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = @"update DetainedLicenses 
                                     set IsReleased = 1, ReleaseDate = @ReleaseDate, ReleasedByUserID = @ReleasedByUserID, ReleaseApplicationID = @ReleaseApplicationID
                                     where LicenseID = @ID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", LicenseID);
                        command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                        command.Parameters.AddWithValue("@ReleaseDate", ReleasedByUserID);
                        command.Parameters.AddWithValue("@ReleaseDate", ReleaseApplicationID);

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

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = "select Found = 1 from DetainedLicenses where LicenseID = @ID and IsReleased = 0;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", LicenseID);
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
      
      
        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    string query = "select * from DetainedLicenses;";
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
