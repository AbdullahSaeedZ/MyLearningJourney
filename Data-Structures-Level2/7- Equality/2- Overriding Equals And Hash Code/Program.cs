/*
================================================================================
LESSON 02: Overriding Equals() and GetHashCode()
================================================================================

1. THE PROBLEM:
C# cannot guess which properties inside your class make two objects "equal". 
To compare objects by data (Value Equality), we must customize Tool 2: .Equals().

2. THE CORE IDEA (Overriding .Equals):
Every class in C# inherits from `System.Object`, which owns a virtual method 
called `Equals(object obj)`. By using `override`, we replace C#'s default 
memory-address check with our own property-by-property check.

   DEFAULT .Equals()                     OVERRIDDEN .Equals()
   +------------------------+            +-------------------------------+
   | Is Address1 == Address2|  ------->  | Is person1.Name == person2.Name|
   +------------------------+            +-------------------------------+

We also need to override the default GetHashCode() method, in order to
make comparisons work with certain data structures.

3. HOW GetHashCode() WORKS (Hashing = Input -> Formula -> Output):
   Hashing always works the same way: give it the exact same INPUT, and it 
   produces the exact same integer OUTPUT. Give it a different input, and you get 
   a different output.
   
      A) DEFAULT GetHashCode() (Input = Memory Address):
         By default, C# feeds the object's memory address (identity) as the INPUT 
         into the hashing formula.
         
         person1 --> Input: Address 0x10 --> [ Hash Formula ] --> Output: 11111
         person2 --> Input: Address 0x20 --> [ Hash Formula ] --> Output: 99999
         
         Result: Two different objects have different addresses (different inputs), 
         so they produce different hash codes—meaning collections like HashSet 
         and Dictionary treat them as NOT equal.
   
      B) OVERRIDDEN GetHashCode() (Input = Object's Data):
         When we override `Equals()` to compare data (`Name`), we MUST also override 
         `GetHashCode()` so it uses that exact same data (`Name`) as the INPUT 
         instead of the memory address.
         
         person1 --> Input: "Ahmed" --> [ Hash Formula ] --> Output: 50505
         person2 --> Input: "Ahmed" --> [ Hash Formula ] --> Output: 50505
         
         Result: Now both objects feed the exact same input ("Ahmed") into the 
         formula, producing the exact same hash code output.
   
      C) WHERE DOES THIS FIT & WHY IS IT USED? (The Missing Link):
         Collections like `Dictionary` and `HashSet` DO NOT call `.Equals()` 
         right away because comparing every property across 1,000,000 items is too slow.
         Instead, they use a fast 2-Step Gatekeeper when searching for an object:
   
         [ Search for person2 ]
                   |
                   v
         STEP 1: Check GetHashCode() first (Fast Integer Check)
                 - Different Hash Codes? --> STOP IMMEDIATELY! Return False. (.Equals() is NEVER called!)
                 - Identical Hash Codes? --> PASS to Step 2!
                   |
                   v
         STEP 2: Call .Equals() (Exact Property Check)
                 - Confirms the actual data matches 100% and returns True.
   
         Bottom Line: `GetHashCode()` is the entry ticket required to reach `.Equals()` 
         inside hash-based collections. If their hash codes don't match, C# 
         assumes they cannot be equal and skips `.Equals()` completely.

4. PITFALL:
- Overriding `.Equals()` does NOT automatically change the `==` operator. They 
  are independent mechanisms (we will fix `==` in Lesson 03).
================================================================================
*/

using System;
using System.Collections.Generic;

namespace EqualityLessons;

public class Person
{
    public string Name { get; set; }

    // 1. Override Equals to compare data instead of memory addresses
    public override bool Equals(object? obj)
    {
        // Check if obj is a Person (and not null), then compare the Name property
        return obj is Person other && Name == other.Name;
    }

    // 2. Override GetHashCode so equal data produces the exact same bucket number
    public override int GetHashCode()
    {
        // Delegate the hash calculation to the Name string's value
        return Name?.GetHashCode() ?? 0;
    }
}

class Lesson02_OverridingEqualsAndHashCode
{
    static void Main()
    {
        // Two separate objects in memory (Different Heap Addresses: 0x10 vs 0x20)
        Person person1 = new Person { Name = "Ahmed" };
        Person person2 = new Person { Name = "Ahmed" };

        Console.WriteLine("=== 1. Testing Our 3 Comparison Tools ===");
        Console.WriteLine($"1. == Operator       : {person1 == person2}");                  // False (Still checks addresses!)
        Console.WriteLine($"2. .Equals() Method  : {person1.Equals(person2)}");             // True  (Now checks Name!)
        Console.WriteLine($"3. ReferenceEquals() : {ReferenceEquals(person1, person2)}");   // False (Always checks addresses)

        Console.WriteLine("\n=== 2. Proof of Why GetHashCode() Matters ===");
        Console.WriteLine($"person1 Bucket Number (Hash): {person1.GetHashCode()}");        // Same int
        Console.WriteLine($"person2 Bucket Number (Hash): {person2.GetHashCode()}");        // Same int

        // HashSet uses Step 1 (GetHashCode) then Step 2 (Equals)
        HashSet<Person> uniquePeople = new HashSet<Person>();
        uniquePeople.Add(person1);

        // Because both produce the same HashCode, HashSet checks the right bucket, 
        // runs .Equals(), and knows "Ahmed" is already inside!
        Console.WriteLine($"Does HashSet contain person2? : {uniquePeople.Contains(person2)}"); // True
    }
}