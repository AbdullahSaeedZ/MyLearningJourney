/*
================================================================================
Lesson 2: Boundary Control with AsEnumerable and AsQueryable
================================================================================

1. PROBLEM (WHY THEY EXIST):
   - In Lesson 1, we learned that crossing boundaries with .ToList() is eager:
     it executes queries immediately and allocates fresh memory in RAM.
   - What if you already have an IEnumerable<T> or an IQueryable<T> and need to
     switch tracks between them WITHOUT executing queries or copying items?
     
   - Moving from IEnumerable to IQueryable:
     A method or query builder strictly demands an IQueryable (Expression Tree),
     so you can build queries dynamically before running them.
     
   - Moving from IQueryable to IEnumerable:
     You want to step out of the IQueryable track and treat subsequent operations
     as in-memory streaming (IEnumerable), without buffering into a List.

2. CORE IDEA:
   - "As..." operators do NOT copy, allocate new collections, or execute queries.
   - They switch the compile-time type track back and forth:
       * IEnumerable<T>  ---- .AsQueryable() ---->  IQueryable<T>
       * IQueryable<T>   ---- .AsEnumerable() --->  IEnumerable<T>

+------------------+---------------------------------+------------------+------------------------------------+
| Operator         | Type Transition                 | Runtime Cost     | Primary Purpose                    |
+------------------+---------------------------------+------------------+------------------------------------+
| .AsQueryable()   | IEnumerable<T> -> IQueryable<T> | O(1) Wrapper     | Wraps in-memory sequence into      |
|                  |                                 | Evaluates in RAM | an IQueryable with Expression Tree.|
+------------------+---------------------------------+------------------+------------------------------------+
| .AsEnumerable()  | IQueryable<T> -> IEnumerable<T> | O(1) Upcast      | Steps down to IEnumerable stream   |
|                  |                                 | Zero allocation  | while preserving lazy execution.   |
+------------------+---------------------------------+------------------+------------------------------------+

3. HOW IT WORKS INTERNALLY:
   - .AsQueryable(): Wraps the IEnumerable inside an EnumerableQuery<T>.
     Calling .Where() on it binds to Queryable.Where, generating an Expression Tree.
   - .AsEnumerable(): Returns the instance directly upcast to IEnumerable<T>.
     Calling .Where() on it binds to Enumerable.Where, taking a Func delegate.

4. WHEN NOT TO USE & COMMON PITFALLS:
   - Calling .AsQueryable() does NOT translate in-memory LINQ into SQL. It still runs in RAM.
   - Calling .AsEnumerable() does NOT load data into memory immediately; execution remains deferred.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Conversion.Shared;

namespace LinqDeepDive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------
            // Stage 0: Initial sequence typed as IEnumerable<Shipping>
            // -------------------------------------------------------------
            IEnumerable<Shipping> source = ShippingRepository.AllAsList;

            // -------------------------------------------------------------
            // 1. IEnumerable -> IQueryable (Using .AsQueryable)
            // -------------------------------------------------------------
            // Wraps the IEnumerable into an IQueryable contract.
            // No elements are copied.
            IQueryable<Shipping> queryable = source.AsQueryable();

            Console.WriteLine("=== 1. Filtering on IQueryable Track ===");
            
            // Calling .Where() here binds to Queryable.Where(Expression<Func<Shipping, bool>>)
            // It builds an Expression Tree representation of the filter.
            IQueryable<Shipping> queryFiltered = queryable.Where(s => s.Sender.StartsWith("A"));

            // Executing the IQueryable sequence:
            queryFiltered.Process("Shippings Filtered via Queryable.Where");

            // -------------------------------------------------------------
            // 2. IQueryable -> IEnumerable (Using .AsEnumerable)
            // -------------------------------------------------------------
            // Switches the track back from IQueryable to IEnumerable.
            // Zero memory allocated; deferred execution preserved.
            IEnumerable<Shipping> backToEnumerable = queryFiltered.AsEnumerable();

            Console.WriteLine("\n=== 2. Filtering on IEnumerable Track ===");

            // Calling .Where() here binds to Enumerable.Where(Func<Shipping, bool>)
            // It executes directly as in-memory delegate filtering.
            IEnumerable<Shipping> enumerableFiltered = backToEnumerable.Where(s => s.ShippingDate == DateTime.Today);

            // Iteration triggers execution:
            enumerableFiltered.Process("Shippings Filtered via Enumerable.Where");

            // This is how to switch boundaries while keeping deferred execution, without immediate execution like .ToList().
        }
    }
}