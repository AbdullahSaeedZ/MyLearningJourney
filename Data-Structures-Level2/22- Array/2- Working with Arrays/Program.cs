/*
   ================================================================================
   Working with Arrays (T[]) — Initialization, Core Operations & Big-O Reference
   ================================================================================
   
   1. TWO WAYS OF INITIALIZATION:
      1- Size-First (`new T[size]`):
         Allocates a fixed block of `size` slots on the heap filled with `default(T)` 
         (`0` for `int`, `null` for `string`, `false` for `bool`), ready to be 
         populated by index later.
         
      2- Inline Values (`new T[] { ... }` or C# 12+ `[ ... ]`):
         Allocates and populates the array in one step; the compiler counts the 
         items and sets the fixed `.Length` automatically.
   
   
   2. CORE PROPERTIES, INDEXING & METHODS (WHAT EACH DOES & ITS BIG-O):
      1- `array.Length` (Property) — O(1):
         Returns the total fixed number of slots allocated in the array (cached 
         directly in the array's object header, so no counting loop occurs).
         
      2- `array[i]` (Index Read / Write) — O(1):
         Reads or overwrites the element at index `i` instantly using direct memory 
         offset math (`BaseAddress + i * ElementSize`). Throws `IndexOutOfRangeException` 
         if `i < 0` or `i >= array.Length`.
         
      3- `array[^1]` (Index-From-End Operator) — O(1):
         Shorthand syntax that translates at compile time to `array[array.Length - 1]`, 
         giving instant access to the last element without manual length math.
         
      4- `Array.IndexOf(array, value)` (Static Search Method) — O(n):
         Scans elements sequentially from index `0` to `Length - 1` using equality 
         comparison (`Equals`). Returns the first matching index, or `-1` if absent.
         
      5- `for (int i = 0; i < array.Length; i++)` (Indexed Loop) — O(n):
         Walks every slot sequentially while exposing the index `i`—required when 
         you need to overwrite elements (`array[i] = ...`) or track positions.
         
      6- `foreach (T item in array)` (Read-Only Loop) — O(n):
         Walks every element sequentially from `0` to `Length - 1` cleanly without 
         index variables; prevents modifying the iteration variable itself.
   ================================================================================
   */

using System;

namespace ArrayBasicsPractice;

class Program
{
    static void Main()
    {
        // =====================================================================
        // TASK 1: TWO WAYS OF INITIALIZATION
        // =====================================================================
        // Way A: Size-first allocation (all slots initialized to default(int) = 0)
        // Declare an int[] named 'scores' of size 4, then assign: 85, 92, 78, 95
        int[] scores = new int[4];
        scores[0] = 85;
        scores[1] = 92;
        scores[2] = 78;
        scores[3] = 95;

        // Way B: Inline literal initialization (compiler infers Length = 4)
        // Declare a string[] named 'days' initialized inline with: "Sun", "Mon", "Tue", "Wed"
        string[] days = { "sun", "mon", "tue", "wed" };


        // =====================================================================
        // TASK 2: BASIC OPERATIONS (O(1) INDEXING & BOUNDS)
        // =====================================================================
        // Print 'scores.Length'                       // Expected Output: Total scores: 4
        // Print the first score via O(1) index read   // Expected Output: First score:  85
        // Print the last day using index-from-end [^1]// Expected Output: Last day:     Wed
        Console.WriteLine($"scores length: {scores.Length}");
        Console.WriteLine($"first score via O(1) index read: {scores[0]}");
        Console.WriteLine($"last day using index-from-end [^1]: {scores[^1]}");

        // Mutate index 2 of 'scores' in place from 78 to 88 — O(1)
        scores[2] = 88;


        // =====================================================================
        // TASK 3: ITERATION & BUILT-IN LINEAR SEARCH
        // =====================================================================
        // Loop through 'scores' using a 'for' loop and print: "Index [i] = value"
        // (Best when you need the index 'i' or are modifying slots)
        Console.WriteLine($"\nScores elements:");
        for (int i = 0; i < scores.Length; i++)
        {
           Console.WriteLine(scores[i]);
        }

        // Loop through 'days' using a 'foreach' loop and print: "- day"
        // (Clean read-only walk; cannot reassign the iteration variable)
        Console.WriteLine($"\nDays elements:");
        foreach (string day in days)
        {
           Console.WriteLine(day);
        }

        // Search 'days' for "Tue" using Array.IndexOf() — O(n) linear scan
        // Store the result in 'index' and print it // Expected Output: Index of 'Tue': 2
        Console.WriteLine($"Search 'days' for \"Tue\" index using Array.IndexOf(): {days.IndexOf("tue")}");

    }
}