/*
====================================================================================================
                             LINQ GROUPING - GroupBy()
====================================================================================================

1. THE PROBLEM:
   Sequences usually store data as a flat stream of records. When you need to segment items
   by a specific property (e.g., categorizing employees by department), doing it imperatively
   requires manual loops, dictionary allocations, and key existence checks:

       if (!dict.ContainsKey(dept)) dict[dept] = new List<Employee>();
       dict[dept].Add(emp);

   This adds boilerplate code and obscures what the query is actually trying to accomplish.

2. THE CORE IDEA:
   GroupBy() partitions a flat sequence into logical buckets based on a key selector.
   It returns an IEnumerable<IGrouping<TKey, TElement>>, where:
     - TKey represents the grouping criteria (e.g., Department name).
     - Each IGrouping<TKey, TElement> acts as a collection of the elements belonging to that key.

   Flat Input Stream:
   [ { HR, Issam }, { HR, Omar }, { IT, Reem } ]
                         │
                         ▼ GroupBy(x => x.Department)
   Grouped Buckets:
   ┌─────────────────────────────────────────────────────────────┐
   │ Key: "HR" ──► Elements: [ Issam, Omar ]                     │
   ├─────────────────────────────────────────────────────────────┤
   │ Key: "IT" ──► Elements: [ Reem ]                            │
   └─────────────────────────────────────────────────────────────┘

3. HOW IT WORKS INTERNALLY:
   - Execution Model: GroupBy uses deferred execution, but it performs eager buffering.
     It must iterate through the entire source collection upon first enumeration to discover
     and build all key-bucket associations before it can yield the groups.
   - Time & Space Complexity: O(N) linear time to scan elements and hash keys, and O(N)
     space complexity to hold the bucket structures in memory.

4. COMMON PITFALLS:
   - Multiple Enumerations: Because execution is deferred, iterating over the returned
     IEnumerable<IGrouping<TKey, TElement>> multiple times re-reads and re-groups the source
     every time unless cached (e.g., with ToList()).
   - Memory Spikes: Grouping very large in-memory collections forces all elements to be buffered.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using GroupingData.Shared;

namespace _1__GroupBy_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            // 1. Primary Method Syntax Example:
            // TKey     = string   -> The criteria used for bucketing (Department)
            // TElement = Employee -> The actual items residing inside that bucket
            IEnumerable<IGrouping<string, Employee>> groups = employees.GroupBy(
                (employee) => employee.Department
            );

            // Output demonstrates:
            // "Key (group): HR"
            // "Value (employee object): Issam"
            // "Value (employee object): Omar"
            foreach (IGrouping<string, Employee> group in groups)
            {
                Console.WriteLine($"\n\nKey (group): {group.Key}");

                foreach (Employee emp in group)
                {
                    Console.WriteLine($"Value (employee object): {emp}");
                }
            }

            // 2. Query Syntax Equivalent:
            IEnumerable<IGrouping<string, Employee>> querySyntaxGrouping =
                from emp in employees
                group emp by emp.Department;
        }
    }
}