/*
================================================================================
LESSON 13: LINQ GroupBy() Operator
================================================================================

1. THE PROBLEM:
Sequences store data as flat streams. Categorizing records imperatively requires 
repetitive manual loops, dictionary allocations, and existence checks:

    Dictionary<string, List<Employee>> dict = new();
    foreach (var emp in employees)
    {
        if (!dict.ContainsKey(emp.Department))
            dict[emp.Department] = new List<Employee>();
        dict[emp.Department].Add(emp);
    }

2. THE CORE IDEA:
`GroupBy()` automates the manual loop of creating and filling a dictionary of lists. 
It takes a flat stream of items and organizes them into labeled buckets.

How the key is created and compared for each item:
1. You hand `GroupBy()` a key selector function: `item => item.KeyProperty`.
2. LINQ evaluates your function on the item to calculate its key.
3. LINQ checks its internal lookup table:
   - If that key ALREADY exists: It drops the item into that existing bucket.
   - If that key is NEW: It creates a brand-new `IGrouping` bucket with that key label,
     then places the item inside it.

DIAGRAM: The Key Evaluation & Bucketing Process

  Incoming Item: Employee("Issam", "HR")
        │
        ▼ Key Selector: `emp => emp.Department`
     Calculated Key: "HR"
        │
        ├── Does "HR" bucket exist?
        │     ├── YES ──► Append Employee to existing "HR" bucket
        │     └── NO  ──► Create new IGrouping bucket labeled "HR" ──► Add Employee
        │
  ─────────────────────────────────────────────────────────────────────────────
  
  Final Result: IEnumerable<IGrouping<string, Employee>>
  
  ┌─────────────────────────────────────────────────────────────┐
  │ [IGrouping Bucket 1]                                        │
  │ Key: "HR"                                                   │
  │ Elements: [ Employee("Issam"), Employee("Omar") ]           │
  ├─────────────────────────────────────────────────────────────┤
  │ [IGrouping Bucket 2]                                        │
  │ Key: "IT"                                                   │
  │ Elements: [ Employee("Reem"), Employee("Zaid") ]            │
  └─────────────────────────────────────────────────────────────┘

3. HOW IT WORKS INTERNALLY:
- Deferred Execution with Eager Buffering:
  Like most LINQ operators, `GroupBy` is deferred (it doesn't execute until enumerated). 
  However, once enumeration starts, it eagerly consumes and hashes the ENTIRE source 
  collection upfront to build all buckets before yielding the first group.
- Complexity: O(N) linear time to scan and hash; O(N) memory to buffer buckets.

4. PITFALLS:
- Multiple Enumerations: Because execution is deferred, iterating over the returned 
  `IEnumerable<IGrouping<...>>` multiple times re-scans and re-groups the entire source 
  each time. Call `.ToList()` if you plan to reuse the groups.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using GroupingData.Shared;

namespace GroupingLessons;

class LINQ_GroupBy
{
    static void Main()
    {
        // =====================================================================
        // 1. METHOD SYNTAX: GroupBy with Key Selector
        // =====================================================================
        IEnumerable<Employee> employees = Repository.LoadEmployees();

        // Key Selector: emp => emp.Department
        // Produces: IEnumerable<IGrouping<string, Employee>>
        IEnumerable<IGrouping<string, Employee>> groups = employees.GroupBy(
            emp => emp.Department
        );

        Console.WriteLine("--- Employees Grouped by Department ---");
        foreach (IGrouping<string, Employee> group in groups)
        {
            // 1. Read bucket label
            Console.WriteLine($"\nDepartment: {group.Key}");

            // 2. Iterate items inside this bucket
            foreach (Employee emp in group)
            {
                Console.WriteLine($" - {emp.FirstName}");
            }
        }

        // =====================================================================
        // 2. VALUE STREAM AGGREGATION (Grouping & Converting)
        // =====================================================================
        string rawFruits = "Apple Banana Orange Grape Apple Banana Apple Orange";
        string[] fruitItems = rawFruits.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Group by the item itself, then materialize into a frequency dictionary
        Dictionary<string, int> fruitFrequencies = fruitItems
            .GroupBy(fruit => fruit)
            .ToDictionary(group => group.Key, group => group.Count());

        Console.WriteLine("\n--- Fruit Frequency ---");
        foreach (KeyValuePair<string, int> kvp in fruitFrequencies)
        {
            Console.WriteLine($"{kvp.Key,-8} : {kvp.Value}");
        }

        // =====================================================================
        // 3. QUERY SYNTAX EQUIVALENT
        // =====================================================================
        IEnumerable<IGrouping<string, Employee>> querySyntaxGroups =
            from emp in employees
            group emp by emp.Department;
    }
}