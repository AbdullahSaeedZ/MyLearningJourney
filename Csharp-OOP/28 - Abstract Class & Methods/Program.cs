using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Abstract class cant have objects, nn abstract class can have both abstract and regular methods
// Abstract class: is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class).

// Abstract class: is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class).
// Abstract method: can only be used in an abstract class, and it does not have a body. The body is provided by the derived class (inherited from).

namespace _28___Abstract_Class___Methods
{

    // this is abstract class, which is like a contract that forces its sub classes to implement its terms
    // no objects of this class allowed
    public abstract class Person
    {

        public string firstName { get; set; }
        public string lastName { get; set; }


        // this abstract method has no implementation, but it is a term of the contract, meaning sub classes must override it and type implementation of this method
        public abstract void Introduce();

        public void sayGoodBye()
        {
            Console.WriteLine("goodbye!");
        }

    }

    // So all abstract methods are virtual,
    // but not all virtual methods are abstract.
    //
    // virtual = optional override
    // abstract = mandatory override


    public class  Employee : Person
    {
        public int ID { get; set; }

        // i must override this function cuz it is a term of the abstract class
        public override void Introduce()
        {
            Console.WriteLine($"hi, im an employee with ID {ID}, my name is {firstName}");
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // cant create an object of abstract class
            // Person person1 = new Person();

            Employee emp1 = new Employee();
            emp1.firstName = "abdullah";
            emp1.lastName = "alzahrani";
            emp1.ID = 100;
            emp1.Introduce();
            emp1.sayGoodBye();



        }
    }
}
