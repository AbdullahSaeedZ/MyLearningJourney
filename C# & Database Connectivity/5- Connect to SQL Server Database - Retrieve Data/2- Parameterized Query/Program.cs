using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

// SQL injection:
//  https://www.youtube.com/watch?v=AKwgjcvGWwg

public class Program
{
    static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=123456;";

    // Parameters are used to safely pass user-provided values into a SQL query,
    // preventing SQL injection and keeping values separate from the query logic
    // Example: WHERE FirstName = @FirstName (value is supplied separately)




    // 1 :
    static public void PrintRecordWithFirstName(string FirstName)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        // we can prepare the query with conditions, using concatenation:
        // string query = "select * from Contacts where FirstName = " + FirstName;
        // but this is risky, see sql injection video, and in EF there is more protection layers.
        // instead, we use a parameterized query (it contains parameter placeholders):
        // @FirstName is a placeholder in the SQL query; its value is supplied later.
        // This placeholder style is specific to SQL queries, not general strings.

        string query = "select * from Contacts where FirstName = @FirstName";
        SqlCommand command = new SqlCommand(query, connection);

        // since the query contains parameter placeholders, we must define them using this method:
        // placeholder name, then value of parameter (taken from function as argument)
        command.Parameters.AddWithValue("@FirstName", FirstName);


        // AddWithValue infers the parameter type automatically, which may be inaccurate in some cases.
        // Use the following approach when explicit typing is needed:
        // command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;

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
            Console.WriteLine("Error: " + e.Message);
        }
        finally
        {
            connection.Close();
        }

    }

    //2 :
    static public void PrintRecordWithFirstNameAndCountry(string FirstName, int CountryID)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string query = "select * from Contacts where FirstName = @FirstName and CountryID = @CountryID";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@FirstName", FirstName);
        command.Parameters.AddWithValue("@CountryID", CountryID);

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
                int countryID = (int)reader["CountryID"];

                Console.WriteLine("\n" + ContactID);
                Console.WriteLine(firstName);
                Console.WriteLine(LastName);
                Console.WriteLine(Email);
                Console.WriteLine(Phone);
                Console.WriteLine(Address);
                Console.WriteLine(countryID);
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
        //PrintRecordWithFirstName("Jane");
        PrintRecordWithFirstNameAndCountry("Jane", 1);
    }
}

