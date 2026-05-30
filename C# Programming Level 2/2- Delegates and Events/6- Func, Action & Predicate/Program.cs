using System;



namespace _6__Func__Action___Predicate
{
    //  Func is a just a generic delegate that is built inside .Net 
    // it is used to declare a delegate instance faster than the usual way
    delegate T delGen<T>(int a, int b);  // this the usual way to declare the delegate


    internal class Program
    {
        static void Main(string[] args)
        {
            // 1-
            // i already defined the delegate above, and here we create the instance
            delGen<int> delAdd = (int x, int y) => x + y;
            Console.WriteLine(delAdd(2,5));


            Console.WriteLine();
            // 2-
            // using Func:
            // structure of func is :    Func< parameter 1, parameter 2, ...up to 16 parameter,  return type>       // return type must be always written
            Func<int, int, int> funcAdd = (int x, int y) => x + y;
            Func<string, string> funcStr = (string name) => "Hi " + name;
            Func<string> funcNoPar = () => "just returning string";

            Console.WriteLine(funcAdd(3,7));
            Console.WriteLine(funcStr("Abdullah"));
            Console.WriteLine(funcNoPar());
            Console.WriteLine();

            // 3- 
            // using Action:
            // Action is just a Func that doesnt have a return type, it is void
            // structure of Action:  Action<up to 16 parameters>
            Action<string> actionStr = (string name) => Console.WriteLine(name);
            Action<int> actionIsEven = (int x) =>
            {
                if (x % 2 == 0)
                    Console.WriteLine("even");
                else
                    Console.WriteLine("Odd");
            };

            actionStr("using the void delegate");
            actionIsEven(6);

            Console.WriteLine();
            // 4- 
            // Predicate is just Func that takes ONE PARAMETER and its return type is bool
            // structure of Predicate:    Predicate<one parameter only> ,  it has bool return type, no need to write it
            Predicate<int> predIsEven = (int x) => x % 2 == 0;

            Console.WriteLine(predIsEven(5));


        }
    }
}
