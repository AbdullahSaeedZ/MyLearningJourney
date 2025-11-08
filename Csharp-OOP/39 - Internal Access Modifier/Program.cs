using System;


// internal means the class is only seen inside the namespace, outside the namespace it is private and cant be reached.
// so internal is accessed only in the same assembly whether .dll or .exe
// public means reachable within the solution

/*
Default Access Levels in C#:

1. Top-level types (class, struct, interface, enum, delegate)
   - Default access level: internal
   - Meaning: The type is only accessible within the same assembly (.exe or .dll).

2. Members inside a class (fields, methods, properties)
   - Default access level: private
   - Meaning: The member is only accessible within the same class.
*/


using Data;

namespace _39___Internal_Access_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // this is a public class in the Data namespace, so i can access it here in another namespace.
            Books book1 = new Books();
            book1.BookName = "book1";

            // but Papers class is internal, which means i can only access it within the Data namespace only
            
        }
    }
}
