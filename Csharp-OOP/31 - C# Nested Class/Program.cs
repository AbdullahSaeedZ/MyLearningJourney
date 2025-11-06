using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// A nested class is a class declared INSIDE another class.
// inner class can access outer members but only through an instance of outer.
// Outer class can create and access its own inner class directly.


namespace _31___C__Nested_Class
{

    public class outerClass
    {
        private int outerVariable;

        public outerClass(int anyVar)
        {
            outerVariable = anyVar;
        }

        public void outerMethod()
        {
            Console.WriteLine("outerMethod called");
        }


        // this class is seperate from the outer class, it only exist inside the outerClass
        public class innerClass
        {
            private int innerVariable;

            public innerClass(int anyV)
            {
                innerVariable = anyV;
            }

            public void innerMethod()
            {
                Console.WriteLine("innerMethod called, innerVariable : " + innerVariable);
            }

            public void accessOuterVariable(outerClass outerObj)
            {
                // cant directly reach private members of outerClass 
                // inner class can access outer members but only through an instance of outer.
                Console.WriteLine("accessing outerVariable from innerCLass: " + outerObj.outerVariable);
            }

        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {

            outerClass outer1 = new outerClass(100);

            outerClass.innerClass inner1 = new outerClass.innerClass(50);

            outer1.outerMethod();
            
            inner1.innerMethod();
            inner1.accessOuterVariable(outer1);

        }
    }
}
