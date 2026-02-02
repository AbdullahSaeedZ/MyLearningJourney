using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this is about preventing creating an object of a class
// there are two ways, to make the class static, or to make the constructor as private.

// another difference between the two, static class cant be inherited or inherit from any classed, unlike private constructors where it can inherit.


namespace _6___Static_Properties___Static_Class
{
    // static classes, are like helper classes, cant create objects out of it, but can use their members 
    // static class can only have static constructor, cuz the default one needs an object, and objects cant be created with static classes.
    // the static constructor will only run once and with the first use of the class when accessing any of its members, with out using the new keyword.

    // this is preventing objects creation at all , outside or inside the class unlike private constructor way.
    static class Settings
    {

        public static int DayNumber
        {
            get
            {
                return DateTime.Today.Day;
            }
        }


        public static string DayName
        {
            get
            {
                return DateTime.Today.DayOfWeek.ToString();
            }
        }


        public static string ProjectPath { set; get; }


        // If not written explicitly, a static constructor may be generated implicitly
        // only when initialization requires executing code (not default values).

    }


    // this is preventing objects creating only outside the class
    class clsTest
    {

        public static int DayNumber
        {
            get
            {
                return DateTime.Today.Day;
            }
        }


        public static string DayName
        {
            get
            {
                return DateTime.Today.DayOfWeek.ToString();
            }
        }

        public static string ProjectPath { set; get; }

        private clsTest()
        {
            //since this is private constructor, it wont allow creating objects outside, hence constructor wont be called
            // whatever code here wont be implemented, cuz no objects created outside the class, but if we create an object here inside the class then it will be called

            Console.WriteLine("this is inside constructor");
        }
            
        // example of creating object inside the class
        public static void test()
        {
            new clsTest();
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // we cant create objects of static classes
            //Settings temp;

            Console.WriteLine("today number is {0}", Settings.DayNumber);
            Console.WriteLine("today name is {0}", Settings.DayName);

            Settings.ProjectPath = @"C:\name\another name";
            Console.WriteLine("Project path is {0}", Settings.ProjectPath);




            // cant create an object of class clsTest
            //  clsTest t1 = new clsTest();
            Console.WriteLine("test Project path is {0}", clsTest.ProjectPath = "ddd");
            clsTest.test();
        }
    }
}