using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23___Method_Overriding_in_C__Inheritance___Base_Keyword
{


    public class clsA
    {


        // Virtual means this method CAN be overridden in sub classes
        // if no virtual keyword, then it is not overriding , it is shadowing or hiding (see next lesson)
        public virtual void Print()
        {
            Console.WriteLine("this is print method in base class A");
        }
    }

    public class clsB : clsA
    {
        // use override keyword 
        public override void Print()
        {
            Console.WriteLine("this is overridden print method in sub class B");

            // we can use body of base print method here using:
           // base.Print();
        }
    }

    // overriding is one type of polymorphism
    // For method overriding:
    // - The base method must be marked as virtual or abstract (or already overridden).
    // - Both methods must have the same signature.
    // - Override is always done in the derived class.

    // virtual methods enable polymorphism, meaning correct method implementation (base or sub) is called at run time based on object type not reference type:

    // Example (upcasting):
    // reference type = clsA , object type = clsB
    // clsA ref = new clsB();
    // ref.Print(); // will call clsB.Print() due to runtime polymorphism


    internal class Program
    {
        static void Main(string[] args)
        {

            clsA A = new clsA();
            A.Print();

            clsB B = new clsB();
            B.Print();



            // Using upcasting:
            // Even though the reference type is clsA, the actual object is clsB.
            // Because Print() is virtual and overridden in clsB, the clsB version will run at runtime.
            clsA upcasting = new clsB();
            upcasting.Print();  // calls clsB.Print() due to runtime polymorphism

        }
    }
}
