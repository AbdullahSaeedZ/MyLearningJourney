using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21___Constructor_Chaining
{

    public class Person
    {
        public string Name;
        public int Age;

        /*
        public Person()
        {
            Name = "Unknown";
            Age = 0;
            Console.WriteLine("Init logic...");
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine("Init logic...");
        }
         */


        // this chaining the constructor, benifit is when changing the code, i change it in one place then it is all set.

        // this is the way we pass parameters from sub class constructor to base constructor when inheritance
        // when running code, if default constructor is called (no values given in object creation) will run and call the chained constructor (the parametrized one) and pass the arguments
        public Person() : this("Unknown", 0)
        {
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine("Init logic...");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // it is like overloading the constructors, i can create objects with out giving arguments and will have default values
            // or i can give arguments and will be passed to members
            // the goal is to make it consistent when makeing changes in constructor, only change in one place then it is changed in the other constructor.
            Person person1 = new Person();
            Console.WriteLine(person1.Name);

            Person person2 = new Person("Abdullah", 99);
            Console.WriteLine(person2.Name);

        }
    }
}
