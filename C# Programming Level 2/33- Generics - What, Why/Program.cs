namespace _33__Generics___What__Why
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // overloaded methods to reach reusabilty (a goal to reach a form of generalization)
            Print(3);
            Print("abdullah");


            // printing using the base object method:
            PrintByObj("\n\nkoko");
            PrintByObj(new { Fname = "alo", Lname = "alalo" }); // using anonymous object

        }

        // before generics, overloading and base object are used to kind of reach reusability,
        // but they have some drawbacks

        // ===============================================================  1- over loading example ===============================================================  \\
        // example of drawback:
        // 1- Low maintainability: if i need to maintain and edit the code, i will edit in more than one place
        // 2- DRY (dont repeat yourself): code is repeated 

        public static void Print(int num)
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // <- repeated in all overloaded function
            Console.WriteLine(num);
        }
        public static void Print(string str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // <- repeated in all overloaded function
            Console.WriteLine(str);
        }



        // =============================================================== 2- base object example ===============================================================  \\
        // since all types are eventually inheriting from the base object,
        // we can use it as a parameter to pass any data, then this way we reached reusability
        // example of drawback:
        // 1- No Type-Safety: we can pass all kind of types, co control on which data to be sent through parameters,
        // which can be a concern and a cause of errors, cuz in implementation we might have to cast the object but to which type ? 
        // 2- cant avoid mistakes
        // 3- low performance: since it is the base object, it we sent premitve types, then we will have boxing/unboxing process

        public static void PrintByObj(object obj)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(obj);
        }



        // =============================================================== solution with generics ===============================================================  \\
        
        // generics solve 3 issued with previous approaches:

        // 1- inrease usability: one class/method works with multiple data types
        // 2- type-safety: it provides a placeholder <T> for the type to work with, which allows to work with any data type sent to the generics
        // 3- no boxing/unboxing: no object base to box the value then unbox it


        // we have two types of generics:

        // 1- Generic Methods
        // 2- Generic Classes

        // explained in next lessons


    }
}
