/*
================================================================================
Hands-On: Working with SortedList<TKey, TValue>
================================================================================

Core Mechanics to Practice:
1. Instantiation & Adding elements (observing automatic key sorting).
2. Key-based access & safe retrieval (list[key], TryGetValue).
3. Index-based positional access (list.Keys[i], list.Values[i]).
4. Removal & containment checks (Remove, ContainsKey, ContainsValue).
5. Iteration over KeyValuePair<TKey, TValue>.
================================================================================
*/

using System;
using System.Collections.Generic;

namespace SortedListPractice;

class Program
{
    static void Main()
    {
        // =====================================================================
        // TASK 1: INSTANTIATION & AUTOMATIC KEY SORTING
        // GOALS:
        // - Declare and initialize a SortedList<int, string> named 'employeeDirectory'.
        // - Insert 4 entries in intentionally random key order:
        //     Key 104 -> "Dana"
        //     Key 101 -> "Alice"
        //     Key 103 -> "Charlie"
        //     Key 102 -> "Bob"
        // - Iterate through the collection with a foreach loop.
        // - Verify that the output prints strictly sorted by key (101 to 104).
        // =====================================================================
        SortedList<int, string> employeeDirectory = new SortedList<int, string>();
        
        // adding in random key order 
        employeeDirectory.Add(104, "Dana");
        employeeDirectory.Add(101, "Alice");
        employeeDirectory.Add(103, "Charlie");
        employeeDirectory.Add(102, "Bob");
        
        // duplicate key:
        //employeeDirectory.Add(102, "Bob"); // throws

        Console.WriteLine("printing pairs, asc sorted automatically:");
        foreach (KeyValuePair<int, string> Pair in employeeDirectory)
        {
            Console.WriteLine($"key: {Pair.Key}, value: {Pair.Value}");
        }

        // =====================================================================
        // TASK 2: DUAL ACCESS (BY KEY VS. BY NUMERIC INDEX)
        // GOALS:
        // - Use TryGetValue to safely look up employee with Key 103 and print the name.
        // - Attempt to look up Key 999 using TryGetValue and print a fallback message if not found.
        // - Access the smallest element using positional indexers (index 0) on .Keys and .Values.
        // - Access the largest element using the last valid index (^1 or Count - 1).
        // =====================================================================
        string emp103Name = employeeDirectory.TryGetValue(103, out string name) ? name : null;
        Console.WriteLine($"\n\nemp 103 name: {emp103Name}");
        
        string emp999Name = employeeDirectory.TryGetValue(999, out string nonExisting) ? nonExisting : "No such key";
        Console.WriteLine($"emp 999 name: {emp999Name}");

        Console.WriteLine($"smallest element index: key {employeeDirectory.Keys[0]}, value: {employeeDirectory.Values[0]}");
        
        Console.WriteLine($"largest element index: key {employeeDirectory.Keys[employeeDirectory.Count -1]}, value: {employeeDirectory.Values[employeeDirectory.Count -1]}");

        Console.WriteLine($"key-based access of emp 103: {employeeDirectory[103]}");

        // =====================================================================
        // TASK 3: MUTATION & CONTAINMENT CHECKS
        // GOALS:
        // - Check if Key 102 exists using ContainsKey.
        // - Remove Key 102 using .Remove().
        // - Verify Key 102 is gone by checking the new Count.
        // - Check if the value "Alice" exists using ContainsValue (note: this is O(n) cuz only keys are sorted and use binary search (O(log n)) but values are not sorted).
        // - Print all remaining elements to confirm the internal array shifted cleanly.
        // =====================================================================
        int oldCount = employeeDirectory.Count;
        
        Console.WriteLine($"\n\nkey 102 exists? {employeeDirectory.ContainsKey(103)}");
        Console.WriteLine($"key 102 removed? {employeeDirectory.Remove(102)}");
        Console.WriteLine($"old count: {oldCount}, new count after removal: {employeeDirectory.Count}");
        Console.WriteLine($"value \"Alice\" exists? {employeeDirectory.ContainsValue("Alice")}");
        
        Console.WriteLine("printing pairs:");
        foreach (KeyValuePair<int, string> Pair in employeeDirectory)
        {
            Console.WriteLine($"key: {Pair.Key}, value: {Pair.Value}");
        }
    }
}