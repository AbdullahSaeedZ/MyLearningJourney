using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26___Multi_Level_Inheritance
{

    public class Person
    {
        public int age { get; set; }
        public string name { get; set; }

        public void Introduce()
        {
            Console.WriteLine($"My name is {name}, and im {age} years old.");
        }

    }

    public class Employee : Person
    {
        public int ID { get; set; }
        public decimal Salary { get; set; }

        public void Work()
        {
            Console.WriteLine($"my id is {ID}, my salary is {Salary} .");
        }

    }

    public class Doctor : Employee
    {

        public string Speciality { get; set; }

        public void Info()
        {
            Console.WriteLine($"my name is {name}, id is {ID}, salary is {Salary:C}, my speciality is {Speciality}");
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Doctor Doctor1 = new Doctor();

            Doctor1.name = "Abdullah";
            Doctor1.ID = 100;
            Doctor1.age = 25;
            Doctor1.Salary = 33000;
            Doctor1.Speciality = "Heart Breaker :)";

            Doctor1.Introduce();
            Doctor1.Work();
            Doctor1.Info();


        }
    }
}
