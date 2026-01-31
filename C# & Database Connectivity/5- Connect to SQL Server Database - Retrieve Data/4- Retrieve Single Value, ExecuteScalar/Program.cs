using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;




// to retrieve a single value we use a method called ExecuteScalar in the the command object
// it returns only one value of a column and record, example is  FirstName only or LastName only.

internal class Program
{

    static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=123456;";


    static string GetFirstName(int ContactID)
    {
        string FirstName = "Not Found";
        SqlConnection connection = new SqlConnection(connectionString);

        string query = "select FirstName from Contacts where ContactID = @Value";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Value", ContactID);


        try
        {
            connection.Open();

            // this returns value of first column of first record appear in the result set, even if result set contains 1000 records.
            // we use Object Type to store value returned which is unknown for now, might be int or string so we use Object type,
            // if no value found it will be null

            // object type
            // In C#, object is the base type for all types.
            // It can reference any type of value, such as string, int, double, etc.

            Object result = command.ExecuteScalar();


            // DBNull.Value represents a NULL value coming from the database
            // null is the absence of an object reference in CLR / C#

            if (result != null && result != DBNull.Value)   
            {
                FirstName = result.ToString();
            }
         
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        finally
        {
            connection.Close();
        }

        return FirstName;
    }

    static void Main(string[] args)
    {

        Console.WriteLine(GetFirstName(1));

    }
}

