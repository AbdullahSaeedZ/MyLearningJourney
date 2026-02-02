using System;
using System.Data;
using ContactsBusinessLayer;

namespace ContactsConsoleApp
{
    internal class ConsoleApp
    {

        static void testFindContact(int ID)
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



        static void Main(string[] args)
        {
            testFindContact(2);


        }
    }
}
