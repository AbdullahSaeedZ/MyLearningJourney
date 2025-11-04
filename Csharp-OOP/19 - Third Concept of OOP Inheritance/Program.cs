using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// same as c++


// relation between person and employee is (is-a) meaning employee is a person (person is not an employee) , this helps us to use inheritance rather than composition

namespace _19___Third_Concept_of_OOP_Inheritance
{
    // base class / super class

    // The base class must be accessible to the derived class.
    // access modifiers do NOT need to match.
    // Example: if the base class is public, any class can inherit it.
    // If the base class is private or not accessible, inheritance is not possible.
    // private sub can inherit from public base, idea is we need to have accessible class to inherit from.

    public class clsPerson 
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        // read-only
        public string FullName { get { return FirstName + ' ' + LastName; } }
    }


    // employee Class Inherits Person
    // sub class / derived class
    public class clsEmployee : clsPerson
    {
        // those private data members that was created in base class, cant be dealt with by the sub class unless we create getter and setter in the base class
        // , or make them protected not private to be able to access them (not the base class data members values) without getters and setters
        // the data members of the base class are private, but we had access to them cuz we created properties for them




        // add whatever members relate to employees as addition to the base class members
        public float Salary { get; set; }
        public string DepartmentName { get; set; }


        public void IncreaseSalaryBy(float Amount)
        {
            Salary += Amount;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            clsEmployee employee1 = new clsEmployee();
            employee1.FirstName = "Abdullah";
            employee1.LastName = "Alzahrani";
            Console.WriteLine("Full name using base class property: {0}", employee1.FullName);

            employee1.Salary = 16000;
            employee1.IncreaseSalaryBy(4000);
            Console.WriteLine("salary: {0}", employee1.Salary);

        }
    }
}
