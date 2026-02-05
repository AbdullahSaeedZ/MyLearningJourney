using System;
using System.Data;
using ContactsBusinessLayer;


// this is the presentation Layer , the Front-end, can be a console app or WinForms or a website
// this layer communicates with the back-end layers


namespace ContactsConsoleApp
{
    internal class ConsoleApp
    {

        static void FindContact(int ID)
        {
            // we let the business layer do the logic and gives us either a filled object or noting (null);
            clsContact Contact = clsContact.find(ID);

            // here we can do the printing, this is the presentation layer:
            if (Contact != null)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"ID: {Contact.ID}" );
                Console.WriteLine($"First Name: {Contact.FirstName}" );
                Console.WriteLine($"Last Name: {Contact.LastName}" );
                Console.WriteLine($"Email: {Contact.Email}" );
                Console.WriteLine($"Address: {Contact.Address}" );
                Console.WriteLine($"Date Of Birth: {Contact.DateOfBirth}" );
                Console.WriteLine($"Phone: {Contact.Phone}" );
                Console.WriteLine($"Country ID: {Contact.CountryID}" );
                Console.WriteLine($"Image Path: {Contact.ImagePath}" );
                Console.WriteLine("--------------------------------------");

            }
            else
            {
                Console.WriteLine($"Contact with ID [{ID}] was not found!!");
            }
        }

        static void AddNewContact()
        {
            clsContact contact = new clsContact();

            contact.FirstName = "Abdullah";
            contact.LastName = "Alzahrani";
            contact.Phone = "0545435";
            contact.Address = "st 1";
            contact.CountryID = 2;
            contact.DateOfBirth = new DateTime(1997, 6, 3);
            contact.ImagePath = "";

            if (contact.Save())
            {
                Console.WriteLine($"Contact Added Successfully! contact ID is {contact.ID}");
            }
            else
            {
                Console.WriteLine("Contact Was Not Added!");
                contact = null;
            }    
        }

        static void UpdateContact(int ID)
        {
            clsContact contact = clsContact.find(ID);

            // update whatever
            contact.FirstName = "boood";
            contact.LastName = "Alzahrani";
            contact.Phone = "0999999";
            contact.Address = "st 1";
            contact.CountryID = 1;
            contact.DateOfBirth = new DateTime(1997, 6, 3);
            contact.ImagePath = "";

            if (contact.Save())
            {
                Console.WriteLine("Contact Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Contact Was Not Updated!");
                contact = null;
            }
        }

        static void DeleteContact(int ID)
        {
            // we cn use the find method to show info before deleting if we want.

            if (clsContact.DeleteContact(ID))
            {
                Console.WriteLine("Contact Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Deletion failed!");
            }

        }

        // can use this method in delete method, to check does ID exist in DB without using find method hence create an object in memory then delete from DB and remain with object in app 
        // this method checks and return boolean with no objects at all.
        static void DoesContactExist(int ID)
        {
            Console.WriteLine($"ID {ID} : {clsContact.DoesExist(ID)}");
        }

        static void ListContacts()
        {
            // data table is like a 2d array, it has columns and rows, see next lessons
            DataTable dataTable = clsContact.GetAllContacts();

            Console.WriteLine("Contacts Data:\n");

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine($"{row["ContactID"]} | {row["FirstName"]} | {row["LastName"]}");
                }
            }
            else
            {
                Console.WriteLine("No Data Available");
            }
        } 


        //--------------------------------------------------------------------------- Countries ---------------------------------------------
        
        static void FindCountry(int ID)
        {
            clsCountries country = clsCountries.Find(ID);

            if (country != null)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"ID: {country.ID}");
                Console.WriteLine($"Country Name: {country.CountryName}");
                Console.WriteLine("--------------------------------------");
            }
            else
            {
                Console.WriteLine($"Country with ID [{ID}] was not found!!");
            }
        }

        //
        static void FindCountryByName(string CountryName)
        {
            clsCountries country = clsCountries.FindByName(CountryName);

            if (country != null)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"ID: {country.ID}");
                Console.WriteLine($"Country Name: {country.CountryName}");
                Console.WriteLine("--------------------------------------");
            }
            else
            {
                Console.WriteLine($"Country with Name [{CountryName}] was not found!!");
            }
        }

        static void AddNewCountry()
        {
            clsCountries country = new clsCountries();
            country.CountryName = "KSA";

            if (country.Save())
            {
                Console.WriteLine("Country Added Successfully!");
                Console.WriteLine($"New Country ID = {country.ID}");
            }
            else
            {
                Console.WriteLine("Country was not added !!"); 
            }
        }

        static void UpdateCountry(int ID)
        {
            clsCountries country = clsCountries.Find(ID);
            country.CountryName = "Saudi Arabia";

            if (country.Save())
            {
                Console.WriteLine("Info Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Info was not updated!");
            }
        }

        static void DeleteCountry(int ID)
        {
            if (clsCountries.DeleteCountry(ID))
            {
                Console.WriteLine("Country Deleted Successfully!");
            }
            else 
            {
                Console.WriteLine("Country was not deleted!");
            }
        }

        static void DoesCountryExist(int ID)
        {
            if (clsCountries.DoesExist(ID))
            {
                Console.WriteLine("Country Exists!");
            }
            else
            {
                Console.WriteLine("Country Does Not Exists!");
            }
        }
        //
        static void DoesCountryExistByName(string CountryName)
        {
            if (clsCountries.DoesExistByName(CountryName))
            {
                Console.WriteLine("Country Exists!");
            }
            else
            {
                Console.WriteLine("Country Does Not Exists!");
            }
        }

        static void ListCountries()
        {
            DataTable dt = clsCountries.getAllCountries();

            Console.WriteLine("Countries Data:\n");

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($" ID: {row["CountryID"]} | Name: {row["CountryName"]}");
                }
            }
            else
            {
                Console.WriteLine("No Data Available");
            }
        }



        static void Main(string[] args)
        {
            //FindContact(2);
            //AddNewContact();
            //UpdateContact(10);
            //DeleteContact(4);
            // ListContacts();
            //DoesContactExist(10);

            // -------------------- Countries ------- 

            //FindCountry(1);
            //AddNewCountry();
            //UpdateCountry(6);
            //DeleteCountry(3);
            //DoesCountryExist(1);
            ListCountries();
        }
    }
}
