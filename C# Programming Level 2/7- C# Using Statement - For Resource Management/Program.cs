using System.Data.SqlClient;

namespace _7__C__Using_Statement___For_Resource_Management
{
    internal class Program
    {
        // what is meant by resources is anything that the program needs from the operating system to be able to do its work
        // such as RAM, open files, database connections, network sockets and camera or microphone access
        // those resources as we know can be managed by CLR or unmanaged

        // managed objects allocated on the managed heap and tracked by the CLR like:
        string name = "abdullah";
        List<int> numbers = new List<int>();

        // above managed code will be handled by GC and frees them once not in use
        // but unmanaged resources like windows resources are not directly managed by GC
        // such as Database connection or Open file streams ran by windows resources like:
        FileStream file = new FileStream("data.txt", FileMode.OpenOrCreate);
        // this will use managed resources like RAM to allocate the file object and plus an unmanaged resources that GC cant handle like Windows Handles used for streams to open the file ========= see stream explaination in next lessons
        // thus, we need to close the file streams or connections manually like:
        //         file.Close();
       

        // some classes or libs in .net, use unmanaged code internally, FileStream is an example, and they are implementing an interface called IDisposable
        // which ensures those classes implement a method called Dispose to ensure cleaning up and releasing resources when called,
        // instead of calling Dispose manually, we can use "Using" to let it handle the disposing once finising from the used object, example:
        static void Main(string[] args)
        {
            string connectionString = $"Server=ABDULLAH;Database=DVLD;User Id=sa;Password=123456;";

            // since the SqlConnection is a managed code in .net but uses unmanaged code and resources for connections, we use it in "using statement block:
            using (SqlConnection connection= new SqlConnection(connectionString))
            {
                // once this block is excecuted, the Dispose method in connection object will be automatically run, ands same for the rest of using statements
                string query = "select * from Drivers";

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"Driver ID = {(int)reader["DriverID"]}");
                            }
                        }
                    }
                }
            }


            // the new way of "using statement" doesnt require brackets, and will run the dispose when the scope of declaration ends, in this example it is the main method scope:
            using SqlConnection connection1 = new SqlConnection(connectionString);
            connection1.Open();

            string query1 = "select * from Drivers";
            using SqlCommand command1 = new SqlCommand(query1, connection1);
            
            using SqlDataReader reader1 = command1.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    Console.WriteLine($"Driver ID = {(int)reader1["DriverID"]}");
                }
            }

        }
    }
}

// IDisposaple interface:
/*
 * ==================================================================================
 *  IDisposable Explained
 * ==================================================================================
 * * Term            |  Explanation
 * ------------------|--------------------------------------------------------------
 * IDisposable       | An interface with one method: Dispose()
 * | 
 * Purpose           | To clean up unmanaged resources safely and manually
 * | 
 * Used In           | Classes like FileStream, SqlConnection, StreamReader, or any custom class.
 * | 
 * Why Important     | Prevents memory leaks, resource locking, and performance issues
 * | 
 * With using        | Works perfectly with the using statement for automatic disposal
 * * ==================================================================================
 * when implementing the interface in custom classes, better to follow best practices from Microsoft
 */
