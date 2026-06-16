using System.Numerics;

namespace _34__Generics___Generics_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // the input parameter will be implicitly known
            Print("Abdullah");
            Print(4);

            // can also explicitly delcare the data type, but no need
            Print<int>(4);

            //using the sum method to return a value
            Console.WriteLine($"sum method result: {Sum(1, 3)}"); 
        }



        // 1- generic methods: 
        // Print<this is Type Parameter> which is the generic data type that will be worked with
        // (T value) type of data will be recieved
        public static void Print<T>(T value)
        {
            Console.WriteLine($"\nData type of recieved data: {typeof(T)}");
            Console.WriteLine($"Value recieved: {value}");
        }


        // a generic method with a return value:
        // the where T : INumber<T> is just a constraint to specify that the type parameter will be a number,
        // otherwise it wont accept the addition of the two parameters, cuz T can be any data type
        // explained in next lessons
        public static T Sum<T>(T value1, T value2) where T : INumber<T>
        {
            return value1 + value2;
        }

    }
}
