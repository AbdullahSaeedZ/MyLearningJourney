using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _29___Structures
{

    struct stStudent
    {
        // access modifier inside the struct is private by default, so we use public to see it in other places; 
        public string FirstName;
        public string LastName;
        public int ID;
        float salary; // this is private by default
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            //struct can be used to hold small data values that do not require inheritance, e.g.coordinate points, key-value pairs, and complex data structure.

            //A struct object can be created with or without the new operator, same as primitive type variables.
            //If you declare a variable of struct type without using new keyword, it does not call any constructor,
            //so all the members remain unassigned.Therefore, you must assign values to each member before accessing them, otherwise, it will give a compile-time error.

            //using new does not mean it's allocated in heap, it is just for initializing members with default values by constructor.
            //structure is allocated in stack as long as it's not part of class.
           

            stStudent Student;

            //Console.WriteLine(Student.FirstName); // will give error, so must be assigned values first.
            Student.FirstName = "Abdullah";
            Student.LastName = "Alzahrani";
            Student.ID = 100;

            Console.WriteLine(Student.FirstName);
            Console.WriteLine(Student.LastName);
            Console.WriteLine(Student.ID);




            stStudent Student2 = new stStudent();
            Console.WriteLine(Student2.ID); // no assigned value by us, but since it is created with constructor, members were given initial values for each type, so we can print.

            Student2.FirstName = "Faris";
            Student2.LastName = "Naif";
            Student2.ID = 54;
            Console.WriteLine(Student2.FirstName);
            Console.WriteLine(Student2.LastName);



        }
    }
}
