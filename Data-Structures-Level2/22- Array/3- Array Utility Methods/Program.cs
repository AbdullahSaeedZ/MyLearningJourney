/*
================================================================================
Hands-On: Array Utility Methods (System.Array) — Core Static Operations
================================================================================

1. STATIC `System.Array` METHODS (WHAT EACH DOES & ITS BIG-O):
   1- `Array.Copy(source, destination, length)` — O(n):
      Copies `length` elements from `source` into an already-allocated `destination` 
      array starting at index `0`. Performs a **Shallow Copy** (copies values for 
      value types, or memory references for reference types—not deep clones).
      
   2- `Array.Resize(ref array, newSize)` — O(n):
      Allocates a brand-new array of `newSize`, copies existing elements over, 
      and updates your `array` variable to point to the new heap block (arrays 
      cannot actually grow in place).
      
   3- `Array.Sort(array)` — O(n log n):
      Sorts the array **in place** in ascending order using IntroSort (a hybrid 
      of QuickSort, HeapSort, and InsertionSort). Mutates the original array.
      
   4- `Array.Reverse(array)` — O(n):
      Reverses the order of elements **in place** by swapping from both ends 
      inward (`array[0]` <-> `array[Length - 1]`).
      
   5- `Array.Clear(array)` (or `Array.Clear(array, index, length)`) — O(n):
      Resets elements back to `default(T)` (`0` for `int`, `null` for `string`, 
      `false` for `bool`) without changing `.Length`.
      
   6- `Array.BinarySearch(sortedArray, value)` — O(log n):
      Finds `value` by repeatedly halving the search range. **Requirement:** The 
      array MUST already be sorted; otherwise, the result is undefined.
================================================================================
*/

using System;

namespace ArrayUtilityMethodsPractice;

class Program
{
    static void Main()
    {
        int[] numbers = { 40, 10, 50, 20, 30 };

        // =====================================================================
        // TASK 1: Array.Copy — O(n) Shallow Copy
        // =====================================================================
        // Allocate a new int[] named 'backup' with the same length as 'numbers'
        // Copy all elements from 'numbers' into 'backup' using Array.Copy()
        // Print 'backup' using string.Join(", ", backup)
        // Expected Output: Backup copied: [40, 10, 50, 20, 30]
        int[] backup = new int[numbers.Length];
        Array.Copy(numbers, backup, numbers.Length);

        Console.WriteLine($"backup array: {string.Join(", ", backup)}");

        // =====================================================================
        // TASK 2: Array.Sort — O(n log n) In-Place Ascending Sort
        // =====================================================================
        // Sort 'numbers' in place using Array.Sort()
        // Print 'numbers'
        // Expected Output: Sorted:        [10, 20, 30, 40, 50]
        Array.Sort(numbers);
        Console.WriteLine($"numbers array after sorting: {string.Join(", ", numbers)}");

        // =====================================================================
        // TASK 3: Array.BinarySearch — O(log n) Fast Lookup (Requires Sorted Array!)
        // =====================================================================
        // Find the index of 40 in the sorted 'numbers' array using Array.BinarySearch()
        // Store it in 'foundIndex' and print it
        // Expected Output: Index of 40:   3
        int foundIndex = Array.BinarySearch(numbers, 40);
        Console.WriteLine($"value 40 index using BinarySearch: {foundIndex}");


        // =====================================================================
        // TASK 4: Array.Reverse — O(n) In-Place Reversal
        // =====================================================================
        // Reverse 'numbers' in place using Array.Reverse()
        // Print 'numbers'
        // Expected Output: Reversed:      [50, 40, 30, 20, 10]
        Array.Reverse(numbers);
        Console.WriteLine($"numbers array reversed: {string.Join(", ", numbers)}");

        // =====================================================================
        // TASK 5: Array.Resize — O(n) Allocates New Array & Reassigns Reference
        // =====================================================================
        // Resize 'numbers' from 5 to 7 using Array.Resize(ref numbers, 7)
        // Set index 5 to 99 and index 6 to 100, then print 'numbers'
        // Expected Output: Resized (7):   [50, 40, 30, 20, 10, 99, 100]
        Array.Resize(ref numbers, 7);
        numbers[5] = 99;
        numbers[6] = 100;
        Console.WriteLine($"numbers array resized to 7: {string.Join(", ", numbers)}");


        // =====================================================================
        // TASK 6: Array.Clear — O(n) Resets Slots to default(T)
        // =====================================================================
        // Clear the first 2 elements of 'numbers' (starting at index 0, length 2) using Array.Clear()
        // Print 'numbers'
        // Expected Output: Cleared [0..1]:[0, 0, 30, 20, 10, 99, 100]
        Array.Clear(numbers, 0, 2);
        Console.WriteLine($"numbers array cleared (resetting to default) two items starting from index 0: {string.Join(", ", numbers)}");
    }
}