/*
================================================================================
LESSON 3: THE .Zip() OPERATOR (2-to-1 PAIRWISE MERGE)
================================================================================

1. THE THEORY & CORE IDEA
--------------------------------------------------------------------------------
Definition (Microsoft .NET Docs):
"Applies a specified function to the corresponding elements of two sequences, 
producing a sequence of the results."

The Problem:
You have two independent lists that correspond purely by their sequence order 
(index 0 with index 0, index 1 with index 1). Combining them manually requires 
an index counter and bounds checks via a `for` loop.

The Solution:
`.Zip()` steps through both sequences side-by-side in lockstep, interlocking 
matching indices into unified output pairs.

Rule: If collection lengths differ, it silently stops when the shorter sequence 
ends (truncation). Excess elements from the longer sequence are dropped.

Mental Model & Diagram:

       List A (Names)                  List B (Depts)
     +----------------+              +----------------+
 [0] |    "Sara"      |              |      "IT"      | [0]
     +--------+-------+              +-------+--------+
              \                              /
               \-----> [  .Zip() Slider  ] <-----/
                               |
                               v
                     +-------------------+
                     |  ("Sara", "IT")   |
                     +-------------------+

     +----------------+              +----------------+
 [1] |    "Sami"      |              |      "HR"      | [1]
     +--------+-------+              +-------+--------+
              \                              /
               \-----> [  .Zip() Slider  ] <-----/
                               |
                               v
                     +-------------------+
                     |  ("Sami", "HR")   |
                     +-------------------+

     +----------------+              +----------------+
 [2] |    "Mona"      |              |   (No Match)   |
     +--------+-------+              +----------------+
              |
              v
     [ Truncated / Dropped ] (Shorter sequence ended)


2. THE 2 PRIMARY PATTERNS
--------------------------------------------------------------------------------
Pattern 1: Bare Zip (ValueTuple)
    seqA.Zip(seqB)  -->  yields (ItemA, ItemB) pairs automatically.

Pattern 2: Zip with Custom Projection (deciding how to show the pairs)
    seqA.Zip(seqB, (a, b) => new { ... })  -->  maps pairs into custom shapes.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class EmployeeSummaryDto
{
    public string FullName { get; set; }
    public string Department { get; set; }
}

public class Program
{
    public static void Main()
    {
        // Two independent parallel collections (Unequal lengths on purpose)
        var names = new List<string> { "Sara", "Sami", "Mona" }; // 3 items
        var departments = new List<string> { "IT", "HR" };       // 2 items (shorter)

        // ---------------------------------------------------------------------
        // 1. Bare Zip (.NET Core 3.0+)
        // Mechanism: Automatically binds matching elements into ValueTuples.
        // Result: ("Sara", "IT"), ("Sami", "HR")  ["Mona" is safely dropped]
        // ---------------------------------------------------------------------
        IEnumerable<(string First, string Second)> pairedTuples = names.Zip(departments);

        // ---------------------------------------------------------------------
        // 2. Custom DTO Projection (with resultSelector)
        // Mechanism: Takes each matching pair and maps them directly into 
        // a strongly-typed class/record.
        // ---------------------------------------------------------------------
        IEnumerable<EmployeeSummaryDto> summaryDtos = names.Zip( departments, (name, dept) => new EmployeeSummaryDto {FullName = name, Department = dept });

        // ---------------------------------------------------------------------
        // 3. Anonymous Type Projection (with resultSelector)
        // Mechanism: Takes each matching pair and maps them into an inline, 
        // temporary read-only object.
        // ---------------------------------------------------------------------
        var anonymousRows = names.Zip(
            departments,
            (name, dept) => new
            {
                EmployeeName = name,
                AssignedDepartment = dept
            }
        );

        // Execution Trigger (Iteration runs the deferred queries)
        Console.WriteLine("--- 1. Bare Zip (Tuples) ---");
        foreach (var pair in pairedTuples)
        {
            Console.WriteLine($"{pair.First} -> {pair.Second}");
        }

        Console.WriteLine("\n--- 2. Custom DTOs ---");
        foreach (var dto in summaryDtos)
        {
            Console.WriteLine($"{dto.FullName} | Dept: {dto.Department}");
        }

        Console.WriteLine("\n--- 3. Anonymous Objects ---");
        foreach (var row in anonymousRows)
        {
            Console.WriteLine($"{row.EmployeeName} works in {row.AssignedDepartment}");
        }
    }
}

/*
--------------------------------------------------------------------------------
3. PITFALLS & PRACTICAL RULES
--------------------------------------------------------------------------------
- Silent Data Truncation:
  `.Zip()` never throws an exception when collections have different counts. 
  It silently discards extra items in the longer sequence. Always verify 
  counts beforehand if silent data loss is unacceptable.

- Positional Matching Only:
  `.Zip()` does not match by keys or identifiers—it matches strictly by index. 
  If either list is reordered or filtered beforehand, pairs will misalign. 
  For key-based associations, use `.Join()` instead.
*/