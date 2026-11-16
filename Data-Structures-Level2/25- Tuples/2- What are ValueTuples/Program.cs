/*
================================================================================
ValueTuple (System.ValueTuple) — Stack-Allocated Tuples, Named Fields & Deconstruction
================================================================================

1. THE PROBLEM (`System.Tuple` WAS SLOW AND UNREADABLE):
- `System.Tuple` had two major flaws in real-world C#:
  1. Every return allocated a heap object -> extra Garbage Collection overhead.
  2. Reading `result.Item1` and `result.Item2` forced developers to guess what 
     each slot meant.


2. CORE IDEA (`System.ValueTuple` — STACK-ALLOCATED MUTABLE STRUCT + COMPILER SUGAR):
- Introduced in C# 7.0, **`ValueTuple`** is a **value type (`struct`)** with 
  first-class C# syntax (`(int Id, string Name)`).
  
- **Zero Heap Allocation:** Lives directly on the **Stack** (or inline inside 
  parent objects/arrays), eliminating GC overhead completely.
  
- **Custom Named Elements:** You name each element directly in the type signature 
  (`(int Min, int Max)`). Under the hood, the fields are still `Item1` and 
  `Item2` in compiled IL—the C# compiler maps your custom names at compile time 
  with **zero runtime cost**.
  
- **Mutable:** Unlike `System.Tuple`, fields on `ValueTuple` can be modified 
  (`stats.Min = 5;`).

  Memory Comparison (`System.Tuple` vs. `System.ValueTuple`):
  
  Legacy Tuple (Class -> Heap):                       ValueTuple (Struct -> Directly on Stack):
  Stack          Heap                                 Stack
  ┌────────┐    ┌──────────────────┐                  ┌────────────────────────────────┐
  │ t ─────┼───►│ Item1: 10        │                  │ stats: [ Min: 10 | Max: 95 ]   │
  └────────┘    │ Item2: 95        │                  └────────────────────────────────┘
                └──────────────────┘                  (No pointer, no heap object, zero GC!)


3. CORE OPERATIONS & BIG-O REFERENCE:
   1- `(val1, val2)` / `(Name1: val1, Name2: val2)` (Literal Creation) — O(1):
      Constructs the `ValueTuple` struct directly on the Stack (zero heap allocation).
      
   2- `tuple.CustomName` / `tuple.Item1` (Field Read / Write) — O(1):
      Direct struct field access in CPU registers/stack memory.
      
   3- `var (a, b) = tuple;` (Deconstruction) — O(1):
      Unpacks tuple elements directly into separate local variables in one line.
      Use `_` (discard) to ignore values you don't need: `var (min, _) = GetBounds();`.
      
   4- `tuple1 == tuple2` / `tuple1 != tuple2` (Equality Operators) — O(k):
      Built-in `==` and `!=` operators compare elements element-by-element.


4. WHEN TO USE VS. AVOID:
- USE WHEN:
  * Returning 2–4 related values from private/internal helper methods or LINQ 
    projections (`.Select(x => (x.Id, x.Name))`).
  * Multi-variable pattern matching (`switch ((x, y))`) or swapping variables 
    cleanly without a `temp` variable: `(a, b) = (b, a);`.
- AVOID WHEN:
  * Exposing complex data in **public library APIs** or when grouping **5+ fields**—
    declare a `record` or `class` instead for self-documenting contracts, 
    validation, and maintainability.
================================================================================
*/

using System;

namespace ValueTupleReference;

class Program
{
    // Clean named ValueTuple return type (lives on Stack, zero heap allocation)
    static (int Min, int Max, double Average) CalculateStats(int[] numbers)
    {
        int min = int.MaxValue;
        int max = int.MinValue;
        int sum = 0;

        foreach (int n in numbers)
        {
            if (n < min) min = n;
            if (n > max) max = n;
            sum += n;
        }

        return (min, max, Average: (double)sum / numbers.Length);
    }

    static void Main()
    {
        int[] scores = { 80, 95, 70, 100, 85 };

        // 1. Named Field Access & Mutability — O(1)
        (int Min, int Max, double Average) stats = CalculateStats(scores);
        Console.WriteLine($"Min: {stats.Min}, Max: {stats.Max}, Avg: {stats.Average}");
        // Output: Min: 70, Max: 100, Avg: 86

        stats.Min = 65; // Allowed! ValueTuple fields are mutable (unlike System.Tuple)


        // 2. Deconstruction into Standalone Variables (with '_' Discard) — O(1)
        
        // normal way:
        (int Min, int Max, double Average) stats1 = CalculateStats(scores);
        
        // with discarding and Deconstruction:
        (int lowest, int highest, _) = stats1; // Ignores Average via '_'
        Console.WriteLine($"Deconstructed -> Lowest: {lowest}, Highest: {highest}");
        // Output: Deconstructed -> Lowest: 70, Highest: 100


        // 3. Inline Tuple Variable Swap (No temporary variable needed!) — O(1)
        int a = 10, b = 20;
        (a, b) = (b, a);
        Console.WriteLine($"After swap -> a: {a}, b: {b}");
        // Output: After swap -> a: 20, b: 10


        // 4. Built-in '==' Structural Value Equality (Ignores field names, compares values)
        (int X, int Y) pointA = (3, 4);
        (int Width, int Height) pointB = (3, 4);
        Console.WriteLine($"pointA == pointB: {pointA == pointB}"); // Output: True
    }
}