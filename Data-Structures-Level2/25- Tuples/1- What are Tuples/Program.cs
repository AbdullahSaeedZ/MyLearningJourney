/*
================================================================================
Tuple (System.Tuple) — Reference-Type Data Grouping, Internals & Trade-offs
================================================================================

1. THE PROBLEM (RETURNING MULTIPLE VALUES WITHOUT CREATING BOILERPLATE CLASSES):
- A C# method can only return one type (`public int Foo()`).
- Before C# 7.0, if a method needed to return two or three related values 
  (like a user's ID, Name, and Status), you were forced to either:
  * Declare a brand-new single-use DTO class/struct just for that return value, or
  * Use clunky `out` parameters (which cannot be used with `async` methods).


2. CORE IDEA (`System.Tuple` — HEAP-ALLOCATED IMMUTABLE CONTAINER):
- `Tuple<T1, T2, ...>` (introduced in .NET 4.0) is a **reference type (`class`)** 
  that bundles up to 8 heterogeneous values into a single object.
  
- **Immutability:** Once constructed, its properties (`Item1`, `Item2`, ...) are 
  **read-only**—you cannot reassign `tuple.Item1 = ...` after creation.
 * 
- **Generic Naming Limitation:** Elements can ONLY be accessed via generic 
  positional names (`Item1`, `Item2`, `Item3`)—custom field names are impossible.

  Heap Allocation Layout (`Tuple.Create(1, "Alice", true)`):
  Stack                        Heap (`Tuple<int, string, bool>` Object)
  ┌──────────────┐            ┌──────────────────────────────────────────────┐
  │ person ──────┼───────────►│ [Obj Header] | Item1: 1 | Item2: ──► "Alice" │
  └──────────────┘            │              | Item3: true                   │
                              └──────────────────────────────────────────────┘


3. CORE OPERATIONS & BIG-O REFERENCE:
   1- `Tuple.Create(v1, v2, ...)` / `new Tuple<T1, T2>(v1, v2)` — O(1):
      Allocates a new `Tuple` instance on the **Heap** and sets all fields once.
   2- `tuple.Item1`, `tuple.Item2`, ... (Property Read) — O(1):
      Reads the strongly typed value directly from the object's field.
   3- `tuple1.Equals(tuple2)` (Structural Value Equality) — O(k):
      Compares each element (`Item1`..`ItemK`) for equality rather than 
      checking if both variables point to the exact same heap address.
   4- `tuple.ToString()` — O(k):
      Formats all items cleanly as `"(Item1, Item2, ...)"`.


4. WHEN TO USE VS. AVOID:
- AVOID IN MODERN C# (C# 7.0+):
  * Allocates on the **Heap** every time it is created (creating Garbage 
    Collector pressure in loops or hot paths).
  * Forces unreadable `Item1`, `Item2` property names instead of meaningful names.
  * Prefer **`ValueTuple`** (`(int Id, string Name)`) in all new C# code unless 
    an older .NET Framework 4.x API explicitly demands `System.Tuple`.
================================================================================
*/

using System;

namespace LegacyTupleReference;

class Program
{
    static void Main()
    {
        // 1. Creation & O(1) Property Access
        // Tuple.Create infers generic types automatically (cleaner than 'new Tuple<...>')
        Tuple<int, string, double> product = Tuple.Create(101, "Mechanical Keyboard", 129.99);

        Console.WriteLine($"ID:    {product.Item1}");   // Output: ID:    101
        Console.WriteLine($"Name:  {product.Item2}");   // Output: Name:  Mechanical Keyboard
        Console.WriteLine($"Price: ${product.Item3}");  // Output: Price: $129.99

        // product.Item1 = 202; // COMPILE ERROR: Properties on System.Tuple are read-only!


        // 2. Built-in Formatting & Structural Equality
        Console.WriteLine($"Formatted: {product}");     // Output: (101, Mechanical Keyboard, 129.99)

        var copy = Tuple.Create(101, "Mechanical Keyboard", 129.99);
        Console.WriteLine($"Equal values? {product.Equals(copy)}"); // Output: True (structural equality)


        // 3. Nested Tuple (Required when exceeding 7 items; 8th slot 'Rest' holds another Tuple)
        var eightItems = Tuple.Create(1, 2, 3, 4, 5, 6, 7, Tuple.Create(8, 9));
        Console.WriteLine($"8th slot Item1: {eightItems.Rest.Item1}"); // Output: 8
    }
}