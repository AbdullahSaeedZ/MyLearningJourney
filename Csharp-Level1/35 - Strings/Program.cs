using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35___Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string S1 = "Abdullah Alzahrani";

            Console.WriteLine(S1.Length);

            //this will take 5 characters staring position 2
            Console.WriteLine(S1.Substring(2, 5));
            Console.WriteLine(S1.ToLower());
            Console.WriteLine(S1.ToUpper());
            Console.WriteLine(S1[2]);
            Console.WriteLine(S1.Insert(3, "KKKK"));
            Console.WriteLine(S1.Replace("a", "*"));
            Console.WriteLine(S1.IndexOf("a"));
            Console.WriteLine(S1.Contains("a"));
            Console.WriteLine(S1.Contains("x"));
            Console.WriteLine(S1.LastIndexOf("a"));

            string S2 = "Ali,Ahmed,Khalid";

            // this is the split function we made in c++ lol
            string[] NamesList = S2.Split(',');

            Console.WriteLine(NamesList[0]);
            Console.WriteLine(NamesList[1]);
            Console.WriteLine(NamesList[2]);

            string S3 = "  Abdullah  ";
            Console.WriteLine(S3.Trim());
            Console.WriteLine(S3.TrimStart());
            Console.WriteLine(S3.TrimEnd());

            /////////////  more info about string in C#  ///////////
            

            /*
                ===============================================================
                🔹 String Immutability in C#
                ===============================================================

                In C#, "string" is IMMUTABLE — means once created, it cannot be changed.

                Every modification (like +=, Replace, ToUpper, Substring) creates a **new object**
                instead of modifying the existing one.

                ===============================================================
                🔸 Example 1 – Basic modification
                ===============================================================
                */

            string s = "Hello";
            s += " World";
            Console.WriteLine(s); // Output: Hello World

            /*
            Here, "Hello" and "Hello World" are two different objects in memory.
            C# created a new string object and made variable `s` point to it.
            The old one ("Hello") will be cleaned later by the Garbage Collector.

            ---------------------------------------------------------------
            C++ Equivalent:
            ---------------------------------------------------------------

            int main() {
                string s = "Hello";
                s += " World";
                cout << s;
            }

            → In C++, std::string is MUTABLE.
            The same memory of the object `s` is updated directly — no new object created.
            */

            /*
            ===============================================================
            🔸 Example 2 – Same reference or new one?
            ===============================================================
            */

            string a = "test";
            string b = a;
            b += "ing";

            Console.WriteLine(a); // test
            Console.WriteLine(b); // testing

            /*
            In C#:
            - Both `a` and `b` pointed to the same "test" string initially.
            - Once you modified `b`, a NEW object "testing" was created.
            - `a` still points to the old "test".

            ---------------------------------------------------------------
            C++ Equivalent:
            ---------------------------------------------------------------

            string a = "test";
            string b = a;   // Creates a copy using copy constructor
            b += "ing";

            cout << a << endl; // test
            cout << b << endl; // testing

            → In C++, `b` is a separate copy already, and its internal memory changes in place.
            */

            /*
            ===============================================================
            🔸 Example 3 – String Interning (C# only)
            ===============================================================
            */

            string x = "Hi";
            string y = "Hi";

            Console.WriteLine(Object.ReferenceEquals(x, y)); // True (same reference)

            y += "!"; // Now y points to a new object

            Console.WriteLine(Object.ReferenceEquals(x, y)); // False

            /*
            C# optimizes memory by storing identical string literals
            in a special area called the "Intern Pool".
            If you modify one of them, a new object is created.

            This behavior doesn't exist in C++.
            */

            /*
            ===============================================================
            🔸 Summary Table
            ===============================================================

            | Comparison            | C# string          | C++ std::string     |
            |------------------------|--------------------|---------------------|
            | Mutable?               | ❌ No (Immutable)  | ✅ Yes (Mutable)    |
            | Memory type            | Managed (Heap + Intern Pool) | Stack/Heap        |
            | When modified          | Creates new object | Edits same memory   |
            | Memory management      | Automatic (GC)     | RAII / Manual       |
            | Alternative for heavy edits | StringBuilder | Not needed usually  |

            ===============================================================
            🔸 Tip:
            ===============================================================
            Use StringBuilder when you need to modify text repeatedly:

            using System.Text;
            StringBuilder sb = new StringBuilder("Abdullah");
            sb.Append(" Alzahrani");
            sb.Replace("Abdullah", "Abood");

            Console.WriteLine(sb.ToString()); // "Abood Alzahrani"

            ===============================================================
            End of Note
            ===============================================================
            */



        }
    }
}
