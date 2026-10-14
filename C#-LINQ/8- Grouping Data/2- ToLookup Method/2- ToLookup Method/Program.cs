/*
====================================================================================================
                             LINQ GROUPING - ToLookup()
====================================================================================================

1. THE PROBLEM:
   When working with grouped data, developers often need immediate, repeated access to groups
   using dictionary-like lookups (e.g., retrieving all employees in "HR" by indexer `lookup["HR"]`).
   Using GroupBy() for this purpose produces an IEnumerable<IGrouping<TKey, TElement>>, which
   requires linear scanning (O(N)) every time you search for a key, and re-executes the grouping
   pipeline on each enumeration unless manually cached.

2. THE CORE IDEA:
   ToLookup() immediately partitions a sequence into a one-to-many dictionary-like data structure
   implementing ILookup<TKey, TElement>. It evaluates eagerly, caches the results in memory, and
   provides indexer-based access (`lookup[key]`) that returns an IEnumerable<TElement>.

   Flat Input Stream:
   [ { HR, Issam }, { HR, Omar }, { IT, Reem } ]
                         │
                         ▼ ToLookup(x => x.Department)
   Materialized Lookup Table (ILookup<string, Employee>):
   ┌─────────────────────────────────────────────────────────────┐
   │ Key: "HR" ──► Elements: [ Issam, Omar ]                     │
   ├─────────────────────────────────────────────────────────────┤
   │ Key: "IT" ──► Elements: [ Reem ]                            │
   └─────────────────────────────────────────────────────────────┘
   Direct Indexer Access:
   lookup["HR"]  ──► [ Issam, Omar ]
   lookup["Fin"] ──► [ ] (Empty sequence, no KeyNotFoundException)

3. HOW IT WORKS INTERNALLY:
   - Execution Model: Immediate execution. ToLookup() reads the entire source collection
     at the moment of invocation and builds an immutable lookup table in memory.
   - Time & Space Complexity: O(N) linear time to build the lookup table. Once created, key
     lookups via the indexer operate in O(1) average time. Space complexity is O(N) to hold
     the materialized structure.

4. COMMON PITFALLS:
   - Immediate Memory Allocation: Because it executes immediately, calling ToLookup() on large
     collections consumes memory up front, regardless of whether all keys are accessed.
   - Immutability: Unlike a standard Dictionary<TKey, List<TElement>>, an ILookup is read-only
     and cannot be modified (no Add, Remove, or Update methods) after creation.
   - Query Syntax Absence: There is no query syntax keyword for ToLookup(); it can only be
     invoked via method syntax.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using GroupingData.Shared;

namespace _2__ToLookup_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            // 1. Primary Method Syntax Example:
            // TKey     = string   -> The criteria used for indexing (Department)
            // TElement = Employee -> The items stored under that key
            
            // Immediate execution: buffers and builds the entire lookup table right here.
            ILookup<string, Employee> lookup = employees.ToLookup(
                (Employee employee) => employee.Department
            );

            // Iterating through all groups:
            foreach (IGrouping<string, Employee> group in lookup) // ILookup<TKey, TElement> implements IEnumerable<IGrouping<TKey, TElement>>
            {
                Console.WriteLine($"\n\nKey (group): {group.Key}");

                // Printing items (employees) in each group (key)
                foreach (Employee emp in group)
                {
                    Console.WriteLine($"Value (employee object): {emp}");
                }
            }

            // Direct Key Access via Indexer:
            // You can query a specific group directly by its key without loops:
            Console.WriteLine("\n--- Direct Key Access for 'HR' ---");
            IEnumerable<Employee> hrEmployees = lookup["HR"];

            foreach (Employee emp in hrEmployees)
            {
                Console.WriteLine($"HR Member: {emp}");
            }

            // Safe Key Handling:
            // If the key does not exist, it safely returns an empty sequence instead of throwing KeyNotFoundException:
            IEnumerable<Employee> financeEmployees = lookup["Finance"];
            Console.WriteLine($"\nFinance members count: {financeEmployees.Count()}"); // Prints 0

            // 2. Query Syntax Equivalent:
            // NOTE: C# query syntax has no direct operator for ToLookup().
            // Grouping in query syntax ('group by') always compiles down to GroupBy().
            // To produce an ILookup via query syntax, you must wrap the query in parentheses
            // and call the method syntax extension:
            ILookup<string, Employee> querySyntaxLookup =
                (from Employee emp in employees
                 select emp).ToLookup((Employee emp) => emp.Department);
        }
    }
}