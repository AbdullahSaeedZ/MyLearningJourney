/*
================================================================================
Hands-On: LINQ with Arrays — Grouping, Anonymous Projection & Joining
================================================================================

1. WHY ARRAYS WORK NATIVELY WITH LINQ:
   - Every 1D array `T[]` implements `IEnumerable<T>` automatically in the CLR.
   - No `.Cast<T>()` bridging is needed—you can chain standard LINQ query 
     operators directly onto any array (`arr.Where(...)`, `arr.GroupBy(...)`, 
     `arr.Join(...)`).


2. CORE OPERATORS IN THIS LESSON (WHAT EACH DOES & ITS BIG-O):
   1- `.GroupBy(keySelector)` — O(n):
      Scans the array once and hashes elements into buckets (`IGrouping<TKey, TElement>`). 
      Each group exposes `.Key` (the shared grouping value) and is itself an 
      `IEnumerable<TElement>` containing all matching items in that bucket.
      
   2- `.Select(selector)` (Projection into Anonymous Type `new { ... }`) — O(n):
      Transforms each element (or group) into a brand-new, compiler-generated, 
      read-only class (`new { Prop1 = ..., Prop2 = ... }`) without declaring a 
      dedicated DTO class upfront.
      
   3- `.Join(inner, outerKeySelector, innerKeySelector, resultSelector)` — O(n + m):
      Performs an **in-memory Inner Hash Join**. First hashes all `m` elements of 
      the `inner` array into a lookup table (O(m)), then streams through the `n` 
      elements of the `outer` array probing matching keys in O(1) per item.
      
   4- Deferred Execution:
      `GroupBy`, `Select`, and `Join` build a query pipeline without running yet—
      execution happens only when you iterate with `foreach` or materialize via 
      `.ToArray()` / `.ToList()`.
================================================================================
*/

using System;
using System.Linq;

namespace LinqWithArraysPractice;

class Program
{
    static void Main()
    {
        // =====================================================================
        // TASK 1: GROUPING & PROJECTION INTO AN ANONYMOUS TYPE
        // =====================================================================
        var products = new[]
        {
            new { Name = "Laptop",   Category = "Electronics", Price = 1200m },
            new { Name = "Mouse",    Category = "Electronics", Price = 25m   },
            new { Name = "Desk",     Category = "Furniture",   Price = 350m  },
            new { Name = "Chair",    Category = "Furniture",   Price = 200m  },
            new { Name = "Keyboard", Category = "Electronics", Price = 75m   }
        };

        // 1. Group 'products' by Category using .GroupBy(...)
        // 2. Project each group using .Select(...) into a new anonymous type with:
        //      - Category   = g.Key
        //      - ItemCount  = g.Count()
        //      - TotalValue = g.Sum(p => p.Price)
        // 3. Iterate and print each summary
        // Expected Output:
        //   Category: Electronics | Items: 3 | Total: $1300
        //   Category: Furniture   | Items: 2 | Total: $550

        foreach (var item in products
                     .GroupBy(product => product.Category)
                     .Select(group => new {Category = group.Key, Items = group.Count(), Total = group.Sum(item => item.Price)}))
        {
            Console.WriteLine($"Category: {item.Category} | Items: {item.Items} | Total: {item.Total}");    
        }

        // =====================================================================
        // TASK 2: INNER JOINING TWO ARRAYS INTO AN ANONYMOUS TYPE
        // =====================================================================
        var employees = new[]
        {
            new { Id = 1, Name = "Alice", DepartmentId = 2 },
            new { Id = 2, Name = "Bob", DepartmentId = 1 }
        };

        // Array of departments
        var departments = new[]
        {
            new { Id = 1, Name = "Human Resources" },
            new { Id = 2, Name = "Development" }
        };

        // 1. Join 'employees' (outer) with 'departments' (inner) using .Join(...)
        //    Match emp.DepartmentId == dept.Id
        // 2. Project each matched pair into a new anonymous type with:
        //      - EmployeeName   = emp.Name
        //      - DepartmentName = dept.Name
        // 3. Iterate and print each employee's name and department
        // Expected Output:
        //   Alice -> Development
        //   Bob -> Human Resources

        var joined = employees.Join(
            departments,
            emp => emp.DepartmentId,
            dept => dept.Id,
            (emp, dept) => new {EmployeeName = emp.Name, DepartmentName = dept.Name}
            );

        Console.WriteLine("\n\n");
        foreach (var employee in joined)
        {
            Console.WriteLine($"Employee Name {employee.EmployeeName}, Depratment Name: {employee.DepartmentName}");
        }


    }
}