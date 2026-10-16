/*
====================================================================================================
                        LINQ JOIN OPERATIONS - MODULE OVERVIEW
====================================================================================================

1. THE PROBLEM:
   Relational models store related data across distinct collections to avoid duplication. For
   instance, an Employee stores a DepartmentId, while department descriptions reside in a separate
   Department collection. When combining these datasets based on matching keys, naive imperative
   code uses nested loops:

       List<EmployeeDetail> results = new List<EmployeeDetail>();
       foreach (Employee emp in employees)
       {
           foreach (Department dept in departments)
           {
               if (emp.DepartmentId == dept.Id)
               {
                   results.Add(new EmployeeDetail(emp.Name, dept.Name));
               }
           }
       }

   This nested-loop approach runs in quadratic time O(N * M), creating performance bottlenecks
   on non-trivial datasets while cluttering business logic with structural control flow.

2. THE CORE IDEA:
   LINQ join operations correlate records from two independent sequences using key equivalence.
   This mirrors SQL join mechanics directly:

   - Join (Inner Join):
     Directly equivalent to SQL 'INNER JOIN'. It flattens the result, returning only records
     where the key exists in both sequences. Unmatched outer or inner records are excluded.

     Outer Table (Employees):           Inner Table (Departments):
     +-------+--------------+           +----+------------+
     | Name  | DepartmentId |           | Id | DeptName   |
     +-------+--------------+           +----+------------+
     | Ali   | 1            |           | 1  | HR         |
     | Omar  | 2            |           | 2  | IT         |
     +-------+--------------+           +----+------------+
                     │                         │
                     └────────────┬────────────┘
                                  │ Matching Keys (DepartmentId == Id)
                                  ▼
     Result Table (Flat 1:1 Correlation):
     +-------+------------+
     | Name  | DeptName   |
     +-------+------------+
     | Ali   | HR         |
     | Omar  | IT         |
     +-------+------------+

   - GroupJoin (Hierarchical / Left Outer Join Structure):
     Correlates each element from the outer table with an enumerable bucket of matching inner
     elements (1:N relationship). In SQL terms, this is conceptually similar to a 'LEFT OUTER JOIN'
     grouped into an aggregated child set. If an outer record has no matches, it remains in the
     result set with an empty collection.

     Outer Table (Departments):         Inner Table (Employees):
     +----+------------+                +-------+--------------+
     | Id | DeptName   |                | Name  | DepartmentId |
     +----+------------+                +-------+--------------+
     | 1  | HR         |                | Ali   | 1            |
     | 2  | IT         |                | Mona  | 1            |
     | 3  | Sales      |                | Omar  | 2            |
     +----+------------+                +-------+--------------+
                     │                         │
                     └────────────┬────────────┘
                                  │ Matching Keys (Id == DepartmentId)
                                  ▼
     Result Table (Hierarchical 1:N Correlation):
     +------------+---------------------------------------+
     | DeptName   | Employees                             |
     +------------+---------------------------------------+
     | HR         | [ { Name: Ali }, { Name: Mona } ]     |
     | IT         | [ { Name: Omar } ]                    |
     | Sales      | [ ] (Empty sequence, outer preserved) |
     +------------+---------------------------------------+

3. HOW IT WORKS INTERNALLY:
   - Execution Model: LINQ joins use deferred execution; evaluation occurs only upon enumeration.
   - Hash Join Mechanics: LINQ does not execute quadratic O(N * M) nested iterations. Instead,
     it uses a Hash Join algorithm:
       1. The inner sequence is fully read and loaded into an internal hash lookup table keyed
          by the inner key selector.
       2. The outer sequence streams lazily. For each outer record, the key is evaluated, and
          matching inner elements are retrieved from the hash table in O(1) average time.
   - Time & Space Complexity: Linear time O(N + M) to process both sequences, and O(M) auxiliary
     memory to hold the inner hash lookup table.

4. COMMON PITFALLS:
   - Inner Sequence Memory Cost: Because the inner sequence is buffered entirely into a hash
     table, placing an exceptionally large collection on the inner side increases immediate memory
     consumption.
   - Null Key Semantics: LINQ joins rely on equality comparers. Key selectors that yield null
     do not match with other null keys by default.
   - Multiple Enumerations: Enumerating a deferred join result multiple times causes the entire
     inner sequence to be re-read and re-hashed each time unless cached (e.g., using ToList()).
====================================================================================================
*/