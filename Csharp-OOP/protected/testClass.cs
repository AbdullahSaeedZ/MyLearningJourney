using System;

// protected internal = protected + internal

// Inside the same assembly:
// - It behaves like public (any class in the same DLL/EXE can access it)

// Outside the assembly:
// - It behaves like protected (only accessible through inheritance)



namespace MyLibrary
{
    public class Person   // ← must be public to allow inheritance from other projects
    {

        // this will be accessible outside assembly for only classes that inherits this class, and here in the assembly will be public (accessed from objects and anywhere)
        protected internal void Speak()   // ← accessible only through inheritance outside the assembly
        {
            Console.WriteLine("Hello");
        }

        // this will be accessible from any where in the other assembly 
        public void greet()
        {
            Console.WriteLine("greeting");
        }
    }


    public class boy
    {

        public void method()
        {
            Person p1 = new Person();
            p1.Speak(); // it is accessed here, it acts as public, but outside the assembly it is protected for inherited classes only
        }
    }
}