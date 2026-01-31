using System;
using System.Data.Common;
using System.Data.SqlClient;

// there is another better solution , Table-Valued Parameter, but will be explained later.

public class Program
{

    static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=123456;";


    // never concatenate user input into SQL, use parameters for values to prevent SQL Injection.
    static public void deleteRecordFromDatabaseUsingIN(int[] IDsRange)
    {
        // to prevent wrong query
        if (IDsRange == null || IDsRange.Length == 0)
        {
            Console.WriteLine("Range is empty");
            return;
        }


        SqlConnection connection = new SqlConnection(connectionString);

        // prepare array of placeholders strings to be placed in the query
        string[] placeholders = new string[IDsRange.Length];

        for (int i = 0; i < placeholders.Length; i++)
        {
            placeholders[i] = $"@ID{i}";
        }

        // join method will write each element with separator in between, all as string.
        string query = $@"delete from Contacts
                         where ContactID in ({string.Join(",", placeholders)});";  // will be like this -> ...ContactID in (@ID0, @ID1, @ID2);


        SqlCommand command = new SqlCommand(query, connection);

        // now add values from IDs array to replace the placeholders as parameters:
        for (int i = 0; i < placeholders.Length; i++)
        {
            command.Parameters.AddWithValue($"@ID{i}", IDsRange[i]);
        }


        try
        {
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();  // non query, cuz we arent querying, we are updating, this method returns int of how many affected rows

            if (rowAffected > 0)
                Console.WriteLine("Records Deleted!");
            else
                Console.WriteLine("Records were not Deleted!");

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
        // prepare the range of IDs as an array or List if dynamic input needed.
        int[] IDsRange = {2,3};
        deleteRecordFromDatabaseUsingIN(IDsRange);

    }
}