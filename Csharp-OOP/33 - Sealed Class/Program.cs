using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// sealed class is a class that cant be inherited.
// example of using it is if im selling my class with its methods i worked on, and dont want to let anyone inherit it and extend its methods or anything
// It is the opposite of an abstract class (which must be inherited).

namespace _33___Sealed_Class
{

    // sealing a class using seal keyword
    public sealed class Person
    {
        public int MyProperty { get; set; }
        
        // cant have virtual methods, cuz no one is overriding it

    }

    public class Employee  // : Person  cant inherit
    {



    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // can create objects
            Person p1 = new Person();

        }
    }
}
