using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30___Dynamic_Type
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 'dynamic' type: resolved at runtime, not compile time
            // Type can change during execution

            dynamic MyDynamicVar = 100;
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());

            MyDynamicVar = "Hello World!!";
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());

            MyDynamicVar = true;
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());

            MyDynamicVar = DateTime.Now;
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());


            // difference:
            // var → type decided at compile time (cannot change later)
            // dynamic → type decided at runtime (can change anytime)

            var x = 5;
         // x = "text";   // it is given int at first, so data type became int and cant change it

            dynamic y = 5;
            y = "text";   // it is dynamic , type can be changed dynamically in run-time

        }
    }
}
