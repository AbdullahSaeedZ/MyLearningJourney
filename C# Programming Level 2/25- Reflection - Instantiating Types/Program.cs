using System.Reflection;
using System.Runtime.Remoting;

namespace TestProject
{
    // ============================================ instantiating objeccts using Types and reflection ============================================ \\
    internal class Program
    {
        static void Main(string[] args)
        {
            // instantiate an integer:
            int i = new int(); // default of 0
            i = 5;

            // another way to instantiate an integer is by using Reflection:
            // we use Activator class, which takes a type as parameter and returns an object of Object data type then we explicitly cast it as needed:
            int a = (int)Activator.CreateInstance(typeof(int));
            a = 3;

            // but the issue is that Activator.CreateInstance(typeof(int)) will return an Object data type, which will be stored in heap with default of 0 value
            // and that is called boxing, where we box a value type in an object in heap, then we unbox by casing to int to store it in stack
            // that is overhead and a waste of performance, solution is a new approach of returning a generic T Type directly,not an object in heap, unless T is a reference type:
            // - if T is a value type (like int): it constructs the instance directly on the Stack (no heap allocation,No Boxing)
            // - if T is a reference type (like class): it instantiates it on the heap normally
            int newApproach = Activator.CreateInstance<int>();

            //   THE TRADE-OFF (Generics vs Old method with casting)
            // - Activator.CreateInstance<T>() is highly optimized but limited to types known at compile-time 
            //   and primarily handles default (parameterless) constructors.
            // - The Non-Generic Activator can face the boxing/unboxing overhead buy it has many overloads allowing ultimate flexibility at runtime, 
            //   such as passing constructor arguments, invoking private constructors, or instantiating types via strings.


            // another way to instantiate a reference type with parameterless ctor:
            object emp = Activator.CreateInstance(typeof(Employee));

            // or with casting:
            Employee emp1 = (Employee)Activator.CreateInstance(typeof(Employee));
            Console.WriteLine(emp1);

            // another way to instantiate a reference type with parameterized ctor using another overload in Activator:
            // Example of Old Approach flexibility (Passing parameters to a constructor at runtime):
            object[] constructorArgs = { "Ahmed", 2 }; // must be same order in the constructor
            Employee empWithParameters = (Employee)Activator.CreateInstance(typeof(Employee), constructorArgs);
            Console.WriteLine(empWithParameters);


            // ====================================== instantiating objects dynamically at run time =================================== \\

            // Example: A player in a game chooses a monster by name, then info will be shown.
            // Idea: Create certain objects dynamically at runtime by passing the class name as a string using Reflection.


            // Scenario 1: Using Activator with strings. This provides isolation capabilities (ObjectHandle). 
            // It is ideal if we are instantiating objects inside a separate/custom AppDomain (or AssemblyLoadContext in modern .NET)
            // so we can interact through a handle and eventually unload the entire domain/context to free memory.
            Console.WriteLine("\n\nEnter Name of Monster [Pixa - Toba - Meno]:");

            // the dll name will be dynamiclly recieved as string, also the class name which we will use to create the object
            string externalAssemblyName = "TestProject";
            string userInput = $"{externalAssemblyName}." + Console.ReadLine();

            // The Activator will look for the assembly using a searching method called the Probing Process (in Application directory, shared runtimes, and configured dependency paths)
            // It returns an ObjectHandle (a wrapper), which keeps the object isolated until we explicitly unwrap it to our current domain context.
            ObjectHandle chosenMonsterHandle = Activator.CreateInstance(externalAssemblyName, userInput);

            // Unwrap grants our current domain direct access to the object reference in the Heap.
            object chosenMonsterObj = chosenMonsterHandle.Unwrap();
            Console.WriteLine(chosenMonsterObj);



            // Scenario 2: Direct local instantiation using an Assembly object that is already active and loaded in our current AppDomain.
            Console.WriteLine("\n\nEnter Name of Monster [Pixa - Toba - Meno]:");
            string userInput2 = $"TestProject." + Console.ReadLine();

            // We already have the Assembly object in memory; we just lookup its metadata directly and instantiate immediately.
            Assembly gameAssembly2 = typeof(Program).Assembly;
            object chosenMonster2 = gameAssembly2.CreateInstance(userInput2); // Returns object directly, no handles, no unwrapping needed.
            Console.WriteLine(chosenMonster2);


        }
    }

    public class Employee
    {
        public string Name { get; set; } = "Abdullah";
        public int Age { get; set; } = 1;

        public Employee()
        {
        }

        public Employee(string Name, int Age)
        {
            this.Age = Age;
            this.Name = Name;
        }

        public override string ToString()
        {
            return $"Employee Name: {Name}, Age: {Age}";
        }
    }

    // monsters
    public class Pixa
    {
        public override string ToString()
        {
            return $"Monster Pixa is choosen with Power: {55}, Damage: {99}";
        }
    }

    public class Toba
    {
        public override string ToString()
        {
            return $"Monster Toba is choosen with Power: {82}, Damage: {43}";
        }
    }

    public class Meno
    {
        public override string ToString()
        {
            return $"Monster Meno is choosen with Power: {63}, Damage: {74}";
        }
    }
}


