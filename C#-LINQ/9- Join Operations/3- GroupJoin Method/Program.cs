/*
====================================================================================================
                            LINQ JOIN - GroupJoin() (Method Syntax)
====================================================================================================

1. THE PROBLEM:
   Relational models store one-to-many relationships across tables (e.g., one Department has many
   Employees). When building a report structured by department—where each department header displays
   its underlying list of employees—using standard Join() flattens the output, duplicating the
   department data across multiple rows and dropping departments that currently have zero employees.
   Writing this imperatively requires manual dictionary grouping or nested loops with filters:

       List<EmployeeGroup> results = new List<EmployeeGroup>();
       foreach (Department dept in departments)
       {
           List<Employee> deptEmps = new List<Employee>();
           foreach (Employee emp in employees)
           {
               if (emp.DepartmentId == dept.Id)
               {
                   deptEmps.Add(emp);
               }
           }
           results.Add(new EmployeeGroup { DepartmentName = dept.Name, Employees = deptEmps });
       }

   This imperative approach is verbose and runs in quadratic time O(N * M).

2. THE CORE IDEA:
   GroupJoin() correlates an outer sequence with an inner sequence based on key matching, but instead
   of flattening matches into individual rows like Join(), it pairs each outer element with an
   IEnumerable<TInner> sequence of all matching inner elements (1:N relationship).
   Departments with no matching employees are preserved with an empty sequence (left outer join behavior).

   Outer: departments (Id)                    Inner: employees (DepartmentId)
   +----+------------+                        +---------+--------------+
   | Id | Name       |                        | Name    | DepartmentId |
   +----+------------+                        +---------+--------------+
   | 1  | FINANCE    |                        | Coc3an  | 1            |
   | 2  | IT         |                        | Jaclyn  | 1            |
   | 5  | SALES      |                        +---------+--------------+
   +----+------------+
           │                                              │
           └───────────────────────┬──────────────────────┘
                                   │ dept.Id == emp.DepartmentId
                                   ▼
   Result Sequence (Hierarchical Projections into EmployeeGroup):
   +--------------------+-----------------------------------------------+
   | DepartmentName (groups)    | Employees                             |
   +--------------------+-----------------------------------------------+
   | FINANCE                    | [ { Coc3an Cole }, { Jaclyn Wolfe } ] |
   | IT                         | [ ] (Empty sequence, outer preserved) |
   | SALES                      | [ ] (Empty sequence, outer preserved) |
   +--------------------+-----------------------------------------------+

3. HOW IT WORKS INTERNALLY:
   - Execution Model: Deferred execution; evaluation starts only when enumerated.
   - Hash Join Mechanics:
       1. Consumes the inner sequence (employees) and loads it into an internal hash lookup table
          grouped by the inner key selector (DepartmentId).
       2. Streams the outer sequence (departments) lazily. For each outer record, it looks up the
          matching bucket from the hash table in O(1) time and passes it to the result selector.
   - Complexity: Linear time O(N + M) where N is outer count and M is inner count, using O(M)
     auxiliary memory for the internal lookup table.

4. COMMON PITFALLS:
   - Reversing Outer and Inner Sequences: Placing Employee as outer and Department as inner produces
     a collection of single-item department lists per employee, rather than grouping employees under departments.
   - Multiple Enumerations of the Inner Sequence: Iterating over `group.Employees` multiple times will
     re-evaluate deferred operations on that sub-sequence unless materialized (e.g., with ToList()).
   - Memory Consumption: The entire inner sequence is read into memory upfront to build the lookup table.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using JoinOperations.Shared;

namespace _2__GroupJoin_Method_Syntax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Department> departments = Repository.LoadDepartment();
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            // 1. Primary Method Syntax Example:
            // Parameters breakdown:
            //   - Inner sequence: employees
            //   - Outer key selector: dept => dept.Id
            //   - Inner key selector: emp => emp.DepartmentId
            //   - Result selector: (dept, emps) => projects outer element and its collection of matches
            
            // returns collection of EmployeeGroup DTO we made so a group represent a department with its employees
            IEnumerable<EmployeeGroup> departmentGroupings = departments.GroupJoin(
                employees,
                (dept) => dept.Id,
                (emp) => emp.DepartmentId,
                (dept,empGroups) => new EmployeeGroup
                {
                    DepartmentName = dept.Name,
                    Employees = empGroups
                }
            );

            Console.WriteLine("--- Departments With Their Employees ---");
            foreach (EmployeeGroup group in departmentGroupings)
            {
                Console.WriteLine($"\nDepartment: {group.DepartmentName}");

                foreach (Employee emp in group.Employees)
                {
                    Console.WriteLine($" - {emp.FullName}");
                }
            }

            // 2. Query Syntax Equivalent:
            // Uses the 'into' contextual keyword to bundle matches into a group
            IEnumerable<EmployeeGroup> querySyntaxGroupJoin =
                from Department dept in departments
                join Employee emp in employees
                    on dept.Id equals emp.DepartmentId into emps
                select new EmployeeGroup
                {
                    DepartmentName = dept.Name,
                    Employees = emps
                };
        }
    }
}