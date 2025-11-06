using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

// Composition is when creating an object of a class inside another class



namespace _32___Composition
{

    public class clsA
    {
        public int x;
        public int y;

        // this relationship is has-a , class A has class b 
        // Composition: Class A (has) an object of Class B.
        // This means that clsB lives and dies with clsA.
        //defining an object of another class inside this class is called composition.
        // class B is composed inside class A
        private clsB ObjectB1;


        public clsA()
        {
            // Create clsB object inside the constructor so it becomes part of clsA.
            ObjectB1 = new clsB(); 
        }

        public void Method1()
        {
            Console.WriteLine("Method1 of class A is called");
        }

        public void Method2()
        {
            Console.WriteLine("Method2 of class A is called");
            Console.WriteLine("im inside class A object, Now i will call method1 of class B...");

            
            ObjectB1.Method1();
        }

    }


    public class clsB
    {
        public void Method1()
        {
            Console.WriteLine("Method1 of class B is called");
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {

            //Create object from class
            clsA ObjectA1 = new clsA();
            ObjectA1.Method1();
            ObjectA1.Method2();

        }
    }
}
