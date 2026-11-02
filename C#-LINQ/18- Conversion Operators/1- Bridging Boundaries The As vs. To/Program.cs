/*
Note: Review the previous lesson on "Managing the Execution Boundary" from the previous topic first.

================================================================================
Lesson 1: Boundary Revision & Prefix Mechanics
================================================================================

1. QUICK REVISION (THE BOUNDARY ISSUE):
   - In our previous lessons, we used .ToList() to cross the boundary from 
     remote SQL (IQueryable) to local RAM (IEnumerable).
   - While effective, .ToList() is an EAGER boundary: it immediately executes
     the SQL query and allocates a brand-new List<T> in memory.
   - The question we take into this module: Can we switch boundaries and compiler
     tracks WITHOUT triggering execution or allocating new containers?

2. PREFIX MECHANICS (AS... VS. TO...):
   - LINQ conversion operators methods strictly follow naming conventions based on
     how they handle execution and allocation:

+-------------+----------------------+--------------------+---------------------------------------+
| Prefix Type | Execution Model      | Memory Cost        | Primary Purpose                       |
+-------------+----------------------+--------------------+---------------------------------------+
| As...       | Deferred (Lazy)      | Zero Allocation    | Reinterprets the interface/type       |
|             | Does not run now     | References same data| without triggering execution.        |
+-------------+----------------------+--------------------+---------------------------------------+
| To...       | Immediate (Eager)    | Allocates New RAM  | Converts data into a concrete storage |
|             | Runs right away      | Creates new copy   | container immediately.                |
+-------------+----------------------+--------------------+---------------------------------------+

3. THE CORE TAKEAWAY BEFORE MOVING FORWARD:
   - "As..." operators change HOW the compiler sees your data.
   - "To..." operators change WHERE your data is stored and WHEN it runs.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Data.Shared;

namespace LinqDeepDive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new BookContext();

            // -------------------------------------------------------------
            // The Issue: .ToList() is an Eager Boundary
            // -------------------------------------------------------------
            // We want to work with in-memory IEnumerable to apply client logic,
            // but calling .ToList() executes SQL Server immediately and
            // allocates a full List<Book> in RAM right here on this line:
            List<Book> memoryList = db.Books.ToList();

            // The data is now buffered in memory; deferred execution is gone.
            var expensiveBooks = memoryList.Where(b => b.Price > 50);

            Console.WriteLine($"Total books loaded into RAM: {memoryList.Count}");
            Console.WriteLine($"Filtered books in memory: {expensiveBooks.Count()}");

            // In the next lesson, we will learn how to control boundary switching 
            // as we need without triggering immediate execution or allocating memory.
        }
    }
}