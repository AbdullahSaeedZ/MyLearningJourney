/*
================================================================================
Working with ArrayList — Complete Reference Example
================================================================================

Core Mechanics Demonstrated:
1. Heterogeneous storage: Mixing int, string, bool, and double in one list.
2. Capacity vs. Count: Observing 2x capacity expansion and manual shrinking 
   via .TrimToSize().
3. Positional mutation: .Insert(), .Remove(), .RemoveAt().
4. Runtime unboxing & casting risks: Using 'is' pattern matching (or explicit 
   casts) because the compiler sees every element strictly as 'object'.
================================================================================
*/

using System;
using System.Collections;

namespace ArrayListReference;

class Program
{
    static void Main()
    {
        // 1. Instantiation & Heterogeneous Insertion
        // Starts at Capacity = 0, jumps to 4 on first Add, then doubles to 8
        ArrayList mixedList = new ArrayList();
        mixedList.Add(42);              // int (boxed onto heap)
        mixedList.Add("Backend");       // string (reference type)
        mixedList.Add(true);            // bool (boxed onto heap)
        mixedList.Add(99.95);           // double (boxed onto heap)
        mixedList.Add("TempItem");      // Triggers resize: Capacity 4 -> 8

        Console.WriteLine($"Count: {mixedList.Count}, Capacity: {mixedList.Capacity}");
        // Output: Count: 5, Capacity: 8


        // 2. Positional Insertion & Removal
        mixedList.Insert(1, "Inserted"); // Shifts elements right: O(n)
        mixedList.Remove("TempItem");    // Linear scan + shift left: O(n)
        mixedList.RemoveAt(0);           // Removes 42 + shift left: O(n)

        Console.WriteLine($"After removals -> Count: {mixedList.Count}, Capacity: {mixedList.Capacity}");
        // Output: Count: 4, Capacity: 8 (Capacity did NOT shrink automatically)


        // 3. Reclaiming Unused Memory (.TrimToSize)
        mixedList.TrimToSize(); // Reallocates internal object[] to match Count: O(n)
        Console.WriteLine($"After TrimToSize -> Count: {mixedList.Count}, Capacity: {mixedList.Capacity}");
        // Output: Count: 4, Capacity: 4


        // 4. Reading & Type-Safe Unboxing
        // Indexer returns 'object' — requires explicit cast or pattern matching
        string secondItem = (string)mixedList[1]; // Explicit cast (throws InvalidCastException if wrong)
        Console.WriteLine($"Index 1: {secondItem}");

        // Safe iteration across mixed types using pattern matching
        Console.WriteLine("\nAll elements:");
        foreach (object item in mixedList)
        {
            switch (item)
            {
                case string s:
                    Console.WriteLine($"[String] {s}");
                    break;
                case bool b:
                    Console.WriteLine($"[Bool]   {b}");
                    break;
                case double d:
                    Console.WriteLine($"[Double] {d:F2}");
                    break;
            }
        }
    }
}
