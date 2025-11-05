using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace _19___Third_Concept_of_OOP_Inheritance
{
    // base class / super class


    public class clsPerson
    {
        public clsPerson(int ID, string Title, string firstName, string lastName)
        {
            this.ID = ID;
            this.Title = Title;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        // read-only
        public string FullName { get { return FirstName + ' ' + LastName; } }

    }



    // sub class / derived class
    public class clsEmployee : clsPerson
    {
        // passing base class parameters to base class constructor using base keyword
        public clsEmployee(int ID, string Title, string firstName, string lastName, float Salary, string Department) : base( ID,  Title,  firstName, lastName)
        {
            this.Salary = Salary;
            this.DepartmentName = Department;
        }

      
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

            clsEmployee employee1 = new clsEmployee(100, "engineer", "Abdullah", "Alzahrani", 24000, "Software");
            Console.WriteLine(employee1.FullName);
            Console.WriteLine(employee1.ID);
            Console.WriteLine(employee1.DepartmentName);
            Console.WriteLine(employee1.Salary);

        }
    }
}