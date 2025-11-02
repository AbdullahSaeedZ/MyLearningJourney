using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// access modifiers define who can reach members of a class
// public member can be reached any where inside or outside the class
// private can only be accessed inside the class, cant outside or from objects.
// protected are accessed inside the class and the inherited classes , not from objects.


// in c# there is a fourth type, which is Internal, will be explained in details later.
// Internal access modifier
//When we declare a type or type member as internal, it can be accessed only within the same assembly.
//An assembly is a collection of types (classes, interfaces, etc) and resources (data). They are built to work together and form a logical unit of functionality.
//That's why when we run an assembly all classes and interfaces inside the assembly run together.



namespace _3___Access_Modifiers
{

    class clsA
    {
        public int x1 = 10;
        private int x2 = 20;
        protected int x3 = 30;


        public int func1()
        {
            return 100;
        }

        private int func2()
        {
            return 200;
        }

        protected int func3()
        {
            return 300;
        }
    }


    class clsB : clsA
    {
        // private members are inherited by derived classes but remain inaccessible
        public int func4()
        {
            // inside the sub class i can reach protected members of base class, like x3
            return x1 + x3;
        }

    }




    internal class Program
    {
        static void Main(string[] args)
        {

            clsA A = new clsA();
            Console.WriteLine("only publics are accessed from objects:");
            Console.WriteLine("x1 = {0}", A.x1);
            Console.WriteLine("func1 = {0}", A.func1());

            // cant access x2,x3 and func2,3 cuz they are protected and private


            // even for sub classes, can only reach public from objects.
            // regarding inherited protected members, only accessed in the class not the object
            clsB B = new clsB();
            Console.WriteLine("inherited public member  x1 = {0}", B.x1);
            


        }
    }
}
