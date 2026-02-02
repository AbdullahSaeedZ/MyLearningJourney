using System;
using System.Data;
using ContactsBusinessLayer;

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


        static void Main(string[] args)
        {
           // FindContact(2);
            AddNewContact();


        }
    }
}
