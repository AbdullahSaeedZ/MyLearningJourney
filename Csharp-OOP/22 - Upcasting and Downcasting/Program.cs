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
        public int Age { get; set; }
        public string FirstName { get; set; }

        public void greet()
        {
            Console.WriteLine($"hi my name is {FirstName} and im {Age} years old");
        }

    }


    // upcasting is to cast sub to base (upcasting , from down to up) sub has all of bas in it, so we can cast it easily to the base, from employee to person
    // down casting is not safe , from base to sub ( downcasting , from up to down) base doesnt have all of base members, person to employee.


    // sub class / derived class
    public class clsEmployee : clsPerson
    {
   
        public float Salary { get; set; }
        public string company { get; set; }


        public void work()
        {
            Console.WriteLine($"i work at {company} and earn {Salary:C} per year");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // upcasting sub to base (safe and fine)
            clsEmployee employee1 = new clsEmployee { FirstName = "Abdullah", Age = 10, company = "SA", Salary = 55000}; // <-- called object initializer syntax works with default constructor
            clsPerson person = employee1;
            person.greet();
            //after upcasting employee to person, we can only access person members but with employee values:  person.Age  ,  person.FirstName   



            //down casting base to sub (not safe, missing sub members in base class)
            /*
             clsPerson person2 = new clsPerson { FirstName = "koko", Age = 22 };   // due to this little values given, castin later will throw exception
            clsEmployee employee2 = (clsEmployee)person2; // runtime exception
             */


            // doing valid down casting is done this way:
            // we create an employee object but using person reference variable, which limits what we use from that object.
            clsPerson person3 = new clsEmployee { FirstName = "fofo", Age = 20, company = "tgb", Salary = 33000 };  // due to this full values given, casting later will be accepted
            clsEmployee employee3 = (clsEmployee)person3;
            employee3.work();



            // Upcasting doesn't reduce object size or make it faster.
            // The object remains an Employee in memory, but we choose to view it through a Person reference.
            // We use upcasting mainly to treat different subclasses in a unified way (polymorphism).
            // Downcasting is only used when we are sure the actual object type is the subclass.


        }
    }
}