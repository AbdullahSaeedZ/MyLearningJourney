using System;
using System.Data.SqlClient;    // first step to connect to a database is to use SQL Server Data Provider



public class Program
{
    // connection string is the details of the connection and which database to connect.
    // static cuz it is one for the whole system 

    // server=.   ,means the database server is my local machine, not online or over the internet
    // then database name and server login info. or use this to skip login info:  Trusted_Connection=True;
    static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=123456;";


    // now we prepare a function to call main objects of the data provider to establish the connection and deal with the database:
    static void printAllContacts()
    {
        // 1-  prepare a connection object using the connection string as parameter:
        SqlConnection connection = new SqlConnection(connectionString);


        // 2- after connection object is created, we prepare a query to use, same as we do in sql server queries.
        // and prepare the command object of the data provider TO EXECUTE the query:
        string query = "select * from Contacts";
        SqlCommand command = new SqlCommand(query, connection);



        // now Connection is ready to open, and command is ready to execute!!
        // lets prepare the execution:
        // with databases and every connection, always use try-catch to handle errors and exceptions:

        try
        {
            // we open the connection,then close it when done:
            connection.Open();

            // to fetch data, create Reader reference variable to receive the object of the command method which has the query script:
            // command.ExecuteReader(); this will return a result set from database as an object of SqlDataReader.
            // this method is used when returning more than one records, other cases will use other methods
            SqlDataReader reader = command.ExecuteReader(); 


            // now lets print the result set using while loop and read method of reader function
            // read will give one record then keeps FORWARD looping till empty then becomes false and stops.
            while (reader.Read())
            {
                // to take the record columns values from the data reader to local variables to be able to print them:
                int contactID = (int)reader["ContactID"];         // can use index from 0 instead of names, but better use names
                string FirstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string Address = (string)reader["Address"];
                int CountryID = (int)reader["CountryID"];

                
                Console.WriteLine("\nContactID: " + contactID);
                Console.WriteLine("FirstName: " + FirstName);
                Console.WriteLine("LastName: " + LastName);
                Console.WriteLine("Email: " + Email);
                Console.WriteLine("Phone: " + Phone);
                Console.WriteLine("Address: " + Address);
                Console.WriteLine("CountryID: " + CountryID);

            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);

        }
        finally
        {
            // in the finally block to avoid being skipped and connection not closing when exceptions happen
            connection.Close();
        }

        // important to close reader and connection when done, one device makes many connections (multiple functions making calls) which is exhausting 
        // let alone many devices connected.
        // there is a connection pool, which is like a limit of connections, when too many connections opened, it wont allow more connections
        // hence app will crash, unless we close the connections.
    }


    static void Main(string[] args)
    {
        printAllContacts();
    }

}


