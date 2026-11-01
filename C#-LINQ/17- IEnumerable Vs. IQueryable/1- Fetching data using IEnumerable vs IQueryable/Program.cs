/*
================================================================================
LESSON 1: FETCHING DATA USING IENUMERABLE VS IQUERYABLE
================================================================================

1. GOAL OF THIS LESSON:
   - Understand why two interfaces exist for querying data in C#.
   - See how IEnumerable filters data in application RAM.
   - See how IQueryable filters data directly on the database engine.
   - Learn how to inspect the generated SQL query to verify the difference.

2. PROBLEM (WHY THIS DISTINCTION EXISTS):
   - Developers want to write C# code (b => b.Price > 50) instead of building
     raw SQL strings manually.
   - Database tables can contain millions of rows, while network bandwidth and RAM
     are limited.
   - Pulling an entire table across the network into application memory just to
     run an 'if' check is slow and causes out-of-memory crashes.
   - We need an interface that tells the remote database to filter the rows
     before sending them across the network.

3. CORE IDEA:
   - IEnumerable<T>: Designed to work best with existing in-memory collections.
     It loads data into RAM first, then evaluates the filter locally.

   - IQueryable<T>: Designed to work directly with external data sources like
     databases. It sends your filter criteria to the database engine so only
     the matching rows are returned.

   - Both interfaces achieve the exact same final result, but they come with
     vastly different performance, memory, and network costs.

4. HOW IT WORKS INTERNALLY (THE WIRE TRACE):
   - IEnumerable:
       C# App -------- SELECT * FROM Books --------> Database Engine
       C# App <--- Transfers All 13 Rows in Wire <-- Database Engine
       C# App: Discards non-matching rows in RAM.
   - IQueryable:
       C# App ---- SELECT * FROM Books WHERE Price > 50 ----> Database Engine
       C# App <--- Transfers Only 5 Matching Rows <---------- Database Engine
       C# App: Directly stores the 5 needed rows in RAM.

5. WHEN NOT TO USE & COMMON PITFALLS:
   - Silent Memory Drain: Using IEnumerable to query database tables. If the
     table contains a large number of rows, all rows are loaded into RAM.
   - Early Casting: Casting a query to IEnumerable early forces all next operations
     (.Where(), .Take(), .OrderBy()) to run locally in RAM instead of on the server.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Data.Shared;
using Microsoft.EntityFrameworkCore;

namespace LinqDeepDive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initializes the database context to open a session with the bookstore database
            using var db = new BookContext();

            // Both IEnumerable<T> and IQueryable<T> expose matching LINQ extension methods (such as .Where),
            // making them appear identical on the surface. However, which interface you choose determines
            // whether that method evaluates in application RAM or translates into a database query.

            // -------------------------------------------------------------
            // Case 1: IEnumerable<T> (Client-side / In-Memory Evaluation)
            // -------------------------------------------------------------
            IEnumerable<Book> enumerableSource = db.Books;

            // Uses the Where method that belongs to the IEnumerable contract.
            // This causes EF Core to fetch the entire table first, leaving the filter
            // to be evaluated entirely inside application RAM (explained in Lesson 2 & 3).
            IEnumerable<Book> enumerableQuery = enumerableSource.Where(b => b.Price > 50);

            Console.WriteLine("--- Case 1: Inspecting IEnumerable SQL ---");
            // Demonstrates the SQL sent to the database: all rows are fetched without a WHERE clause
            Console.WriteLine(db.Books.AsQueryable().ToQueryString());

            Console.WriteLine("\n--- Case 1: IEnumerable Executed ---");
            foreach (var book in enumerableQuery)
            {
                Console.WriteLine($"{book.Title} | {book.Price}");
            }

            
            
            // -------------------------------------------------------------
            // Case 2: IQueryable<T> (Server-side / Database Evaluation)
            // -------------------------------------------------------------
            IQueryable<Book> queryableSource = db.Books;

            // Uses the Where method that belongs to the IQueryable contract.
            // This preserves the query definition so the database engine executes
            // the filter before returning matching rows (explained in Lesson 2 & 3).
            IQueryable<Book> queryableQuery = queryableSource.Where(b => b.Price > 50);

            Console.WriteLine("\n--- Case 2: Inspecting IQueryable SQL ---");
            // Displays the SQL statement translated and sent to SQL Server by the provider
            Console.WriteLine(queryableQuery.ToQueryString());

            Console.WriteLine("\n--- Case 2: IQueryable Executed ---");
            foreach (var book in queryableQuery)
            {
                Console.WriteLine($"{book.Title} | {book.Price}");
            }
        }
    }
}