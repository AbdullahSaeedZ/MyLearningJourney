/*
 * ============================================================================
 * LESSON: INSERTING ELEMENTS INTO A LIST IN C#
 * ============================================================================
 * 
 * 1. INSERTION STRATEGIES & TIME COMPLEXITY
 * -----------------------------------------
 * - Collection Initializer { }: Populates items at declaration via compiler-generated Add() calls.
 * 
 * - Appending to the End (Amortized O(1)):
 *   * Add(item): Appends a single element to the end.
 *   * AddRange(collection): Appends an entire sequence (IEnumerable<T>) to the end.
 *
 *   * "Amortized" means it is O(1) almost every time, averaged over many additions;
 *     an occasional O(N) spike occurs only when the internal array fills up, doubles in size,
 *     and must copy all N existing items into the new memory buffer.
 * 
 * - Inserting at an Index (O(N)):
 *   * Insert(index, item): Inserts a single item at a specified index.
 *   * InsertRange(index, collection): Inserts multiple items starting at an index.
 *   * Slower because all subsequent elements must physically shift right in memory.
 */

namespace _3__Inserting_Elements_into_a_List;

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Collection Initializer: populates list at declaration
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Console.WriteLine("List items inserted by initialization:\n" + string.Join(", ", numbers));

        // ----------------------------------------------------
        // 2. Appending at the End (Amortized O(1))
        // ----------------------------------------------------
        
        // Add single item
        numbers.Add(100);
        Console.WriteLine("\nAdd(100):\n" + string.Join(", ", numbers));

        // AddRange with array
        numbers.AddRange(new int[] { 11, 22 });
        Console.WriteLine("\nAddRange(new int[] {11, 22}):\n" + string.Join(", ", numbers));

        // AddRange with another List
        numbers.AddRange(new List<int> { 33, 44 });
        Console.WriteLine("\nAddRange(new List<int> {33, 44}):\n" + string.Join(", ", numbers));

        // ----------------------------------------------------
        // 3. Inserting at Specific Index (O(N) - shifts elements right)
        // ----------------------------------------------------
        
        // Insert single item at index 1
        numbers.Insert(1, 22);
        Console.WriteLine("\nInsert(1 index, 22 value):\n" + string.Join(", ", numbers));

        // Insert multiple items starting at index 3
        numbers.InsertRange(3, new List<int> { 13, 13 });
        Console.WriteLine("\nInsertRange(new List<int> {13, 13}):\n" + string.Join(", ", numbers));
    }
}