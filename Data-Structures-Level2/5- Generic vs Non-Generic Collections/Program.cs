/*
 * ============================================================================
 * LESSON: GENERIC VS. NON-GENERIC COLLECTIONS IN C#
 * ============================================================================
 * 
 * Collections are data structures that can hold multiple elements. In C#, 
 * collections are broadly categorized into two types: generic and non-generic.
 * 
 * 
 * 1. GENERIC COLLECTIONS
 * ----------------------
 * What are Generic Collections?
 * - Part of the System.Collections.Generic namespace.
 * - Generics introduce the concept of type parameters (<T>), allowing code 
 *   to work with specific types safely and efficiently.
 * - Allow you to define the exact element type at instantiation (e.g., List<int>).
 * - Shift type checks to compile-time, preventing runtime type mismatches.
 * 
 * Advantages:
 * - Type Safety: Enforced at compile-time; impossible to insert unintended types.
 * - Performance: Value types are stored directly in stack memory, eliminating
 *   the need for boxing and unboxing.
 * - Reduced Memory Overhead: No extra heap wrapper objects created for value types.
 * - Code Reusability: Clean algorithms that operate on any specified type.
 * 
 * Key Generic Collections:
 * - List<T>                    : Dynamic resizable array.
 * - Dictionary<TKey, TValue>   : Key-value hash table.
 * - Queue<T>                   : First-In, First-Out (FIFO) queue.
 * - Stack<T>                   : Last-In, First-Out (LIFO) stack.
 * - HashSet<T>                 : Set of unique elements.
 * 
 *
 *
 * 
 * 2. NON-GENERIC COLLECTIONS
 * --------------------------
 * What are Non-Generic Collections?
 * - Part of the System.Collections namespace (legacy, dating back to .NET 1.0).
 * - Store every element as 'System.Object', accepting any mixed data types.
 * 
 * Disadvantages Compared to Generics:
 * - Type Unsafe: Accepts any arbitrary object, deferring errors to runtime.
 * - Boxing/Unboxing Overhead: Every value type (int, double, struct) added must 
 *   be boxed into a heap object, then unboxed upon retrieval.
 * - Memory Pressure: Boxing creates thousands of tiny heap objects that stress 
 *   the Garbage Collector.
 * 
 * Key Non-Generic Collections:
 * - ArrayList : Legacy resizable array storing 'object'.
 * - Hashtable : Legacy key-value store using 'object' for keys and values.
 * - Queue     : Legacy FIFO collection.
 * - Stack     : Legacy LIFO collection.
 * 
 * 
 * 3. BEST PRACTICE VERDICT
 * ------------------------
 * Always default to Generic Collections. 
 * Microsoft's official guidelines recommend generic collections for all modern 
 * development. Non-generic collections exist primarily for backward compatibility 
 * with legacy code. Even if you genuinely need to store mixed data types, use 
 * List<object> instead of ArrayList to keep access to modern generic LINQ APIs.
 */

using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsCourse
{
    internal class Lesson02_GenericVsNonGeneric
    {
        static void Main(string[] args)
        {
            // ================================================================
            // 1. NON-GENERIC: ArrayList (System.Collections)
            // ================================================================
            ArrayList nonGenericList = new ArrayList();

            // BOXING OCCURS HERE:
            // 10 and 20 are value types (int) on the stack.
            // ArrayList accepts 'object', so the runtime allocates a heap box 
            // for each number, copies the 4 bytes, and stores the heap address.
            nonGenericList.Add(10);
            nonGenericList.Add(20);

            // LACK OF TYPE SAFETY:
            // ArrayList accepts any type silently at compile time.
            nonGenericList.Add("Accidental String");

            // UNBOXING REQUIRED:
            // Retrieval gives an 'object'. You must cast it explicitly, which 
            // checks the heap type and copies the bytes back to the stack.
            int firstVal = (int)nonGenericList[0];
            Console.WriteLine($"ArrayList item (unboxed): {firstVal}");

            // RUNTIME CRASH TRAP:
            // The compiler cannot protect you here. This builds fine,
            // but crashes at runtime with System.InvalidCastException:
            /*
            int brokenVal = (int)nonGenericList[2]; // CRASH: "Accidental String" is not an int!
            */

            Console.WriteLine();

            // ================================================================
            // 2. GENERIC: List<T> (System.Collections.Generic)
            // ================================================================
            List<int> genericList = new List<int>();

            // ZERO BOXING:
            // List<int> is specialized at runtime as an underlying int[].
            // Raw 4-byte integers are written directly into the array without heap wrapping.
            genericList.Add(10);
            genericList.Add(20);

            // COMPILE-TIME TYPE SAFETY:
            // The compiler rejects mismatched types immediately.
            // genericList.Add("Accidental String"); // COMPILER ERROR: CS1503

            // DIRECT ACCESS (NO UNBOXING, NO CASTING):
            // The return type is already guaranteed to be 'int'.
            int genericFirstVal = genericList[0];
            Console.WriteLine($"List<int> item (zero boxing, type-safe): {genericFirstVal}");
        }
    }
}