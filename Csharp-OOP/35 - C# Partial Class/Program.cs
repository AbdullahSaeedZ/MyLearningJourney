using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;



// partial class is a class that has its implementation in different places

// The compiler will merge them into ONE single class at compile-time.
// we have MyClass in two different files and we can use them here in main
// all parts of a partial class should be in the same namespace.


/*
 - All parts must:
     • Be in the **same namespace**
     • Have the ** same class name**
     • Have the ** same access modifier** (public, internal, etc.)
     • Be available at** compile time** (not dynamically loaded)

- Partial class members are fully shared:
     ➜ Any field, property, or method declared in one part
        is visible to all other parts of the same class.

*/

// once we create a class file in the project, it is directly included here, not like C++ where we need to type #include

namespace _35___C__Partial_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MyClass obj = new MyClass();

            obj.method1();
            obj.method2();


        }
    }
}
