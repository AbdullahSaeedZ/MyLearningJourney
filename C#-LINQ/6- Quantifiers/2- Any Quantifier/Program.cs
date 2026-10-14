
/*
====================================================================================================
                              LINQ QUANTIFIERS - ANY()
====================================================================================================

1. THE PROBLEM:
   You often need to verify existence:
   - "Is this collection empty or does it have elements?"
   - "Does at least one record satisfy this specific condition?"
   Before Any(), developers commonly wrote `collection.Count() > 0` or manual `foreach` loops with
   a boolean flag and a `break`.
   - `Count() > 0` on an `IEnumerable` forces the entire sequence to be iterated just to know if 
     a single element exists.
   - Manual loops clutter code with state tracking variables.

2. THE CORE IDEA:
   `Any()` determines whether a collection contains elements, or whether any element satisfies a condition:
   - `Any()`            : Returns true if the collection contains at least one element.
   - `Any(predicate)`   : Returns true if at least one element matches the specified predicate.

   ASCII Diagrams:

   Any() (Non-empty check):
   Input:  [ E01 ] [ E02 ] [ E03 ] ...
           |-- Found 1st element! --> Returns TRUE immediately. (E02, E03 are never inspected)

   Any(predicate):
   Predicate: x => x.Salary > 150000
   Input:  [ 103,200 ] [ 192,400 ] [ 120,000 ] ...
           |-- False --| |-- TRUE! --|
                         (Halt: Returns TRUE immediately. The rest is unread)

   -------------------- Worst-case (No match) = O(n):
   Input:  [ 100k ] [ 110k ] [ 120k ]
           |-False-|-False-|-False-| --> Returns FALSE after full traversal.

3. HOW IT WORKS INTERNALLY:
   - Immediate Execution: Returns a scalar `bool` value right away.
   - Short-Circuiting:
     * Calls `GetEnumerator()`.
     * If no predicate is passed, calls `MoveNext()`. If `MoveNext()` returns true, `Any()` yields true immediately.
     * If a predicate is passed, it loops with `MoveNext()` and tests `predicate(current)`. The VERY FIRST
       time the predicate returns true, enumeration terminates immediately via return true.
   - SQL Translation (EF Core): Translates to `WHERE EXISTS (SELECT 1 FROM ...)` in SQL.
     The database stops scanning rows the moment the first match is encountered.

4. COMMON PITFALLS:
   - Any() vs Count() > 0: Never use `Count() > 0` to check for existence on `IEnumerable` or `IQueryable`.
     `Count()` counts the entire table/stream, while `Any()` short-circuits at the first match.
   - Null Collections: Calling `Any()` on a `null` collection throws `ArgumentNullException`. Always ensure
     the collection reference is not null before invoking.
   - Negative Predicate Confusion: Using `!list.Any(x => x.IsActive)` is logically equivalent to checking
     if "no elements are active", not "all elements are inactive" (which would be `list.All(...)`).
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Quantifiers.Shared;

namespace _2__Any_Quantifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            Console.WriteLine("==================================================================");
            Console.WriteLine("                    LINQ QUANTIFIERS: ANY()                       ");
            Console.WriteLine("==================================================================\n");

            // 1. Check if the collection contains any records at all.
            Console.WriteLine("Does Collection have records: " + employees.Any());

            // 2. Check if any employee matches a specific condition (e.g., salary, skills).
            Console.WriteLine("Is there any employee name starting with 'jac': " + employees.Any(emp => emp.Name.StartsWith("jac", StringComparison.OrdinalIgnoreCase)));
            
            // 3. Check if any employee has exactly one skill.
            Console.WriteLine("Is there any employee with only 1 skill: " + employees.Any(emp => emp.Skills.Count == 1));


        }
    }
}