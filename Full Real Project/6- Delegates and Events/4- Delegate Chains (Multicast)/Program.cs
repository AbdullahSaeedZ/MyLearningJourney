using System;

// delegate chaining is to have one delegate instance pointing to multiple methods at the same time

namespace _4__Delegate_Chains__Multicast
{

    delegate void delChains(string input);
    delegate string delString(string input);

    internal class Program
    {
        static void Main(string[] args)
        {
            ///////// PART1
            
            delChains del1 = Method1;  // instantiate the delegate and point it to a method
            del1("just showing");
            
            del1 = del1 + Method2;     // now we do chaining, which makes the delegate creates an array containing references of added (subscribed) methods, called Invocation List 
            // or compound operator:
            del1 += Method3;   // this called multicast delegate -> cuz it has multiple methods
            del1("all methods added");    // the delegate will run methods based on their order in the invocation list
            
            var InvList = del1.GetInvocationList();       // we can see the list using this method and breakpoint with debug mode
            
            del1 -= Method2;    // can remove methods references from the delegate
            del1("after removing");



            Console.WriteLine();
            // ------------------------------------------------------------------------------------------------------------------
            ///////// PART2
            // two important attributes of delegate:

            delChains del2 = Method1;

            Console.WriteLine(del2.Method); // this will get the method name that is references to by the delegate
            Console.WriteLine(del2.Target); // this will get the class instance (object) reference that the method is created in
                                            // in this case, it will show nothing cuz now method1 is static and doesnt belong to a class instance (object)

            
            MyClass temp = new MyClass();  // lets create an object and a method to try the target attribute

            delChains del3 = temp.MyClassMethod;

            Console.WriteLine(del3.Method);
            Console.WriteLine(del3.Target);

           
            Console.WriteLine(object.ReferenceEquals(del3.Target, temp));   // can run this to see that Target is the object reference that contains the method


            Console.WriteLine();
            // ------------------------------------------------------------------------------------------------------------------
            ///////// PART3 

            // using delegate chains with method that return values, i will use lambdas to practice it

            delString deleg = (string input) => $"method 1 : {input}";
            deleg += (string input) => $"method 2 : {input}";
            deleg += (string input) => $"method 3 : {input}";

            Console.WriteLine(deleg("last method returned value is the only one showed")); // each method in invocation list will return value but will be overridden with next method value and last one will show up
             


        }



        ///////// PART1
        public static void Method1(string input) 
        {
            Console.WriteLine($"Method 1: {input}");
        }

        public static void Method2(string input) 
        {
            Console.WriteLine($"Method 2: {input}");
        }

        public static void Method3(string input) 
        {
            Console.WriteLine($"Method 3: {input}");
        }


    }

    ///////// PART2
    class MyClass
    {
        public void MyClassMethod(string input)
        {
            Console.WriteLine("new class method");
        }
    }


}
