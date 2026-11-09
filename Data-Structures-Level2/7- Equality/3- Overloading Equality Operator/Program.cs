/*
================================================================================
LESSON 03: Overloading the == and != Operators
================================================================================

1. THE PROBLEM:
In Lesson 02, we overrode `.Equals()` so `person1.Equals(person2)` returns True. 
However, `person1 == person2` STILL returns False! Overriding `.Equals()` does 
NOT automatically update the `==` operator.

2. THE CORE IDEA (Two Independent Mechanisms):
In C#, `.Equals()` and `==` have no automatic connection:
- Tool 2 (`.Equals()`): A virtual method inherited from `System.Object` (Overridden).
- Tool 1 (`==`): A static operator belonging to the class (Overloaded).

To make `==` compare data (Value Equality) instead of memory addresses, we must 
explicitly overload `operator ==` and tell it to call our `.Equals()` method.

   BEFORE OVERLOADING ==                     AFTER OVERLOADING ==
   person1 == person2                        person1 == person2
           |                                         |
           v                                         v
   [ Checks Memory Addresses ]               [ Calls person1.Equals(person2) ]
           |                                         |
           v                                         v
         FALSE                                     TRUE

3. HOW IT WORKS INTERNALLY (The 3-Step Operator Formula):
When overloading `==`, we cannot just write `return left.Equals(right);` 
because if `left` is `null`, calling `left.Equals()` will crash the program 
with a `NullReferenceException`. Instead, we use a strict 3-step check:

   [ left == right ]
           |
           +--> Step 1: ReferenceEquals(left, right)
           |    (Are both pointing to the exact same address, or are BOTH null?)
           |    If Yes --> Return TRUE immediately (Fastest path!).
           |
           +--> Step 2: left is null || right is null
           |    (Is only ONE of them null?)
           |    If Yes --> Return FALSE immediately (Prevents null crash!).
           |
           +--> Step 3: return left.Equals(right)
                (Both are guaranteed non-null objects --> Run our Lesson 02 logic!).

4. PITFALL:
- C# Compiler Rule: `==` and `!=` are a mandatory pair. If you overload `==`, 
  the compiler forces you to also overload `!=` (which simply returns `!(left == right)`).
================================================================================
*/

using System;

namespace EqualityLessons;

public class Person
{
    public string Name { get; set; }

    // From Lesson 02: Custom Value Equality for Tool 2 (.Equals)
    public override bool Equals(object? obj)
    {
        return obj is Person other && Name == other.Name;
    }

    public override int GetHashCode()
    {
        return Name?.GetHashCode() ?? 0;
    }

    // =========================================================================
    // NEW IN LESSON 03: Overloading Tool 1 (== and != Operators)
    // =========================================================================
    public static bool operator ==(Person? left, Person? right)
    {
        // Step 1: Same memory address (or both are null)?
        if (ReferenceEquals(left, right))
            return true;

        // Step 2: Is one of them null? (Using 'is null' avoids triggering '==' again!)
        if (left is null || right is null)
            return false;

        // Step 3: Safe to call our overridden Equals() method
        return left.Equals(right);
    }

    public static bool operator !=(Person? left, Person? right)
    {
        // Reuse the == operator and flip the result
        return !(left == right);
    }
}

class Lesson03_OverloadingEqualityOperator
{
    static void Main()
    {
        // Two separate objects in memory (Different Heap Addresses: 0x10 vs 0x20)
        Person person1 = new Person { Name = "Ahmed" };
        Person person2 = new Person { Name = "Ahmed" };

        Console.WriteLine("=== Checking All 3 Comparison Tools Now ===");
        
        // Tool 1 (==) now forwards the check to .Equals()!
        Console.WriteLine($"1. == Operator       : {person1 == person2}");                  // True
        Console.WriteLine($"   != Operator       : {person1 != person2}");                  // False

        // Tool 2 (.Equals) compares the Name property
        Console.WriteLine($"2. .Equals() Method  : {person1.Equals(person2)}");             // True

        // Tool 3 (ReferenceEquals) CANNOT be overridden—still checks memory addresses!
        Console.WriteLine($"3. ReferenceEquals() : {ReferenceEquals(person1, person2)}");   // False
    }
}