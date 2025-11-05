using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23___Method_Overriding_in_C__Inheritance___Base_Keyword
{
    // shadowing = hiding
    // if no virtual keyword, it is just hiding not overriding

    public class Base
    {

        // if no virtual key word, then it is just hiding
        public virtual void myMethod()
        {
            Console.WriteLine("base class implementation of myMethod");
        }

        public virtual void myOtherMethod()
        {
            Console.WriteLine("base class implementation of myOtherMethod");
        }
    }

    public class Sub : Base
    {
        // when calling both methods below, it will show sub class methods not the base class, so whats the difference between hiding and overriding if they do the same thing?
        // the difference will be shown when using upcasting


        // overriding base class method (runtime polymorphism)
        public override void myMethod()
        {
            Console.WriteLine("sub class implementation of myMethod using overriding");
        }

        // hiding base class method, using new keyword ((hiding/shadowing, no polymorphism))
        public new void myOtherMethod()
        {
            Console.WriteLine("sub class implementation of myOtherMethod using hiding");
        }

    }




    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nbase object:\n");
            Base baseObj = new Base();
            baseObj.myMethod();
            baseObj.myOtherMethod();

            Console.WriteLine("\nusing overriding and hiding:\n");
            Sub subObj = new Sub();
            subObj.myMethod();
            subObj.myOtherMethod();



            Console.WriteLine("\nafter casting:\n");
            Base upCasted = subObj;
            upCasted.myMethod();     // due to overriding, the runtime poly has used sub class method, it has overridden the base one
            upCasted.myOtherMethod();  // but here due to hiding and not overriding, in runtime the base method is implemented


            //so in short words, when up casting , hiding is canceled and we see last overriding in the chain

        }
    }
}