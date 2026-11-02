/*
================================================================================
Lesson 2: Cast vs. OfType (Handling Mixed Type Sequences)
================================================================================

1. PROBLEM (WHY THEY EXIST):
   - You have a collection containing a base class (like Shipping), but the actual
     objects inside are mixed derived types (GroundShipping, AirShipping, OceanShipping).
   - You want to extract and work with only one specific derived type (e.g., GroundShipping).
   - If you use .Cast<T>(), it assumes every single item in the sequence is that type.
     The moment it hits an item of a different type, it throws an InvalidCastException at runtime.
   - How do we safely filter for a specific derived type without crashing?

2. CORE IDEA:
   - .Cast<T>(): Strict casting. Attempts to cast all items to T. Fails if any item cannot be cast.
   - .OfType<T>(): Safe filtering + casting in one step. Keeps matching types and skips the rest.

+--------------------+---------------------+---------------------+---------------------------------------+
| Method             | Non-matching Items  | Execution Behavior  | Purpose                               |
+--------------------+---------------------+---------------------+---------------------------------------+
| .Cast<T>()         | Throws Exception    | Immediate Failure   | Strict casting when all items MUST    |
|                    | InvalidCastException| upon iteration      | match the target type.                |
+--------------------+---------------------+---------------------+---------------------------------------+
| .OfType<T>()       | Safely Ignored      | Yields only matches | Filtering a mixed sequence to extract |
|                    | Silently skipped    | without throwing    | a specific derived subtype.           |
+--------------------+---------------------+---------------------+---------------------------------------+

3. HOW IT WORKS INTERNALLY:
   - .Cast<T>(): Runs an explicit cast `(T)item` inside a foreach loop.
     If the cast is invalid, the CLR throws InvalidCastException.
   - .OfType<T>(): Checks each item using `item is T`. If true, it yields `(T)item`.
     If false, it silently skips to the next item.

4. WHEN NOT TO USE & COMMON PITFALLS:
   - Do not write `.Where(x => x.GetType() == typeof(T)).Cast<T>()`.
     It is redundant and clunky. Use `.OfType<T>()` instead.
   - Do not use `.Cast<T>()` on collections with mixed derived types unless you
     want runtime crashes when unexpected types appear.
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
            // Initial mixed collection of Shipping objects (Ground, Air, Ocean, Rail)
            IEnumerable<Shipping> shippings = ShippingRepository.AllAsList;

            // =============================================================
            // 1. The Issue: .Cast<T>() on a Mixed Collection
            // =============================================================
            // .Cast<GroundShipping>() assumes every element is a GroundShipping.
            // Because the list contains AirShipping and other types, iterating this throws:
            Console.WriteLine("=== 1. Attempting .Cast<GroundShipping>() ===");
            try
            {
                IEnumerable<GroundShipping> groundShippings = shippings.Cast<GroundShipping>();
                groundShippings.Process("Ground shippings"); // Throws InvalidCastException
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"[CRASH]: {ex.GetType().Name} -> {ex.Message}\n");
            }

            // =============================================================
            // 2. The Clunky Fix: Filtering before Casting
            // =============================================================
            // Pre-filtering with Where prevents the cast failure, but it is verbose:
            Console.WriteLine("=== 2. Pre-Filtering with .Where() before .Cast() ===");
            IEnumerable<GroundShipping> groundShippingsWhere = shippings
                .Where(x => x.GetType() == typeof(GroundShipping))
                .Cast<GroundShipping>();

            groundShippingsWhere.Process("Ground shippings via Where + Cast");

            // =============================================================
            // 3. The Clean Solution: .OfType<T>()
            // =============================================================
            // .OfType<T>() filters and casts in a single operation.
            // Non-matching types are silently skipped without throwing exceptions.
            Console.WriteLine("\n=== 3. Clean Solution with .OfType<GroundShipping>() ===");
            IEnumerable<GroundShipping> safeGroundShippings = shippings.OfType<GroundShipping>();

            safeGroundShippings.Process("Ground shippings via OfType");
        }
    }
}