namespace TestNamespace
{
    /* =================================================================================
     * SECTION 1: THE PROBLEM (Why does 'Type' exist?)
     * =================================================================================
     * In old languages, after compilation, code usually loses its structural names. Without the 'Type' 
     * class, an executing program cannot inspect its own structure at runtime. This 
     * makes it impossible to build dynamic tools (like generic JSON serializers or 
     * ORMs) that need to examine unknown classes on the fly.

    * =================================================================================
     * SECTION 2: THE CORE IDEA
     * =================================================================================
     * .NET solves this via "Reflection", where 'System.Type' is the central core.
     * Think of 'Type' as a runtime "mirror" or blueprint object representing any 
     * C# type (Class, Struct, int, etc.). Getting a 'Type' object gives you the 
     * full catalog to dynamically inspect that type's members.
     *

     * =================================================================================
     * SECTION 3: HOW IT WORKS INTERNALLY
     * =================================================================================
     * Compilation produces an Assembly (.DLL/.EXE) containing IL Code and Metadata Tables 
     * (a database of all code structures). When you call 'typeof(TestClass)', the CLR 
     * queries these tables and returns a 'System.RuntimeType' instance (inheriting 'Type') 
     * filled with pointers to that class's layout in memory.
     */
 

    internal class Program
    {
        // The Type class is a central class in reflection, representing a type in C#.
        // we use it to get and navigate the information about a type, such as its methods, properties, fields, and events.

        Type type0 = typeof(Employee);
        // typeof(Employee); <- this will return a reference to an object of RuntimeType class (hidden by microsoft) which has memebers that we use like name, fullname, IsClass
        // the CLR will take the metadata after this file is compiled into exe file + metadata, then since we used reflection on Employee, and Employee metadata is available
        // the CLR will query the metadata table and store the data in a RuntimeType object on heap.
        // then the RuntimeType object is upcasted to its base class Type, the reasons of upcasting to the base class Type are:

        //1. Encapsulation & Security: 'System.RuntimeType' is an internal, implementation-specific class. 
        //   Microsoft hides it so developers cannot access internal CLR methods or break runtime memory management,
        //   so they give us the base class Type as a reference variable to access certain memebrs of subclass RuntimeType.

        // 2. Unified API (Polymorphism): 'Employee' isn't the only thing that needs a descriptive object of RuntimeType class.
        //    .NET handles completely different types of structures in memory, such as Dynamic Types or external COM Objects.
        //    Each of these has its own specific, hidden internal descriptive class written completely differently from 'RuntimeType'.
        //    
        //    This is where the magic of Upcasting comes in: since all these diverse internal catalog classes are forced 
        //    to inherit from the shared abstract 'System.Type' base class, you can use a single 'Type' reference variable 
        //    to store and interact with ANY type in .NET using the exact same methods and properties, without caring 
        //    about the underlying concrete implementation.

        //3. Backward Compatibility & Flexibility: It decoupling the public API from the internal engine. 
        //    Microsoft can completely rewrite how 'RuntimeType' works internally in future .NET versions, 
        //    but your code won't break because your code only depends on the stable 'System.Type' base class.


        public static object GetUnknownType()
        {
            string input = "4";

            if (int.TryParse(input, out int number))
            {
                // we check if user entered a number then return an int object at run time
                return number;
            }
            else
            {
                // we check if user didnt enter a number then return a string object at run time
                return "";
            }
        }

        static void Main(string[] args)
        {
            // ======================================================= ++++ Obtaining Types ++++ ======================================================= \\


            // getting metadata of DateTime class from the assembly it was defined in, then return a RuntimeType object filled with info upcasted to a Type class

            // 1- At runtime,
            // if we dont know what objects will be sent to us to check, we initially define an object data type, which is a base for all data types
            // then we use GetType to get the actual type in runtime:
            object unknown = GetUnknownType();
            Type typeTest = unknown.GetType(); // if user passes a string, then this will be a string Type

            // 2- At compile time,
            // we already know the objects when writing the code, so we use typeof
            Type type = typeof(DateTime);
            Console.WriteLine("the Type info:");
            Console.WriteLine($"type name: {type.Name}");
            Console.WriteLine($"type full name: {type.FullName}");
            Console.WriteLine($"is this type a class?: {type.IsClass}");

            // or any class
            Type type1 = typeof(int);
            Console.WriteLine("\n\nthe Type1 info:");
            Console.WriteLine($"type name: {type1.Name}");// returns TypeName
            Console.WriteLine($"type name: {type1.Namespace}");// returns Namespace
            Console.WriteLine($"type full name: {type1.FullName}"); // returns Namespace.TypeName
            Console.WriteLine($"type full name: {type1.BaseType}"); // returns base type where int is inheriting, value type
            Console.WriteLine($"is this type a class?: {type1.IsClass}");


            // =================  Obtaining info of nested types, example is classes defined inside a class (nested):
            Type employeeType = typeof(Employee);
            Console.WriteLine($"\n\nEmployee Type Name: {employeeType.Name}");

            // must be in an array to store all nested types of class Employee
            Type[] nestedTypes = typeof(Employee).GetNestedTypes();

            for (byte i = 0; i < nestedTypes.Length; i++)
            {
                Console.WriteLine($"Nested type Name of index {i}: {nestedTypes[i].Name}");
            }


            // =================  Obtaining info about interfaces inherited by a certain type:

            Type[] interfacesOfType = typeof(int).GetInterfaces();

            Console.WriteLine("\n\nInterfaces inherited by Int type");
            for (byte i = 0; i < interfacesOfType.Length; i++)
            {
                Console.WriteLine($"Interface Name:{interfacesOfType[i].Name}");
            }
        }
    }

    public class Employee
    {
        public string name { get; set; }

        // this is composition, will not be showm in the nestedTypes
        public FullTimeEmployee fullTime  = new FullTimeEmployee();

        // this is nested class, will be shown in nestedTypes
        public class FullTimeEmployee
        {
        }

        public class PartTimeEmployee
        {
        }

        public void testvoid1()
        {
        }
    }
}
