/*
====================================================================================================
                        LINQ COMPARISON - GroupBy() vs. ToLookup()
====================================================================================================

1. THE PROBLEM:
   Developers often assume GroupBy() and ToLookup() are interchangeable because both partition
   elements into key-based groups. In reality, choosing the wrong operator causes severe
   performance regressions or incorrect query semantics:
     - Performance Degradation: Re-evaluating expensive upstream queries multiple times.
     - Stale Data Bugs: Assuming an in-memory lookup will reflect future mutations to the underlying
       source.

   The "Single-Pass (used in one time process) vs. Multi-Pass (used in multiple processes)" operational rule:
     - GroupBy uses deferred execution. Iterating over the sequence multiple times forces the runtime
       to scan, hash, and partition the underlying source sequence on every single iteration.
       
     - ToLookup uses immediate execution. It reads the source sequence once, instantiates the
       buckets, and freezes them into an in-memory structure. Subsequent key lookups or iterations
       read directly from this cached structure without re-evaluating the source.

2. THE CORE IDEA:
   GroupBy creates a deferred query execution plan, whereas ToLookup creates an immutable,
   materialized one-to-many lookup table.

   GroupBy (Deferred Query Plan):
   Source ──► [ Query Blueprint ] ──► Each iteration re-evaluates source sequence.
                                       No indexer (`groups["HR"]` does not compile).

   ToLookup (Immediate Snapshot / 1:N Structure):
   Source ──► [ Evaluates Once ] ──► Fixed In-Memory Table: ILookup<TKey, TElement>
                                      O(1) Average Indexer: `lookup["HR"]`.

   Architectural Comparison:
   ┌──────────────────────┬───────────────────────────────┬───────────────────────────────┐
   │ Dimension            │ GroupBy()                     │ ToLookup()                    │
   ├──────────────────────┼───────────────────────────────┼───────────────────────────────┤
   │ Execution Model      │ Deferred                      │ Immediate (Eager)             │
   │ Return Type          │ IEnumerable<IGrouping<K, V>>  │ ILookup<K, V>                 │
   │ Indexer Access       │ Not supported                 │ Supported (`lookup[key]`)     │
   │ Multi-pass Iteration │ Re-executes the pipeline      │ Reuses the in-memory cache    │
   │ Query Syntax Support │ Supported (`group by`)        │ Not supported (Method only)   │
   └──────────────────────┴───────────────────────────────┴───────────────────────────────┘

3. HOW IT WORKS INTERNALLY:
   - GroupBy: Yields an iterator. Invoking the method performs no partitioning. When enumeration
     begins, elements are buffered into internal hash structures to yield groups, which are then
     discarded once the enumeration cycle completes.
   - ToLookup: Instantly consumes the underlying source sequence upon invocation. It partitions
     elements into internal arrays grouped by key and wraps them inside an immutable ILookup
     container. Lookups via the indexer execute with O(1) average time complexity.

4. COMMON PITFALLS & INTERVIEW HIGHLIGHTS:
   - Linear Lookups on GroupBy: Writing `.Where(g => g.Key == "HR")` or `.First(g => g.Key == "HR")`
     on a GroupBy sequence executes an O(N) scan across the groups on every call. Use ToLookup for
     frequent, key-based random access.
   - Eager Memory Pressure: Calling ToLookup() on large datasets allocates memory for the entire
     partition structure upfront, even if only a single key is accessed downstream.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using GroupingData.Shared;

namespace _3__GroupBy_vs_ToLookup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            // -------------------------------------------------------------------------
            // SCENARIO 1: GroupBy (Deferred Execution - Single-pass pipelines)
            // -------------------------------------------------------------------------
            // Definition only; no grouping occurs at this point.
            IEnumerable<IGrouping<string, Employee>> groupedDeferred = employees.GroupBy(
                (Employee emp) => emp.Department
            );

            // First evaluation occurs during enumeration:
            Console.WriteLine("--- Iterating GroupBy (Pass 1) ---");
            foreach (IGrouping<string, Employee> group in groupedDeferred)
            {
                Console.WriteLine($"Department: {group.Key}, Count: {group.Count()}");
            }

            // A second enumeration re-evaluates the entire grouping operation from scratch.

            // -------------------------------------------------------------------------
            // SCENARIO 2: ToLookup (Immediate Execution - Multiple lookups & operations)
            // -------------------------------------------------------------------------
            // Evaluated and loaded into memory on this line:
            ILookup<string, Employee> lookupSnapshot = employees.ToLookup(
                (Employee emp) => emp.Department
            );

            
            // ------  Multi-Pass (used in many processes) ------
            // Operation 1: Direct key retrieval (O(1))
            Console.WriteLine("\n--- Operation 1: Direct Access for 'HR' ---");
            foreach (Employee emp in lookupSnapshot["HR"])
            {
                Console.WriteLine($"HR Member: {emp.FirstName}");
            }

            // Operation 2: Secondary retrieval using the existing in-memory structure
            Console.WriteLine("\n--- Operation 2: Direct Access for 'IT' ---");
            foreach (Employee emp in lookupSnapshot["IT"])
            {
                Console.WriteLine($"IT Member: {emp.FirstName}");
            }

            // Operation 3: Full sequence iteration reusing cached partitions
            Console.WriteLine("\n--- Operation 3: Enumerating All Partitions ---");
            foreach (IGrouping<string, Employee> group in lookupSnapshot)
            {
                Console.WriteLine($"Department: {group.Key}, Count: {group.Count()}");
            }
        }
    }
}