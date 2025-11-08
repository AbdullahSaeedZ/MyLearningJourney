using System;

// now this is saperate solution and project, the class library (dll assembly) i made is in different place
// jut link it to this project from add -> reference -> then browse to the dll file

// calling its namespace
using MyLibrary;

namespace project_Linked_with_dll
{
    internal class Program
    {
        static void Main(string[] args)
        {


            clsMyMath Math = new clsMyMath();

            Console.WriteLine(Math.Sum(10, 20));
        }
    }
}
