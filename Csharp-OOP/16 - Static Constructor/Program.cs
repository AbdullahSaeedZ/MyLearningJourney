using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// static means on the class level , not the objects level
// static constructor is is called once in the life of the program, unlike non static ones, called with each object.
// static constructors cant be parameterized
// We can have only one static constructor in a class. It cannot have any parameters or access modifiers.
// We cannot call a static constructor directly. However, the static constructor gets called automatically when using memebrs of the static class

namespace _16___Static_Constructor
{

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


        // static constructors cant be parameterized
        static Settings()
        {
            ProjectPath = "cckckck";
            Console.WriteLine("im static constructor");
        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("not using static class members, so static constructor not called yet");
            Console.WriteLine("still not used");
            Console.WriteLine("used in next lines");
            Console.WriteLine(Settings.DayName);
            Console.WriteLine(Settings.ProjectPath);


        }
    }
}
