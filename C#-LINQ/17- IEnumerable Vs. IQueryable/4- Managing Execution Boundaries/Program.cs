/*
================================================================================
Lesson 4: The Developer's Rulebook & Type Boundaries
================================================================================

1. GOAL OF THIS LESSON:
   - Understand the clean boundary between database queries and RAM operations.
   - Learn the golden rule: filter on the database, format in C#.
   - See how calling .ToList() forms the boundary between IQueryable and IEnumerable.

2. PROBLEM (WHY WE NEED A BOUNDARY):
   - Some operations can only run on the database (filtering massive datasets,
     joining large tables, sorting).
   - Some operations can only run in C# (calling custom methods, applying complex
     string formatting, parsing proprietary business logic).
   - If you run database operations in C#, your app runs out of RAM.
   - If you try to run custom C# operations on the database, EF Core crashes
     with a runtime translation error.

3. CORE IDEA:
   - Stay in IQueryable as long as possible to reduce rows and columns on the server.
   - Switch to IEnumerable using .ToList() once the minimal data reaches RAM.
   - Database handles heavy lifting; application memory handles formatting.

+----------------------+--------------------+---------------------------------------+
| Stage                | Interface / Type   | Work Done Here                        |
+----------------------+--------------------+---------------------------------------+
| 1. Database Query    | IQueryable<T>      | Filtering, sorting, and pagination    |
| 2. The Boundary      | .ToList()          | Executes SQL, streams results to RAM  |
| 3. In-Memory Process | IEnumerable<T>     | Custom C# methods and text formatting |
+----------------------+--------------------+---------------------------------------+

4. THE TWO-STEP WORKFLOW:
   - Step 1 (Server): Use IQueryable with .Where() and .OrderBy() so SQL Server
     discards unwanted records before transmission.
   - Step 2 (Client): Call .ToList() to fetch only those matching records.
     From here, you are in standard IEnumerable memory, free to call any C# method.

5. WHEN NOT TO USE & COMMON PITFALLS:
   - Calling .ToList() too early: Placing .ToList() before .Where() forces the
     entire table into RAM first.
   - Calling custom C# methods before .ToList(): Passing a non-translatable C#
     helper method inside an IQueryable .Where() causes a runtime crash.
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
        // Custom C# helper method that SQL Server knows nothing about
        static string FormatBadge(Book book)
        {
            return $"[PREMIUM ITEM] {book.Title.ToUpper()} - Costs ${book.Price}";
        }

        static void Main(string[] args)
        {
            // Initializes the database context to open a session with the bookstore database
            using var db = new BookContext();

            // =============================================================
            // STAGE 1: Database Work (IQueryable)
            // =============================================================
            // Build the query. SQL Server does the filtering.
            // Nothing has executed yet (deferred execution).
            IQueryable<Book> query = db.Books
                .Where(b => b.Price > 50)
                .OrderBy(b => b.Title);

            Console.WriteLine("--- Generated SQL (Server-Side Work) ---");
            Console.WriteLine(query.ToQueryString());

            // =============================================================
            // THE BOUNDARY: .ToList()
            // =============================================================
            // SQL runs now. Only the matching filtered rows cross the network.
            // We now exit IQueryable and enter in-memory IEnumerable (List<Book>).
            List<Book> filteredBooks = query.ToList();

            // =============================================================
            // STAGE 2: RAM Work (IEnumerable)
            // =============================================================
            // Now that data is safely in memory, we can use any custom C# logic
            // without worrying about database translation errors.
            IEnumerable<string> formattedBadges = filteredBooks
                .Select(b => FormatBadge(b));

            Console.WriteLine("\n--- Formatted Output (Client-Side Work) ---");
            foreach (var badge in formattedBadges)
            {
                Console.WriteLine(badge);
            }
        }
    }
}