using System;
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

        public void UpdateRecordToDatabase()
        {

            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update Contacts
                            set FirstName = @FirstName
                            where ContactID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", this.FirstName);
            command.Parameters.AddWithValue("@ID", this.ContactID);

            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();  // non query, cuz we arent querying, we are updating, this method returns int of how many affected rows

                if (rowAffected > 0)
                    Console.WriteLine("Record updated!");
                else
                    Console.WriteLine("Record was not updated!");

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

        clsInfo Contact = new clsInfo("Abdullah", "Alzahrani", "AZ@AZ.com", "054833", "Dmm st1", 2);


        // update info then run method to update in database:
        Contact.ContactID = 8; // here i assigned it to use in the query
        Contact.FirstName = "bobobo";
        Contact.UpdateRecordToDatabase();

    }
}