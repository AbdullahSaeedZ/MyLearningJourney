/*
================================================================================
LESSON 2: ANATOMY OF THE INTERFACES
================================================================================

1. GOAL OF THIS LESSON:
   - Inspect the internal members of both IEnumerable<T> and IQueryable<T>.
   - Understand why IEnumerable only moves forward through existing objects.
   - Understand how IQueryable carries an Expression Tree, an ElementType, and a Provider.
   - See how IQueryable inherits from IEnumerable while adding these three capabilities.

2. PROBLEM (WHY IQUERYABLE NEEDS A DIFFERENT STRUCTURE):
   - IEnumerable<T> only provides an enumerator: a cursor to step through
     objects already stored in memory one by one.
   - A cursor cannot read your C# filter logic, inspect your conditions, or
     translate them into a database language like SQL.
   - To run queries on a remote database, an interface must store the query
     as an inspectable tree structure rather than closed executable machine code.

3. CORE IDEA:
   - IEnumerable<T> contract:
       * Exposes: GetEnumerator()
       * Role: Steps forward one by one through existing objects in RAM.
 
   - IQueryable<T> contract (inherits from IEnumerable<T>):
       * Exposes: Expression, ElementType, and Provider (IQueryProvider)
       * Role: Stores the query as an Expression Tree and points to the Provider
         that translates and runs it against the database.

   +------------------+-----------------------+---------------------------------------+
   | Interface        | Member                | Purpose                               |
   +------------------+-----------------------+---------------------------------------+
   | IEnumerable<T>   | GetEnumerator()       | Returns cursor to step through items  |
   +------------------+-----------------------+---------------------------------------+
   | IQueryable<T>    | GetEnumerator()       | Inherited: triggers query execution   |
   |                  | Expression            | Holds the query Expression Tree       |
   |                  | ElementType           | Data type of the returned items       |
   |                  | Provider              | Engine that translates & runs query   |
   +------------------+-----------------------+---------------------------------------+

4. HOW IT WORKS INTERNALLY:
   - Inside an IQueryable instance:
       1. Expression: Holds the Expression Tree that represents your LINQ query.
       2. ElementType: Tells .NET what type of items the query returns.
       3. Provider: The engine that reads the Expression Tree, converts it to
          SQL, and sends it to the database engine.
   - Because IQueryable inherits from IEnumerable, you can iterate it with foreach.
     The moment foreach calls GetEnumerator(), the Provider compiles the Expression
     Tree to SQL, queries the database, and returns the result rows.

5. WHEN NOT TO USE & COMMON PITFALLS:
   - Expecting IQueryable to execute upon declaration: nothing runs against the
     database until you iterate (foreach), call ToList(), or call a terminating method.
   - Trying to inspect complex Expression Trees manually without need; they are
     designed primarily for query providers to translate.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

            // -------------------------------------------------------------
            // 1. Inspecting IEnumerable<T> Contract
            // -------------------------------------------------------------
            // IEnumerable<T> exposes only one method: GetEnumerator().
            // It steps through objects that already exist in memory.
            IEnumerable<Book> enumerable = db.Books.ToList();

            Console.WriteLine("=== 1. IEnumerable Inspection ===");
            Console.WriteLine($"Type: {enumerable.GetType().Name}");

            // Moving through IEnumerable manually using its forward cursor:
            using (IEnumerator<Book> enumerator = enumerable.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    Console.WriteLine($"First Book via Enumerator: {enumerator.Current.Title}");
                }
            }

            // -------------------------------------------------------------
            // 2. Inspecting IQueryable<T> Contract
            // -------------------------------------------------------------
            // IQueryable extends IEnumerable by exposing three distinct properties:
            // 1. ElementType -> The Type of items in the sequence.
            // 2. Expression  -> The Expression Tree representing the query logic.
            // 3. Provider    -> The engine that translates the Expression Tree (EF Core).
            IQueryable<Book> queryable = db.Books.Where(b => b.Price > 50);

            Console.WriteLine("\n=== 2. IQueryable Anatomy ===");
            
            // Property 1: ElementType
            Console.WriteLine($"ElementType : {queryable.ElementType.FullName}");

            // Property 2: Expression (Expression Tree, inspectable data)
            Console.WriteLine($"Expression  : {queryable.Expression}");
            Console.WriteLine($"Node Type   : {queryable.Expression.NodeType}");

            // Property 3: Provider (The translation engine)
            Console.WriteLine($"Provider    : {queryable.Provider.GetType().FullName}");

            // -------------------------------------------------------------
            // 3. Execution (Inherited IEnumerable Behavior)
            // -------------------------------------------------------------
            // Because IQueryable inherits from IEnumerable, calling foreach triggers
            // GetEnumerator(). This prompts the Provider to translate the Expression Tree
            // into SQL and fetch matching rows from SQL Server.
            Console.WriteLine("\n=== 3. Executing Query via Enumeration ===");
            foreach (var book in queryable)
            {
                Console.WriteLine($"{book.Title} | ${book.Price}");
            }
        }
    }
}