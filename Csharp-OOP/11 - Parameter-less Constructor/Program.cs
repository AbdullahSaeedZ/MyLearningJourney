using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;





namespace _11___Parameter_less_Constructor
{

    class clsPerson
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int age { get; set; }



        // this is a parameterless constructor, used to implement certain code once an object is created.
        public clsPerson()
        {
            ID = -1;
            name = "Abdullah";
            age = 0;
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            clsPerson person1 = new clsPerson(); // after new , we are calling the constructor

            Console.WriteLine("id = {0}", person1.ID);
            Console.WriteLine("age = {0}", person1.age);
            Console.WriteLine("name = {0}", person1.name);

        }
    }
}
