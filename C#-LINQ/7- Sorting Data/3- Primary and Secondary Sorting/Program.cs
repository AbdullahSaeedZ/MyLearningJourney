
/*
====================================================================================================
           LINQ DATA ORDERING - PRIMARY & SECONDARY SORTING (THENBY / THENBYDESCENDING)
====================================================================================================

1. THE PROBLEM:
   Primary sorting often results in "ties" (e.g., multiple employees sharing the same name length,
   department, or salary). You need to define how ties are broken without losing the primary sort:
   - Sort by Name, then resolve duplicate names by Salary.
   - Sort by Skill count, then sort employees within the same count alphabetically.
   Calling OrderBy twice overrides the first sort entirely rather than resolving ties.

2. THE CORE IDEA:
   Secondary sorting operators execute ONLY when preceding keys are equal:
   - ThenBy(keySelector)           : Resolves ties in ASCENDING order.
   - ThenByDescending(keySelector) : Resolves ties in DESCENDING order.
   - Requires IOrderedEnumerable<T>: Can only be called after OrderBy, OrderByDescending, or another ThenBy.

   ASCII Diagram (OrderBy Name.Length THEN ThenBy Salary Descending):

   Input:
   [ Ali: $40k ] [ Sara: $90k ] [ Bob: $80k ] [ John: $50k ]

   Step 1: Primary Sort by Name.Length (Ascending):
   Group Len 3: [ Ali: $40k ], [ Bob: $80k ]   <-- Tie!
   Group Len 4: [ Sara: $90k ], [ John: $50k ] <-- Tie!

   Step 2: ThenBy Salary (Descending) resolves ties within each group:
   Group Len 3: [ Bob: $80k ], [ Ali: $40k ]
   Group Len 4: [ Sara: $90k ], [ John: $50k ]

   Final Output:
   [ Bob: $80k ] -> [ Ali: $40k ] -> [ Sara: $90k ] -> [ John: $50k ]

3. HOW IT WORKS INTERNALLY:
   - Composite Comparer:
     OrderBy returns an `IOrderedEnumerable<T>`. When you chain `ThenBy`, LINQ wraps the existing
     comparer inside a compound comparer. During sorting, it evaluates key 1; if comparison returns 0
     (equal), it falls back to key 2.
   - SQL Translation (EF Core):
     Maps directly to comma-separated SQL clauses:
     `ORDER BY LEN(Name) ASC, Salary DESC`.

4. COMMON PITFALLS:
   - The OrderBy Chaining Bug:
     `employees.OrderBy(e => e.Name).OrderBy(e => e.Salary)` -> Bug: The second OrderBy destroys the first!
     Always use `OrderBy(...).ThenBy(...)`.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using DataSorting.Shared;

namespace _3__Primary_and_Secondary_Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            Console.WriteLine("==================================================================");
            Console.WriteLine("        LINQ ORDERING: THENBY & THENBYDESCENDING DEMO             ");
            Console.WriteLine("==================================================================\n");

            // =========================================================================
            // Example 1: Method Syntax (Primary: Name Length ASC, Secondary: Salary DESC)
            // Goal:
            // 1. Group/Sort employees primarily by the length of their Name (shortest first).
            // 2. If two employees have the SAME name length, break the tie by Salary (highest first).
            // =========================================================================
            Console.WriteLine("--- 1. Method Syntax: OrderBy(Name.Length) -> ThenByDescending(Salary) ---\n");

            var sortedEmployees = employees
                .OrderBy(e => e.Name.Length)
                .ThenByDescending(e => e.Salary);

            foreach (var emp in sortedEmployees)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine();

            // =========================================================================
            // Example 2: Query Syntax Equivalent (Comma-separated orderby clauses)
            // How it maps:
            // "orderby emp.Name.Length, emp.Salary descending"
            // The first clause acts as OrderBy, subsequent clauses act as ThenBy.
            // =========================================================================
            Console.WriteLine("--- 2. Query Syntax Equivalent ---\n");

            var querySorted = from emp in employees
                              orderby emp.Name.Length, emp.Salary descending
                              select emp;

            foreach (var emp in querySorted)
            {
                Console.WriteLine(emp);
            }
        }
    }
}