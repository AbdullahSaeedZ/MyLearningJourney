/*
================================================================================
LESSON 3: THE METHOD SIGNATURE SHOWDOWN (ENUMERABLE VS QUERYABLE)
================================================================================

1. GOAL OF THIS LESSON:
   - Compare the method signatures of Enumerable.Where and Queryable.Where.
   - Understand how the compiler decides between compiling a lambda into
     an executable delegate (Func) versus building an Expression Tree.
   - Learn at a high level how the Provider inspects the Expression Tree to
     produce SQL.

2. PROBLEM (WHY TWO SEPARATE EXTENSION CLASSES EXIST):
   - You write the exact same syntax: .Where(b => b.Price > 50).
   - If that lambda is compiled directly into machine instructions (Func),
     it becomes an opaque box. The database engine cannot see inside it or
     know which column or value to filter on.
   - C# needs two separate sets of extension methods:
       * One accepting executable code (Func) for local RAM operations.
       * One accepting inspectable data (Expression<Func>) for remote translation.

3. CORE IDEA:
   - Enumerable.Where: Belongs to System.Linq.Enumerable. It accepts a Func<T, bool>.
     The compiler compiles the lambda into IL instructions that execute directly in CPU/RAM.

   - Queryable.Where: Belongs to System.Linq.Queryable. It accepts an Expression<Func<T, bool>>.
     The compiler translates the lambda into an Expression Tree (data nodes).

+-------------------+--------------------+----------------------------+-----------------------+
| Extension Class   | Target Interface   | Parameter Type             | What the Lambda Is    |
+-------------------+--------------------+----------------------------+-----------------------+
| Enumerable        | IEnumerable<T>     | Func<T, bool>              | Executable Code (IL)  |
| Queryable         | IQueryable<T>      | Expression<Func<T, bool>>  | Inspectable Tree Data |
+-------------------+--------------------+----------------------------+-----------------------+

4. HOW IT WORKS INTERNALLY (THE HIGH-LEVEL TRANSLATION):
   - Interfaces define contracts, not implementation logic. The .Where() method
     does not live directly inside IEnumerable<T> or IQueryable<T>.
   - Instead, the static classes System.Linq.Enumerable and System.Linq.Queryable
     attach these methods via C# extension methods.
     
   - When you explicitly declare your variable as:
       * IEnumerable<Book> -> The compiler binds to Enumerable.Where(source, func)
       * IQueryable<Book>  -> The compiler binds to Queryable.Where(source, expression) <- that is what makes the difference
 
   - When Queryable.Where receives an Expression Tree:
       1. The compiler creates nodes: BinaryExpression (>), MemberExpression (Price), Constant (50).
       2. The query is passed to the Provider (EF Core).
       3. The Provider inspects the nodes with one goal: mapping those operations
          into the target database syntax (such as generating "WHERE [b].[Price] > 50.0").
       4. It sends that translated SQL command across the network to execute on the server.

5. WHEN NOT TO USE & COMMON PITFALLS:
   - Invoking custom C# methods inside an IQueryable lambda (e.g., .Where(b => CustomCheck(b))).
     The Provider cannot map your custom local C# method to SQL and throws an InvalidOperationException.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Data.Shared;

namespace LinqDeepDive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initializes the database context to open a session with the bookstore database
            using var db = new BookContext();

            // -------------------------------------------------------------
            // 1. Signature Showdown: What the Compiler Generates
            // -------------------------------------------------------------
            // Even though both lines look identical, the declared type of the variable
            // completely changes what the compiler emits:

            // A. Compiles to an opaque, executable delegate (Func):
            Func<Book, bool> inMemoryDelegate = b => b.Price > 50;

            // B. Compiles to an Expression Tree (inspectable data nodes):
            Expression<Func<Book, bool>> expressionTree = b => b.Price > 50;

            Console.WriteLine("=== 1. Inspecting the Generated Types ===");
            Console.WriteLine($"Func Type            : {inMemoryDelegate.GetType().Name}");
            Console.WriteLine($"Expression Tree Type : {expressionTree.GetType().Name}");
            Console.WriteLine($"Expression Body      : {expressionTree.Body}");

            
            
            
            
            // -------------------------------------------------------------
            // 2. Calling Enumerable.Where vs Queryable.Where
            // -------------------------------------------------------------

            // Case A: IEnumerable<T> (Enumerable.Where)
            // 1. Database context initiated above.
            // 2. Upcasting db.Books to IEnumerable binds to Enumerable.Where with deferred execution.
            IEnumerable<Book> enumerableSource = db.Books;
            IEnumerable<Book> enumerableQuery = enumerableSource.Where(b => b.Price > 50);

            Console.WriteLine("\n=== 2. Enumerable.Where Executed ===");
            // 3. Enumeration triggers EF Core to bring the entire table over the network.
            // 4. Filtering (b.Price > 50) is evaluated locally in application RAM.
            // 5. Matching results are printed.
            foreach (var book in enumerableQuery)
            {
                Console.WriteLine($"[RAM] {book.Title} | ${book.Price}");
            }

            
            
            
            // Case B: IQueryable<T> (Queryable.Where)
            // 1. Database context initiated above.
            // 2. Keeping reference as IQueryable binds to Queryable.Where with deferred execution (builds Expression Tree).
            IQueryable<Book> queryableSource = db.Books;
            IQueryable<Book> queryableQuery = queryableSource.Where(b => b.Price > 50);

            Console.WriteLine("\n=== 3. Queryable.Where Executed ===");
            Console.WriteLine("Generated SQL from Provider:");
            Console.WriteLine(queryableQuery.ToQueryString());

            // 3. Enumeration triggers the Provider to translate the tree into SQL ready with what we need.
            // 4. Filtering is executed remotely on SQL Server; only matching rows cross the wire.
            // 5. Matching results are printed.
            foreach (var book in queryableQuery)
            {
                Console.WriteLine($"[DB]  {book.Title} | ${book.Price}");
            }
        }
    }
}