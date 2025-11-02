using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6___Static_Properties___Static_Class
{
    // static classes, are like helper classes, cant create objects out of it, but can use their members 
    // static class can only have static constructor, cuz the default one needs an object, and objects cant be created with static classes.
    // the static constructor will only run once and with the first use of the class when accessing any of its members, with out using the new keyword.
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

        }
    }
}
