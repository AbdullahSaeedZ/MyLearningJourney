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
    public class TestClass
    {
        public int age { get; set; }
        public string name { get; set; }
        private void testvoid()
        {
        }
        public void testvoid1()
        {
        }
    }

    internal class Program
    {
        // The Type class is a central class in reflection, representing a type in C#.
        // we use it to get and navigate the information about a type, such as its methods, properties, fields, and events.
        
        static void Main(string[] args)
        {
            // 
            Type type = typeof(string);

            Console.WriteLine("the Type info:");
            Console.WriteLine($"type name: {type.Name}");
            Console.WriteLine($"type full name: {type.FullName}");
            Console.WriteLine($"is this type a class?: {type.IsClass}");


            // or any class such as this one i created above
            Type type1 = typeof(int);

            Console.WriteLine("\n\nthe Type1 info:");
            Console.WriteLine($"type name: {type1.Name}");
            Console.WriteLine($"type full name: {type1.FullName}");
            Console.WriteLine($"is this type a class?: {type1.IsClass}");


            // 
            Type type2 = typeof(TestClass);
            // typeof(TestClass); <- this will return a reference to an object of RuntimeType class (hidden by microsoft) which has memebers that we use like name, fullname, IsClass
            // the CLR will take the metadata after this file is compiled into exe file + metadata, then since we used reflection on TestClass, and TestClass metadata is available
            // the CLR will query the metadata table and store the data in a RuntimeType object on heap.
            // then the RuntimeType object is upcasted to its base class Type, the reasons of upcasting to the base class Type are:

            //1. Encapsulation & Security: 'System.RuntimeType' is an internal, implementation-specific class. 
            //   Microsoft hides it so developers cannot access internal CLR methods or break runtime memory management,
            //   so they give us the base class Type as a reference variable to access certain memebrs of subclass RuntimeType.

            // 2. Unified API (Polymorphism): 'TestClass' isn't the only thing that needs a descriptive object of RuntimeType class.
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


        }
    }
}
