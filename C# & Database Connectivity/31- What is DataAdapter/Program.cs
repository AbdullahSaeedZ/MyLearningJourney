/*
 In C#, a DataAdapter is a class that acts as a bridge between a DataSet and a data source, such as a database.
It provides methods for populating a DataSet with data from the data source and updating the data source with changes made to the DataSet.
 
 𝗗𝗮𝘁𝗮𝗯𝗮𝘀𝗲  <---->  DataAdapter  <---->  𝗗𝗮𝘁𝗮𝗦𝗲𝘁

More Detailed:

𝗗𝗮𝘁𝗮𝗦𝗼𝘂𝗿𝗰𝗲 → DataAdapter → 𝗗𝗮𝘁𝗮𝗦𝗲𝘁 → 𝗗𝗮𝘁𝗮𝗧𝗮𝗯𝗹𝗲 → 𝗗𝗮𝘁𝗮𝗩𝗶𝗲𝘄
 */

using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {

        string connectionString = "Server=.;Database=HR_Database;User Id=sa;Password=123456;";

        // Create a new DataSet
        DataSet dataSet = new DataSet();

        // Create a new DataAdapter with a SELECT query and the connection string
        string query = "SELECT * FROM Employees;";
        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connectionString);

        // Open the connection
        SqlConnection connection = new SqlConnection(connectionString);

        // start the process, skipped try-catch just to show the steps :)
        connection.Open();

        // Set the SelectCommand of the DataAdapter to the connection
        dataAdapter.SelectCommand.Connection = connection;

        // Fill the DataSet with data from the data source, it will create the DataTable and fill everything automatically
        dataAdapter.Fill(dataSet, "Employees");

        connection.Close();

        // Display the data from the DataSet
        DataTable customersTable = dataSet.Tables["Employees"];
        foreach (DataRow row in customersTable.Rows)
        {
            Console.WriteLine("Customer ID: {0}, Name: {1}, LastName: {2}", row["ID"], row["FirstName"], row["LastName"]);
        }




        /*

        // Make changes to the DataSet (add, modify, or delete rows)
        //
        //
        //

        // Update the data source with the changes made to the DataSet
        connection.Open();

        // Set the UpdateCommand of the DataAdapter to the connection
        dataAdapter.UpdateCommand.Connection = connection;

        // Update the data source with the changes
        dataAdapter.Update(dataSet, "Employees");

        connection.Close();
        */
    }
}