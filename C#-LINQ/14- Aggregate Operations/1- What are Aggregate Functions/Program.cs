/*
====================================================================================================
                        LINQ AGGREGATION OPERATIONS - Overview
====================================================================================================

1. THE CORE IDEA:
   Aggregation operators collapse an entire sequence of values into a single scalar value 
   (e.g., a number, boolean, or computed object).

   Instead of transforming items 1-to-1 (like Select) or filtering them (like Where),
   aggregation processes the whole collection down to a single outcome (N-to-1).

   Standard LINQ Aggregation Operators:
   ┌──────────────────────┬────────────────────────────────────────────────────────────────────────┐
   │ Method               │ Primary Purpose                                                        │
   ├──────────────────────┼────────────────────────────────────────────────────────────────────────┤
   │ Count() / LongCount()│ Returns total number of elements (or matching elements).               │
   │ Sum()                │ Computes the numeric total of all elements/projections.                │
   │ Average()            │ Calculates the arithmetic mean.                                        │
   │ Min() / MinBy()      │ Identifies the smallest value or item with the minimum key.            │
   │ Max() / MaxBy()      │ Identifies the largest value or item with the maximum key.             │
   │ Aggregate()          │ General-purpose accumulator (fold/reduce) for custom accumulations.    │
   └──────────────────────┴────────────────────────────────────────────────────────────────────────┘

   Execution Classification:
   All aggregation operators trigger IMMEDIATE EXECUTION. They cannot stream lazily because 
   a total, minimum, or average requires inspecting the entire stream before yielding a result.

2. HOW IT WORKS INTERNALLY:
   - Traversal: Enumerates the sequence forward from start to finish via `IEnumerator<T>`.
   - Accumulator State: Maintains an internal state variable (e.g., running total or counter).
   - Short-Circuiting: None. Unlike `Any()` or `First()`, standard aggregates must process every 
     element (O(N) time complexity).
   - Empty Sequence Handling:
       - `Sum()` on an empty collection returns `0`.
       - `Average()`, `Min()`, and `Max()` throw `InvalidOperationException` on empty value-type sequences.

3. COMMON PITFALLS:
   - Multiple Enumerations: Calling `.Count()`, then `.Min()`, then `.Max()` on an unbuffered 
     `IEnumerable<T>` causes three separate database queries or stream iterations.
   - Division by Zero: Calling `.Average()` on an empty collection crashes with an exception.
   - Numeric Overflow: Calling `.Sum()` on large integer sets can exceed `int.MaxValue`; use 
     long projections or `long` overloads when summing large values.
====================================================================================================
*/

