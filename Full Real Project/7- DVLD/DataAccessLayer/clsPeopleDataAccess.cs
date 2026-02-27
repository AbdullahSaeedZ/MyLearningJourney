using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace DataAccessLayer
{
    public class clsPeopleDataAccess
    {

        public static bool FindPerson(string Filter, ref int PersonID, ref string NationalID, ref string FirstName, ref string SecondName, ref string ThirdName,
                  ref string LastName, ref byte Gender, ref string Country, ref string Phone, ref string Email, ref string Address, ref string ImagePath, ref DateTime BirthDate)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();
                    string query = $@"select People.*, CountryName from People
                                    left join Countries on NationalityCountryID = Countries.CountryID
                                    where {Filter} = @ID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (Filter == "PersonID")
                            command.Parameters.AddWithValue("@ID", PersonID);
                        else
                            command.Parameters.AddWithValue("@ID", NationalID);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            PersonID = (int)reader["PersonID"];
                            NationalID = (string)reader["NationalNo"];
                            FirstName = (string)reader["FirstName"];
                            SecondName = (string)reader["SecondName"];
                            ThirdName = (string)reader["ThirdName"];
                            LastName = (string)reader["LastName"];
                            Gender = (byte)reader["Gender"];
                            Country = (string)reader["CountryName"];
                            Phone = (string)reader["Phone"];
                            Email = reader["Email"] == DBNull.Value ? string.Empty : (string)reader["Email"];
                            Address = (string)reader["Address"];
                            BirthDate = (DateTime)reader["DateOfBirth"];
                            ImagePath = reader["ImagePath"] == DBNull.Value ? string.Empty : (string)reader["ImagePath"];

                            isFound = true;
                        }
                    }
                }    
            }
            catch (Exception e)
            {
                throw;
            }

            return isFound;
        }


        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
                string query = @"select * from viewAllPeople;";

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
            return dt;
        }

        public static bool DoesExist(int ID, string filter)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();
                    string query = $@"select A=1 from People where {filter} = @ID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            isFound = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return isFound;
        }



    }
}
