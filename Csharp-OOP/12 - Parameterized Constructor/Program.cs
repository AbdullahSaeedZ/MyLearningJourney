using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12___Parameterized_Constructor
{


    class clsPerson
    {
        public int ID { set; get; }
        public string name { set; get; }
        public int age { set; get; }

        // if no access modifier, it is private by default
        public clsPerson(int ID, string name, int age)
        {
            //use this to differentiate parameters from properties names
            this.ID = ID;
            this.name = name;
            this.age = age;
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {

            clsPerson person1 = new clsPerson(-1, "Abdullah", 1); // it wont allow creating objects without filling the constructor parameters
            Console.WriteLine("id = {0}", person1.ID);
            Console.WriteLine("age = {0}", person1.age);
            Console.WriteLine("name = {0}", person1.name);

        }
    }
}
