/*
================================================================================
LESSON: LINQ (LANGUAGE INTEGRATED QUERY)
================================================================================

1. THE PROBLEM (WHY LINQ WAS CREATED)
--------------------------------------------------------------------------------
Before LINQ, querying data depended entirely on where that data lived:
- Querying in-memory collections meant writing manual loops and custom filter methods.
- Querying SQL databases meant embedding raw SQL strings into C# code.
- Querying XML meant learning XPath / XQuery.

Drawbacks of the old approach:
- No compile-time type safety: Errors in SQL strings failed only at runtime.
- Duplication: You had to write repetitive filtering/mapping methods for every type.

Custom Filter Approach (like in previous lesson):
+------------------------------------------------------------------+
| Custom Method:                                                   |
| public static IEnumerable<Employee> Filter(                      |
|     this IEnumerable<Employee> source,                           |
|     Func<Employee, bool> predicate)                              |
+------------------------------------------------------------------+
Problem: Tied specifically to Employee. Writing one for Product,
Customer, Order, etc., creates massive code duplication.


2. THE CORE IDEA
--------------------------------------------------------------------------------
LINQ bridges the gap by making query operations a first-class citizen inside C#.
It replaces ad-hoc methods with standardized generic extension methods.

Built-in Generic LINQ Replacement:
+------------------------------------------------------------------+
| Standard LINQ:                                                   |
| public static IEnumerable<TSource> Where<TSource>(               |
|     this IEnumerable<TSource> source,                            |
|     Func<TSource, bool> predicate)                               |
+------------------------------------------------------------------+
Benefit: Works across ANY type (TSource) without writing custom logic.


3. DATA TARGETS & INTERFACES (LOCAL VS REMOTE)
--------------------------------------------------------------------------------
LINQ operates across two primary domains:

               +----------------------------------+
               |               LINQ               |
               +-----------------+----------------+
                                 |
        +------------------------+------------------------+
        |                                                 |
        v                                                 v
+-------------------------------+ +-------------------------------+
|  Local Objects (In-Memory)    | |  Remote Data (Out-of-Process) |
+-------------------------------+ +-------------------------------+
| - Works on: IEnumerable<T>    | | - Works on: IQueryable<T>     |
| - Targets: Arrays, Lists      | | - Targets: SQL Databases      |
| - Executes: In C# via IL      | | - Executes: Translated to SQL |
+-------------------------------+ +-------------------------------+


4. TWO SYNTAX FLAVORS (HOW IT WORKS INTERNALLY)
--------------------------------------------------------------------------------
LINQ provides two ways to write queries:
1. Method Syntax (Fluent API)
2. Query Syntax  (SQL-like declarative style)

Query Syntax is syntactic sugar. The C# compiler transforms Query Syntax 
directly into Method Syntax before generating bytecode (IL).

Compilation Flow:
+---------------------------------------+
| Query Syntax:                         |
| from n in numbers where n % 2 == 0    |
| select n;                             |
+-------------------+-------------------+
                    |
                    | (Compiler translates)
                    v
+---------------------------------------+
| Method Syntax:                        |
| numbers.Where(x => x % 2 == 0);       |
+---------------------------------------+


5. MINIMAL C# CODE EXAMPLE
--------------------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6 };

        // 1. Method Syntax
        var evensMethod = numbers.Where(x => x % 2 == 0);

        // 2. Query Syntax (lowered to Where(...) by the compiler)
        var evensQuery = from n in numbers
                         where n % 2 == 0
                         select n;

        // Output results
        foreach (var n in evensMethod)
        {
            Console.WriteLine(n); // 2, 4, 6
        }
    }
}

/*
--------------------------------------------------------------------------------
6. WHEN NOT TO USE IT & COMMON PITFALLS
--------------------------------------------------------------------------------
- Performance-Critical Loops:
  LINQ introduces small overheads (delegate allocations, iterator state machines).
  For ultra-hot CPU loops, an ordinary 'for' loop avoids allocations.

- Unintended Multiple Enumeration:
  IEnumerable<T> re-executes queries upon each enumeration unless cached with
  .ToList() or .ToArray().

- Over-Chaining:
  Nesting dozens of operations into a single unreadable statement instead of 
  breaking queries down clearly.
*/