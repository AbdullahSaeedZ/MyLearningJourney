/*
====================================================================================================
                              LINQ JOIN - Join() (Method Syntax)
====================================================================================================

1. THE PROBLEM:
   Domain models maintain relational normalization: Employee stores only a DepartmentId foreign
   key, while Department contains the actual department Name. When generating employee reports
   displaying their respective department names, querying them manually requires nested loops:

       List<EmployeeDepartmentDto> results = new List<EmployeeDepartmentDto>();
       foreach (Employee emp in employees)
       {
           foreach (Department dept in departments)
           {
               if (emp.DepartmentId == dept.Id)
               {
                   results.Add(new EmployeeDepartmentDto 
                   { 
                       FullName = emp.FullName, 
                       DepartmentName = dept.Name 
                   });
               }
           }
       }

   This imperative approach executes in quadratic time O(N * M), scales poorly as data grows,
   and introduces unnecessary nesting.

2. THE CORE IDEA:
   Join() performs an inner join between an outer sequence and an inner sequence based on matching
   keys extracted via key selectors. It projects matching pairs using a result selector function.
   Unmatched records from either sequence are discarded.

   Outer: employees (DepartmentId)          Inner: departments (Id)
   +---------+--------------+               +----+---------+
   | Name    | DepartmentId |               | Id | Name    |
   +---------+--------------+               +----+---------+
   | Coc3an  | 1            |               | 1  | FINANCE |
   | Jaclyn  | 1            |               | 2  | IT      |
   +---------+--------------+               +----+---------+
                    │                              │
                    └──────────────┬───────────────┘
                                   │ emp.DepartmentId == dept.Id
                                   ▼
   Result Sequence (Flat Matches):
   +-----------------------+------------------+
   | FullName              | DepartmentName   |
   +-----------------------+------------------+
   | Coc3an Cole           | FINANCE          |
   | Jaclyn Wolfe          | FINANCE          |
   +-----------------------+------------------+

3. HOW IT WORKS INTERNALLY:
   - Execution Model: Deferred execution. No iteration occurs until the resulting sequence is
     enumerated (e.g., via foreach or ToList()).
   - Hash Join Mechanics:
       1. Evaluates the inner sequence (departments) eagerly upon first enumeration, loading its keys
          and elements into an internal hash lookup table.
       2. Streams the outer sequence (employees) lazily, evaluating each outer key against the hash
          table for instant O(1) matching.
   - Complexity: Linear time O(N + M) where N is outer count and M is inner count, using O(M)
     auxiliary memory for the hash table.

4. COMMON PITFALLS:
   - Inner Sequence Sizing: Because the inner sequence is hashed in memory, placing the larger
     collection as the inner parameter consumes unnecessary RAM. Keep the smaller set as the inner.
   - Non-Matching Keys (Inner Join Behavior): Any employee with an unassigned DepartmentId (0 or null)
     or any department with no employees will be excluded entirely from the output.
   - Multiple Enumeration: Enumerating the returned IEnumerable multiple times reconstructs the
     internal hash table on each pass unless cached with ToList().
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using JoinOperations.Shared;

namespace _1__Join_Method_Syntax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();
            IEnumerable<Department> departments = Repository.LoadDepartment();

            // 1. Primary Method Syntax Example:
            // Parameters breakdown:
            //   - Inner sequence: departments
            //   - Outer key selector: emp => emp.DepartmentId
            //   - Inner key selector (the matching key or property): dept => dept.Id
            //   - Result selector: (emp, dept) => projection
            
            // will return a collection of single objects (projection used) in our case the DTOs,
            // not a collection of lists or groups like in GroupJoin method in next lesson
            IEnumerable<EmployeeDepartmentDto> employeeWithDepartment = employees.Join(
                departments,
                (emp) => emp.DepartmentId,
                (dept) => dept.Id,
                (emp, dept) => new EmployeeDepartmentDto
                {
                    FullName = emp.FullName,
                    DepartmentName = dept.Name
                }
            );

            Console.WriteLine("--- Employee Directory With Department ---");
            foreach (EmployeeDepartmentDto entry in employeeWithDepartment)
            {
                Console.WriteLine(entry); // emp name [dept name]
            }

            // 2. Query Syntax Equivalent:
            IEnumerable<EmployeeDepartmentDto> querySyntaxJoin =
                from emp in employees
                join dept in departments
                    on emp.DepartmentId equals dept.Id
                select new EmployeeDepartmentDto
                {
                    FullName = emp.FullName,
                    DepartmentName = dept.Name
                };
        }
    }
}