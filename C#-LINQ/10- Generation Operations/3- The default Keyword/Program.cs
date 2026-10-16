/*
====================================================================================================
                        C# LANGUAGE FOUNDATIONS - The `default` Keyword
====================================================================================================

1. THE PROBLEM:
   Generic code (like `T` in generic methods or collections) operates on types that are unknown at
   compile time. A generic algorithm often needs to initialize an unassigned variable or provide a
   neutral fallback value. However:
     - You cannot simply assign `null`, because `T` might be a non-nullable value type (like `int`),
       which causes a compiler error.
     - You cannot assign `0`, because `T` might be a reference type (like `Question` or `string`).

2. THE CORE IDEA:
   The `default` operator (or literal) produces the default state of any type in .NET:
     - For Reference Types (classes, interfaces): Produces `null`.
     - For Numeric Value Types (int, double, decimal): Produces zero (`0`, `0.0`, `0m`).
     - For Boolean Value Types: Produces `false`.
     - For Structs (e.g., DateTime): Produces an instance with all fields set to their respective default values.

   Type Categories:
   ┌──────────────────────────────┬───────────────────────────────┬───────────────────────────────┐
   │ Type Category                │ Concrete Examples             │ Evaluated default Value       │
   ├──────────────────────────────┼───────────────────────────────┼───────────────────────────────┤
   │ Reference Types              │ string, Question, List<T>     │ null                          │
   │ Numeric Value Types          │ int, double, decimal          │ 0, 0.0, 0m                    │
   │ Boolean Value Types          │ bool                          │ false                         │
   │ Structs (Value Types)        │ DateTime                      │ DateTime.MinValue (01/01/0001)│
   └──────────────────────────────┴───────────────────────────────┴───────────────────────────────┘

3. HOW IT WORKS INTERNALLY:
   - Memory Model: In the CLR, `default` represents clearing the allocated memory for that variable
     to all binary zeroes (zeroed bits in the stack or heap memory block).
   - Modern C# Evolution:
       - C# 2.0: Required specifying the type explicitly: `default(int)`, `default(Question)`.
       - C# 7.1+: Introduced the default literal `default`, where the compiler infers the target type
         from the left-hand assignment.

4. COMMON PITFALLS:
   - Expecting Object Instantiation: Writing `default(Question)` does NOT call the constructor `new Question()`.
     It yields `null`.
   - Silent Nulls in LINQ: When LINQ operators fall back to `default(T)` for reference types (like in
     `FirstOrDefault()` or parameterless `DefaultIfEmpty()`), they yield `null`, which can trigger
     `NullReferenceException` if accessed directly without null-checking.
====================================================================================================
*/

using System;
using Generation.Shared;

namespace _3__The_default_Keyword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------------------
            // 1. Explicit default(T) vs. Target-Typed default Literal (C# 7.1+)
            // -------------------------------------------------------------------------
            // Explicit syntax (C# 2.0+):
            int defaultIntExplicit = default(int);
            Question defaultQuestionExplicit = default(Question);

            // Inferred / Target-typed syntax (Modern C#):
            int defaultInt = default;
            double defaultDouble = default;
            decimal defaultDecimal = default;
            bool defaultBool = default;
            DateTime defaultDateTime = default;
            Question defaultQuestion = default; // Reference type -> null

            // -------------------------------------------------------------------------
            // 2. Value Inspections Across Types
            // -------------------------------------------------------------------------
            Console.WriteLine("--- Default Values of Value Types ---");
            Console.WriteLine($"default(int):      {defaultInt}");          // 0
            Console.WriteLine($"default(double):   {defaultDouble}");       // 0
            Console.WriteLine($"default(decimal):  {defaultDecimal}");      // 0
            Console.WriteLine($"default(bool):     {defaultBool}");         // False
            Console.WriteLine($"default(DateTime): {defaultDateTime}");     // 1/1/0001 12:00:00 AM

            Console.WriteLine("\n--- Default Values of Reference Types ---");
            // Reference types resolve to null:
            Console.WriteLine($"default(Question) == null: {defaultQuestion == null}"); // True

            // -------------------------------------------------------------------------
            // 3. Significance in LINQ Context
            // -------------------------------------------------------------------------
            // When LINQ methods like DefaultIfEmpty() run on an empty sequence of reference types,
            // they emit default(T) (null) unless you provide an explicit fallback object!
        }
    }
}