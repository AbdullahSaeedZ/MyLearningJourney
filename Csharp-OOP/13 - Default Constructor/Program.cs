using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13___Default_Constructor
{
    class clsPerson
    {
        public int ID { set; get; }
        public string name { set; get; }
        public int age { set; get; }

        // default values of premitive types will be 0, false for boolean
        // default values of reference types will be null, like string or objects not yet created like clsPerson person1;

        // default constructor will be created when we dont declare any constructor
        // default constructor will fill members with default values

    }


    internal class Program
    {
        static void Main(string[] args)
        {

            clsPerson person1 = new clsPerson(); // default constructor will fill members will be filled with default values
            Console.WriteLine("id = {0}", person1.ID);
            Console.WriteLine("age = {0}", person1.age);
            Console.WriteLine("name = {0}", person1.name);

        }
    }
}
