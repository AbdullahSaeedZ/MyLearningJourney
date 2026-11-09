/*
================================================================================
LESSON 04: Compile-Time (==) vs. Runtime (.Equals) & How ReferenceEquals Works
================================================================================

1. THE PROBLEM:
Even after you overload `==` and override `.Equals()` in `Person`, if you store 
your `Person` objects inside `object` variables (`object obj1 = person1;`), 
`obj1 == obj2` suddenly returns FALSE again, while `obj1.Equals(obj2)` still 
returns TRUE!

2. THE CORE IDEA (Static Binding vs. Dynamic Binding):
The compiler and the runtime treat Operators (`==`) and Virtual Methods (`.Equals()`) 
completely differently:

   VARIABLE DECLARATION:  object obj1 = new Person { Name = "Ahmed" };
                          \____/            \______________________/
                             |                         |
                    Compile-Time Type             Runtime Type
                   (The Label on Box)       (Actual Object in Heap)

   A) Tool 1 (`==` Operator) -> Resolved at COMPILE-TIME:
      The compiler only looks at the variable type on the left (`object`). 
      It does NOT look inside the Heap. Since the variable type is `object`, 
      it locks in `object == object` which checks memory addresses, because 
      == operator is not overloaded in Object class, we just overloaded it in Person class
      but in compile time, only object type is seen not the person type

   B) Tool 2 (`.Equals()` Method) -> Resolved at RUNTIME:
      Because `.Equals()` is a `virtual` method, C# waits until the program is 
      running, follows the pointer into the Heap, sees the actual object is a 
      `Person`, and executes `Person.Equals()` (which checks data).

3. HOW ReferenceEquals() USES THIS EXACT TRICK:
Look at the actual source code of `ReferenceEquals` inside .NET:

   public static bool ReferenceEquals(object objA, object objB)
   {
       return objA == objB;
   }

   Why doesn't `objA == objB` trigger `Person`'s overloaded `==` operator?
   Because the parameters `objA` and `objB` are typed as `object`! 
   At compile-time, the compiler permanently binds `objA == objB` to the 
   base `object == object` (memory address check). No class can ever bypass it.

4. PITFALL:
- Using `==` when working with base classes, `object`, or generics (`T`) where 
  the variable type doesn't match the specific child class. Always use `.Equals()` 
  when polymorphism is involved.
================================================================================
*/

using System;

namespace EqualityLessons;

public class Person
{
    public string Name { get; set; }

    public override bool Equals(object? obj) => obj is Person other && Name == other.Name;
    public override int GetHashCode() => Name?.GetHashCode() ?? 0;

    public static bool operator ==(Person? left, Person? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.Equals(right);
    }

    public static bool operator !=(Person? left, Person? right) => !(left == right);
}

class Lesson04_CompileTimeVsRuntimeEquality
{
    static void Main()
    {
        // Two separate Person objects in memory (0x10 vs 0x20)
        Person person1 = new Person { Name = "Ahmed" };
        Person person2 = new Person { Name = "Ahmed" };

        // Point 'object' variables to those exact same Person instances
        object obj1 = person1;
        object obj2 = person2;

        Console.WriteLine("=== 1. Comparing via 'Person' Variables ===");
        // Compiler sees 'Person == Person' -> Uses our overloaded operator!
        Console.WriteLine($"person1 == person2      : {person1 == person2}");      // True
        Console.WriteLine($"person1.Equals(person2) : {person1.Equals(person2)}"); // True


        Console.WriteLine("\n=== 2. Comparing via 'object' Variables (The Trap!) ===");
        // COMPILE-TIME: Compiler sees 'object == object' -> Checks memory addresses!
        Console.WriteLine($"obj1 == obj2            : {obj1 == obj2}");            // False!

        // RUNTIME: Virtual method checks actual Heap type (Person) -> Checks Name!
        Console.WriteLine($"obj1.Equals(obj2)       : {obj1.Equals(obj2)}");       // True!


        Console.WriteLine("\n=== 3. Why ReferenceEquals() Never Fails ===");
        // Accepts (object, object), forcing 'object == object' at compile-time
        Console.WriteLine($"ReferenceEquals(p1, p2) : {ReferenceEquals(person1, person2)}"); // False
    }
}