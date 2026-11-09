/*
================================================================================
LESSON 01: The Big Picture — Reference vs. Value Equality & The 3 Tools
================================================================================

1. THE PROBLEM:
When you create two objects with the exact same data and compare them, C# returns 
False. By default, C# checks if they are the same object in memory, not if they 
hold the same data.

2. THE CORE IDEA (2 Types of Equality):

A) Value Equality (Same Data, Different Objects):
   Two separate houses built from the same blueprint.

   STACK (Variables)          HEAP (Memory)
   +---------+                +------------------------+
   | person1 | -------------> | Person { Name="Ahmed"} | (Address: 0x10)
   +---------+                +------------------------+
   +---------+                +------------------------+
   | person2 | -------------> | Person { Name="Ahmed"} | (Address: 0x20)
   +---------+                +------------------------+

B) Reference Equality (Same Object in Memory):
   Two people holding the address to the exact same house.

   STACK (Variables)          HEAP (Memory)
   +---------+
   | person1 | ------+
   +---------+       |        +------------------------+
                     +------> | Person { Name="Ahmed"} | (Address: 0x10)
   +---------+       |        +------------------------+
   | person3 | ------+
   +---------+

3. HOW IT WORKS INTERNALLY (The 3 Comparison Tools in C#):
To compare objects, C# gives you 3 tools. By default, for any custom class, 
ALL THREE check Reference Equality (memory addresses):

   +---------------------------+---------------------+-------------------------+
   | Tool                      | Default Behavior    | Can We Customize It?    |
   +---------------------------+---------------------+-------------------------+
   | 1. == (Operator)          | Reference Equality  | Yes (Overload in L03)   |
   | 2. .Equals() (Method)     | Reference Equality  | Yes (Override in L02)   |
   | 3. ReferenceEquals()      | Reference Equality  | NO  (Locked safety net) |
   +---------------------------+---------------------+-------------------------+

4. PITFALL:
- Assuming `==` or `.Equals()` compares properties inside your class automatically. 
  Unless you explicitly customize Tools 1 and 2, they only check if both 
  variables point to the exact same memory address.
================================================================================
*/

using System;

namespace EqualityLessons;

public class Person
{
    public string Name { get; set; }
}

class Lesson01_TheBigPicture
{
    static void Main()
    {
        // =====================================================================
        // CASE A: Two Separate Objects with Identical Data
        // Each 'new' allocates a different address on the Heap (0x10 vs 0x20).
        // =====================================================================
        Person person1 = new Person { Name = "Ahmed" };
        Person person2 = new Person { Name = "Ahmed" };

        Console.WriteLine("=== Case A: Same Data, Different Memory Addresses ===");
        Console.WriteLine($"1. == Operator       : {person1 == person2}");                  // False
        Console.WriteLine($"2. .Equals() Method  : {person1.Equals(person2)}");             // False
        Console.WriteLine($"3. ReferenceEquals() : {ReferenceEquals(person1, person2)}");   // False


        // =====================================================================
        // CASE B: Two Variables Pointing to the Exact Same Object
        // No 'new' keyword. Both hold the exact same Heap address (0x10).
        // =====================================================================
        Person person3 = person1;

        Console.WriteLine("\n=== Case B: Same Memory Address ===");
        Console.WriteLine($"1. == Operator       : {person1 == person3}");                  // True
        Console.WriteLine($"2. .Equals() Method  : {person1.Equals(person3)}");             // True
        Console.WriteLine($"3. ReferenceEquals() : {ReferenceEquals(person1, person3)}");   // True
    }
}