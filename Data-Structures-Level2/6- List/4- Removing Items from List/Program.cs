/*
 * ============================================================================
 * LESSON: REMOVING ITEMS FROM A LIST IN C#
 * ============================================================================
 * 
 * 1. REMOVAL METHODS & TIME COMPLEXITY
 * ------------------------------------
 * - Remove(value) [O(N)]:
 *   * Searches sequentially (O(N)) for the first occurrence of the item.
 *   * If found, removes it and shifts all subsequent elements left (O(N)).
 *   * Returns true if found and removed; otherwise false.
 * 
 * - RemoveAt(index) [O(N)]:
 *   * Direct index lookup (O(1)), but must shift subsequent elements left (O(N)).
 *   * Throws ArgumentOutOfRangeException if the index is out of bounds.
 * 
 * - RemoveAll(predicate) [O(N)]:
 *   * Removes all elements matching a condition using a single pass (in-place shift).
 *   * Returns the count of removed elements.
 * 
 * 
 * 2. CLEARING THE LIST: Clear()
 * -----------------------------
 * - Empties the list (Count resets to 0), but the allocated Capacity stays unchanged.
 * 
 * - Value Types [O(1)]: Simply resets the internal _size field to 0.
 * - Reference Types [O(N)]: Sets every slot to null via Array.Clear() so the 
 *   Garbage Collector can reclaim memory for the unreferenced objects.
 */

namespace _4__Removing_Items_from_List;

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Initialize list with a preset capacity to avoid early reallocations
        List<string> names = new List<string>(capacity: 10) 
        { 
            "Dev.Abdullah", "Eng.Ali", "Dev.Nora", "Dr.Nasser", "Mr.Khalid", "Mr.Rashid" 
        };
        Console.WriteLine("List:\n" + string.Join(", ", names));

        // 1. Remove by Value: searches for first match, removes it, shifts subsequent items left
        names.Remove("Dr.Nasser");
        Console.WriteLine("\nRemove by value (Dr.Nasser):\n" + string.Join(", ", names));

        // 2. Remove by Index: removes element at index 3 and shifts remaining elements left
        names.RemoveAt(3);
        Console.WriteLine("\nRemove by index (3):\n" + string.Join(", ", names));

        // 3. Remove by Predicate: removes all matches in a single O(N) pass
        names.RemoveAll(name => name.StartsWith("Dev"));
        Console.WriteLine("\nRemove by a predicate (starting with Dev):\n" + string.Join(", ", names));

        // 4. Clearing the List:
        // Resets Count to 0 while keeping the allocated Capacity intact.
        // O(N) here because strings are reference types, requiring Array.Clear() to null references.
        names.Clear();
        Console.WriteLine("\nList after clearing:\n" + string.Join(", ", names));
    }
}