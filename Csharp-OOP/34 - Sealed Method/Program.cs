using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// sealing a method prevent any overriding on it by other classes methods
// we cant override it but we can shadow it

// so idea of sealing a method is to stop the overriding chain at certain point by  sealed keyword


namespace _34___Sealed_Method
{

    public class Person
    {
        // to be able to use sealed methods, we have to use it on overridden methods only
        public virtual void Greet()
        {
            Console.WriteLine("hello");
        }

    }

    public class Employee : Person
    {
        // to be able to use sealed methods, we have to use it on overridden methods only
        // we can ONLY seal an overriding method (needs override key word).
        // So we CANNOT mark a virtual method as sealed directly.
        public sealed override void Greet()
        {
            Console.WriteLine("employee says hello");
        }

        // next sub classes cant override this method

    }


    public class Manager : Employee
    {
        // cant override Greet cuz it is sealed
        // but we can shadow it, using new keyword
        public override void Greet()
        {
            Console.WriteLine("manager says hi");
        }

    }




    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Greet();

            Employee e = new Employee();
            e.Greet();

            Manager m = new Manager();
            m.Greet(); // will give error


        }
    }
}
