using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15___Multiple_Constructors_using_overloading
{


    // function overloading: same function name, but different parameters
    // different number of parameters or different types, or different order of types.



    class clsPerson
    {
        public int ID { set; get; }
        public string name { set; get; }
        public int age { set; get; }



        // constructor Overloading allows us to create multiple constructors for the same class.
        // they must have the same name (class name), but differ in the number or types of parameters.
        public clsPerson()
        {
            ID = 1;
            name = "Abdullah";
            age = 2;
        }

        public clsPerson(int ID, string name, int age)
        {
            this.age = age;
            this.ID = ID;
            this.name = name;
        }


    }


    internal class Program
    {
        static void Main(string[] args)
        {

            clsPerson person1 = new clsPerson(); // parameterless constructor called
            Console.WriteLine("id = {0}", person1.ID);
            Console.WriteLine("age = {0}", person1.age);
            Console.WriteLine("name = {0}", person1.name);

            Console.WriteLine("\n\n");

            clsPerson person2 = new clsPerson(3, "fofo", 33); // parameterized constructor called
            Console.WriteLine("id = {0}", person2.ID);
            Console.WriteLine("age = {0}", person2.age);
            Console.WriteLine("name = {0}", person2.name);

        }
    }
}
