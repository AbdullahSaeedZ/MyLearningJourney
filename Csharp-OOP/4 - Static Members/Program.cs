using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// static members (methods or variables) are shared in memory, so objects will have special memory space for objects data members, but one memory space for a method, and also a shared memory space for static members.

// obj1 and obj2 when accessing a static data member, will point to same memory address, cuz static is shared.
// but in C#, static members can be accessed through the class name not by objects, className.staticMember = value;

namespace _4___Static_Members
{

    class clsA
    {
        public int x1;
        public static int x2; // this is shared for all objects, it is on the class level.


        public int func1() // only accessed by an object
        {
            // non static methods in objects can use static members normally
            x2 += 1000;
            return x1 + x2;
        }

        public static int func2() // this is accessed from the class itself, cant access from an object
        {
            // static methods cant access non static members, cuz non static means the are inside an object, so the static method will say ok u called a nonstatic, but from which object ?
            return x2;
        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {
            clsA objA = new clsA();
            clsA objB = new clsA();

            // here x1 of objA is different from objB x1, different memory locations
            objA.x1 = 5;
            objB.x1 = 10;
            

            
            // now this static member is accessed only from the class itself to edit.
            clsA.x2 = 400;

            // cant update or read static variable from the object:
            // objA.x2 = 2;   error
          

            // non-static method func1 can call static variable x2 to update and print
            Console.WriteLine("objA func1 = {0}", objA.func1());
            Console.WriteLine("objB func1 = {0}", objB.func1());

        }
    }
}
