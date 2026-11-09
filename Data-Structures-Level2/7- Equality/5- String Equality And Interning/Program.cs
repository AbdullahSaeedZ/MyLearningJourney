/*
================================================================================
LESSON 05: String Equality & String Interning
================================================================================

1. THE PROBLEM:
`string` is a reference type (a class), so you would expect two different 
string objects to return False when compared with `==`. Yet, in C#, two strings 
with the exact same letters return True for both `==` and `.Equals()`. Why?

2. THE CORE IDEA (Built-in Overrides & Interning):
Microsoft pre-configured `System.String` with two special behaviors:
- Built-In Overrides: `string` already overrides `.Equals()` and overloads `==` 
  to compare character-by-character (Value Equality) out of the box.
- String Interning: A runtime memory optimization where identical text literals 
  are automatically pointed to the exact same memory address.

   STRING INTERNING (Memory Optimization):
   string str1 = "Hello";  ---> [ Allocates "Hello" in Intern Pool (0x50) ] <--- string str2 = "Hello";
   
   Because both share 0x50, ReferenceEquals(str1, str2) returns True!

3. HOW IT WORKS INTERNALLY (Literal vs. Explicit Construction):
String interning only happens automatically for literal text strings written in 
your code. If you build a string dynamically at runtime (like reading 
from a file, user input, or array conversion), it allocates a brand-new object 
in memory, bypassing the intern pool.

   - Literal String:      string a = "Hello"; (Shares pool address)
   - Dynamic Allocation:  string b = new string("Hello".ToCharArray()); (Forces new memory address)

4. PITFALL:
- Assuming `ReferenceEquals()` will always return False for strings. Because of 
  string interning, identical string literals share memory addresses, causing 
  `ReferenceEquals()` to return True unexpectedly.
================================================================================
*/

using System;

namespace EqualityLessons;

class Lesson05_StringEqualityAndInterning
{
    static void Main()
    {
        // =====================================================================
        // SCENARIO 1: String Literals (Triggering String Interning)
        // =====================================================================
        string str1 = "Hello";
        string str2 = "Hello";

        Console.WriteLine("=== 1. String Literals (Interned) ===");
        Console.WriteLine($"str1 == str2               : {str1 == str2}");               // True (Value match)
        Console.WriteLine($"str1.Equals(str2)          : {str1.Equals(str2)}");          // True (Value match)
        // Interning optimization makes both point to the exact same memory address!
        Console.WriteLine($"ReferenceEquals(str1, str2): {ReferenceEquals(str1, str2)}"); // True


        // =====================================================================
        // SCENARIO 2: Explicitly Constructed Strings (Bypassing Interning)
        // =====================================================================
        string str3 = new string("Hello".ToCharArray());
        string str4 = new string("Hello".ToCharArray());

        Console.WriteLine("\n=== 2. Explicitly Constructed Strings (Separate Memory) ===");
        Console.WriteLine($"str3 == str4               : {str3 == str4}");               // True (Value match)
        Console.WriteLine($"str3.Equals(str4)          : {str3.Equals(str4)}");          // True (Value match)
        // Separate memory objects created on the Heap
        Console.WriteLine($"ReferenceEquals(str3, str4): {ReferenceEquals(str3, str4)}"); // False
    }
}