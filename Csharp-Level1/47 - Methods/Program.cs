using System; // Base namespace for core classes like Console, Math, etc.

namespace _47___Methods // A namespace is like a folder grouping related classes
{
    internal class Program // "internal" = visible only inside this project/assembly
    {
        // Access modifiers define visibility:
        // public → visible everywhere
        // private → visible only inside this class (default for members)
        // protected → visible in this class + derived classes
        // internal → visible within this project
        // protected internal / private protected → hybrid visibility levels

        void Test(int name) // Default is "private" since no modifier is specified; non-static (requires an object)
        {
            // Example: Program p = new Program(); p.Test(10);
        }

        public static void PrintMyInfo(string Name, byte Age) // "public" = accessible from anywhere; static = belongs to the class itself
        {
            Console.WriteLine("Name= {0} , Age= {1}", Name, Age);
        }

        private static void Main(string[] args) // "private" = visible only inside this class; must be static as program entry point
        {
            // C# is fully OOP — all methods must be inside a class. Use static for direct access without creating an object.
            PrintMyInfo("Abdullah Alzahrani", 100);

            // Example of calling instance method:
            // Program obj = new Program();
            // obj.Test(10);
        }
    }
}

// the rest is same as C++