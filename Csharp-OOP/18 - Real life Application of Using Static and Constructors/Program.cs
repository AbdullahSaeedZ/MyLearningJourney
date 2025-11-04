using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


// same stuff used in bank project i did in c++

namespace _18___Real_life_Application_of_Using_Static_and_Constructors
{

    // important NOTE, dont create empty objects, objects once created they must relate to an existed person or certain data.
    // here we will enforce any object creation to be filled first with info, so when we look in data base or an where, we dont find empty objects with empty data (we did it in the bank project)
    // some problems can be, forgetting to fill important fields like last name and so on , then data gets messy and incomplete, so we control it from the start.
    // first step is to use the parameterized constructor
    class clsPerson
    {

        public int ID { get; set; }
        public int age { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        // to force filled object
        public clsPerson(int ID, int age, string name)
        {
            this.ID = ID;
            this.age = age;
            this.name = name;

        }

        // since we controlled the objects creation, we can use the overloaded methods to find those objects and bring them from our data base and we are confident that we have required info to search by
        static public clsPerson find(int ID)
        {
            // (just simulation, later will access real data base)
            if (ID == 100)
            {
                // if found, we return a created object in memory filled with data from database
                return new clsPerson(100, 20, "Abdullah");
            }
            else
            {
                // if not found we return null, no empty objects, no created object in memory, only null reference variable.
                return null;
            }
        }

        static public clsPerson find(string username, string password)
        {
            // (just simulation, later will access real data base)
            if (username == "admin" && password == "1234")
            {
                return new clsPerson(200, 25, "admin");
            }
            else
            {
                return null;
            }
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // controlling creation process
            // clsPerson person1 = new clsPerson(100, 20, "abdullah"); // this object can not be empty, now it is filled and represents a real person



            // when finding objects: 
            // declare and prepare the reference variable:
            clsPerson personToFind = clsPerson.find(100);
            if (personToFind != null)
            {
                Console.WriteLine("\nobject was found in data base and returned the object");
                Console.WriteLine("id = {0}", personToFind.ID);
                Console.WriteLine("age = {0}", personToFind.age);
                Console.WriteLine("name = {0}", personToFind.name);
            }
            else
            {
                Console.WriteLine("\nobject wasnt found in data base, and we have no object returned, only reference variable with null value");
            }

            // same by username and password
            clsPerson person2ToFind = clsPerson.find("username", "123334");
            if (person2ToFind != null)
            {
                Console.WriteLine("\nobject was found in data base and returned the object");
                Console.WriteLine("id = {0}", person2ToFind.ID);
                Console.WriteLine("age = {0}", person2ToFind.age);
                Console.WriteLine("name = {0}", person2ToFind.name);
            }
            else
            {
                Console.WriteLine("\nobject wasnt found in data base, and we have no object returned, only reference variable with null value");
            }



            // till here we hit our goal to not have an empty object, search then return a filled object or return with null reference variable !
            // so, we prevent creating empty objects to avoid incomplete or invalid data records.
            // by forcing object creation through a parameterized constructor, every object
            // will always represent a real, valid person.
            // when searching, we return either a fully filled object or null, hence never an empty object.

        }
    }
}
