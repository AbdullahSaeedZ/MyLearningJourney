using System;


// Lambda Function is a function that has no a name and a shorthanded syntax

namespace _3__Anonymous_Methods___Lambda_Expressions
{

    delegate int delOperations(int x, int y);
    delegate string delPrintHello(string name);
    delegate void delSayHi();

    internal class Program
    {
        static void Main(string[] args)
        {
            // 1- this is delegate as we learned:
            // we used delegate to reference the Add method that we declared before:
            delOperations del1 = add;
            delOperations del2 = subtract;
            Console.WriteLine(del1(5, 10));
            Console.WriteLine(del2(5, 10));

            // but in c# v2 in about 2005, they introduced anonymous methods
            // anonymous methods allow us to define a method in the delegate declaration without having to declare methods outside:
            // we became able to write less code with anonymous methods:
            delOperations del3 = delegate (int x, int y) // called anonymous, cuz no name, only parameters list and logic to execute
            {
                return x + y;
            };

            // this way is also called in-line methods, cuz defined and linked to delegate in the same line, no outside declared functions
            delOperations del4 = delegate (int x, int y) 
            {
                return x - y;
            };

            Console.WriteLine(del3(4, 6));
            Console.WriteLine(del4(4, 6));

            // later in C# v3 in about 2008, they introduced Lambda expressions to write even less code, and this became more popular in modern c# code
            // parameter list + => to refer to the logic + the logic
            delOperations delLambda = (int x, int y) => x * y;
            Console.WriteLine(delLambda(2, 3));

            // if more logic code, we open curly brackets and the logic, if we have parameters then we put return:
            delOperations delLambda2 = (int x, int y) =>
             {
                 // lines of code
                 return x * y;
             };


            // can use Lambda with void delegates:
            delSayHi hi = () => Console.WriteLine("hi there");
            hi();

            // or any delegate:
            delPrintHello nameHello = (string name) => "Hello " + name;
            Console.WriteLine(nameHello("abullah")); 
        }



        static public int add(int x, int y)
        {
            return x + y;
        }
        static public int subtract(int x, int y)
        {
            return x - y;
        }



    }


   
}
