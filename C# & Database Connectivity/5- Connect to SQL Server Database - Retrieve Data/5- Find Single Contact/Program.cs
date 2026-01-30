using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Dynamic;


internal class Program
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

        static public clsInfo findContactByID(int ID)
        {
            clsInfo temp = new clsInfo();
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from Contacts where ContactID = @Value";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Value", ID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())  // using if-statement cuz we are looking for only one record
                {
                    temp.ContactID = (int)reader["ContactID"];
                    temp.FirstName = (string)reader["FirstName"];
                    temp.LastName = (string)reader["LastName"];
                    temp.Email = (string)reader["Email"];
                    temp.Phone = (string)reader["Phone"];
                    temp.Address = (string)reader["Address"];
                    temp.CountryID = (int)reader["CountryID"];
                }
                else
                {
                    temp = null;
                }    
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                temp = null;
            }
            finally
            {
                connection.Close();
            }

            return temp;
        }
        public void PrintInfo()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("ContactID: " + ContactID);
            Console.WriteLine("FirstName: " + FirstName);
            Console.WriteLine("Last Name: " + LastName);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Phone: " + Phone);
            Console.WriteLine("Address: " + Address);
            Console.WriteLine("CountryID: " + CountryID);
            Console.WriteLine("----------------------------");
        }
    }

 

    static void Main(string[] args)
    {
        clsInfo Contact = clsInfo.findContactByID(11);

        if (Contact != null)
        {
            Contact.PrintInfo();
        }
        else
        {
            Console.WriteLine("No Contact Found");
        }

    }
}