/*
 * ============================================================================
 * LESSON: INTRODUCTION TO COLLECTIONS IN C#
 * ============================================================================
 * 
 * 1. THE PROBLEM: WHY DO WE NEED COLLECTIONS BEYOND RAW ARRAYS?
 * -------------------------------------------------------------
 * Raw arrays (e.g., int[]) are fixed-size blocks of contiguous memory.
 * They are extremely fast for direct index lookups, but in real-world software:
 * 
 * - Fixed Capacity: Array sizes must be set at creation. Expanding an array 
 *   requires allocating a brand new array and copying all elements over.
 * 
 * - Limited Operations: Arrays lack built-in behaviors like checking for 
 *   duplicates, tracking insertion order, or managing dynamic workloads.
 * 
 * - Mismatched Access Patterns: Different algorithms demand specific rules:
 *   * LIFO (Last-In, First-Out) for undo/redo or execution stacks.
 *   * FIFO (First-In, First-Out) for background job processing.
 *   * Key-Value associations for instant lookup without looping.
 * 
 * Collections solve these challenges by wrapping underlying data structures 
 * with dynamic sizing, automatic memory management, and specialized APIs—which 
 * are simply built-in, optimized methods designed to perform common operations 
 * much faster and with minimal boilerplate.
 * 
 * 
 * 2. COMMON COLLECTION TYPES IN C#
 * -----------------------------------------
 * - List                 : Dynamic contiguous array with automatic resizing.
 * - SortedList           : Key-value collection kept sorted by key.
 * - Dictionary           : High-speed key-value lookup based on hash tables.
 * - Hashtable            : Key-value store that works with general objects.
 * - ArrayList            : Dynamic array that stores items as general objects.
 * - HashSet              : Unordered collection enforcing unique items (no duplicates).
 * - Stack                : LIFO (Last-In, First-Out) access pattern.
 * - Queue                : FIFO (First-In, First-Out) access pattern.
 * - LinkedList           : Doubly-linked nodes allowing fast insertions anywhere.
 * - ObservableCollection : Dynamic list that notifies listeners when items change.
 * - ConcurrentDictionary : Thread-safe dictionary built for multi-threaded access.
 * - BitArray             : Highly compact array of boolean flags using single bits.
 */

using System;
using System.Collections.Generic;

namespace CollectionsCourse
{
    internal class Lesson01_IntroToCollections
    {
        static void Main(string[] args)
        {
            // --------------------------------------------------------
            // 1. Raw Array Limitation: Fixed Size
            // --------------------------------------------------------
            int[] rawArray = new int[2];
            rawArray[0] = 10;
            rawArray[1] = 20;
            // Adding a 3rd element here would throw IndexOutOfRangeException.

            // --------------------------------------------------------
            // 2. Dynamic Collection: Automatic Resizing
            // --------------------------------------------------------
            List<int> dynamicNumbers = new List<int>();
            dynamicNumbers.Add(10);
            dynamicNumbers.Add(20);
            dynamicNumbers.Add(30); // Grows dynamically without manual resizing
            Console.WriteLine($"Dynamic list count: {dynamicNumbers.Count}");

            // --------------------------------------------------------
            // 3. Specialized Behavior Preview: Key-Value Lookup
            // --------------------------------------------------------
            Dictionary<string, int> userAges = new Dictionary<string, int>
            {
                ["Abdullah"] = 25,
                ["Fahad"] = 30
            };
            Console.WriteLine($"Instant key lookup: {userAges["Abdullah"]}");

            // --------------------------------------------------------
            // 4. Specialized Behavior Preview: Enforcing Uniqueness
            // --------------------------------------------------------
            HashSet<int> uniqueIds = new HashSet<int> { 101, 102, 101 };
            Console.WriteLine($"HashSet count (duplicates dropped): {uniqueIds.Count}"); // Prints 2
        }
    }
}