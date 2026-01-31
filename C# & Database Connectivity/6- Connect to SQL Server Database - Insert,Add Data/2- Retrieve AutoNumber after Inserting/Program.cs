using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;



public class Program
{

    static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=123456;";

    class clsInfo
    {
        public int ContactID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public int CountryID { set; get; }

        public clsInfo(string FirstName, string LastName, string Email, string Phone, string Address, int CountryID)
        {
            // this.ContactID = ContactID;   // auto increment in database
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.CountryID = CountryID;
        }

        public void AddToDatabaseGetID()
        {

            SqlConnection connection = new SqlConnection(connectionString);

            // @ creates a verbatim string literal that preserves formatting
            // and allows multi-line text without escape sequences
            // meaning = takes text as it is, no escapes will affect or anything

            string query = @"insert into Contacts  
                             Values (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID);
                             select scope_identity();";

            // SCOPE_IDENTITY() returns the last identity value generated
            // in the current connection and execution scope

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", this.FirstName);
            command.Parameters.AddWithValue("@LastName", this.LastName);
            command.Parameters.AddWithValue("@Email", this.Email);
            command.Parameters.AddWithValue("@Phone", this.Phone);
            command.Parameters.AddWithValue("@Address", this.Address);
            command.Parameters.AddWithValue("@CountryID", this.CountryID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();  // ExecuteScalar will execute all query ,BUT will return a scalar (first value of first column and row) value of last query

                //casting = converting between numeric types (e.g. int -> float)
                //parsing = analyzing text and converting it into a number

                // TryParse signature:
                // bool int.TryParse(string s, out int NewVariable)

                //1- we have result as object, we convert it into string, to use it in the tryParse method
                //2- the parsed(converted) value is stored in InsertedID via the out keyword
                //3- OUT takes uninitialized variable and gives it a value
                //4- the method itself return boolean value indicating success or failure + the new value of InsertedID

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    Console.WriteLine($"Newly inserted ID is {InsertedID}");
                else
                    Console.WriteLine("failed to retrieve the inserted ID");

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
    }



    static void Main(string[] args)
    {

        clsInfo Contact = new clsInfo("fofo", "alfofo", "ff@Af.com", "0548342", "Dmm st1", 3);
        Contact.AddToDatabaseGetID();

    }
}