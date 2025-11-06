using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;


// Interface class is a contract that force classes to implement certain terms.
// Interface is a class that has only heading or no implementation methods, no implementation at all.
// An interface is a completely "abstract class", which can only contain abstract methods and properties (with empty bodies)
// Like abstract classes, interfaces cannot be used to create objects
// Interfaces can contain properties and methods, but not fields/variables
// Interface members are by default abstract and public
// An interface cannot contain a constructor (as it cannot be used to create objects)

// in new versions of C#, we can add methods with implementation inside an interface


namespace _29___What_is_Interface_and_Why
{

    // create using interface keyword, and better use I prefix when naming to differentiate.
    public interface IPerson
    {
        // cant create data members
        //int age;

        // no access modifiers, they are abstract methods and public by defaullt

        string firstName { get; set; }
        string lastName { get; set; }

        void introduce();

        void print();

    }


    //can use interfaces with regular classes or abstract classes
    public abstract class Person : IPerson
    {
        // add access modifiers for all contract terms
        public string firstName { get; set; }
        public string lastName { get; set; }

        public abstract void introduce();
      

        // just do the implementation, no need to use override keyword
        public void print()
        {
            Console.WriteLine("hi");
        }

        // we fulfilled the interface terms, now we can do whatever extra steps
        // any extra methods 
        public void SendEmail()
        {
            Console.WriteLine("email sent");
        }


        
    }


    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
