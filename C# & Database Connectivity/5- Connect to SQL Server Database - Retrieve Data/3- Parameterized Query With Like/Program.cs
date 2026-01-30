using System;
using System.ComponentModel;
using System.Data.SqlClient;




internal class Program
{

    static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=123456;";


    static public void PrintRecordWithNameStartsWith(string StartsWith)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        string query = "select * from Contacts where FirstName like @Value";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Value", StartsWith + "%");  // here add the wildcard


        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                int ContactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string Address = (string)reader["Address"];
                int CountryID = (int)reader["CountryID"];

                Console.WriteLine("\n" + ContactID);
                Console.WriteLine(firstName);
                Console.WriteLine(LastName);
                Console.WriteLine(Email);
                Console.WriteLine(Phone);
                Console.WriteLine(Address);
                Console.WriteLine(CountryID);

            }

            reader.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
    }

    static public void PrintRecordWithNameEndsWith(string EndsWith)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        string query = "select * from Contacts where FirstName like @Value";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Value","%" + EndsWith);  // here add the wildcard


        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                int ContactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string Address = (string)reader["Address"];
                int CountryID = (int)reader["CountryID"];

                Console.WriteLine("\n" + ContactID);
                Console.WriteLine(firstName);
                Console.WriteLine(LastName);
                Console.WriteLine(Email);
                Console.WriteLine(Phone);
                Console.WriteLine(Address);
                Console.WriteLine(CountryID);

            }

            reader.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
    }

    static public void PrintRecordWithNameContains(string Contains)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        string query = "select * from Contacts where FirstName like @Value";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Value", "%" + Contains + "%");  // here add the wildcard


        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                int ContactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string Address = (string)reader["Address"];
                int CountryID = (int)reader["CountryID"];

                Console.WriteLine("\n" + ContactID);
                Console.WriteLine(firstName);
                Console.WriteLine(LastName);
                Console.WriteLine(Email);
                Console.WriteLine(Phone);
                Console.WriteLine(Address);
                Console.WriteLine(CountryID);

            }

            reader.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
    }



    static void Main(string[] args)
    {
        Console.WriteLine("\nRecords Start with J");
        PrintRecordWithNameStartsWith("J");

        Console.WriteLine("\n-----------------------\nRecords end with n");
        PrintRecordWithNameEndsWith("n");


        Console.WriteLine("\n-----------------------\nRecords contain mi");
        PrintRecordWithNameContains("mi");
    }
}

