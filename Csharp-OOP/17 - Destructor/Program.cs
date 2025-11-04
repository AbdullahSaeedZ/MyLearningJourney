using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17___Destructor
{

    class clsPerson
    {

        public clsPerson()
        {
            Console.WriteLine("constructor called");
        }

        // destructor must have telda (~)
        // no modifiers needed, no parameters, no direct calling, called once object is destructed
        ~clsPerson()
        {
            Console.WriteLine("destructor called");
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            clsPerson person1 = new clsPerson();

            Console.WriteLine("while using te object, still destructor not called, once we finish, the garbage collector will destruct the object");
            Console.WriteLine("then destructor will run, press any key to indicate that we finished with the object");
            Console.ReadKey();
        }
    }
}
