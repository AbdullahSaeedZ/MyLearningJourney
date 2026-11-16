/*
================================================================================
Hands-On: LINQ with Jagged Arrays (`T[][]`) — Flattening & Row Filtering
================================================================================

1. WHY JAGGED ARRAYS WORK SEAMLESSLY WITH LINQ (UNLIKE `T[,]`):
   - A rectangular array (`int[,]`) does NOT implement `IEnumerable<T>`, so LINQ 
     operators cannot run directly on it without `.Cast<int>()`.
     
   - A jagged array (`int[][]`) IS a 1D array whose elements are `int[]` arrays—
     so it implements `IEnumerable<int[]>` natively! Every outer element in a 
     LINQ query represents one inner row (`subArray`).


2. CORE OPERATORS IN THIS LESSON (WHAT EACH DOES & ITS BIG-O):
   1- `.SelectMany(subArray => subArray)` (Flatten 2D -> 1D Stream) — O(N):
      Walks through every outer row and yields each inner element one by one 
      as a single flat `IEnumerable<int>` stream (`1, 2, 3, 4, 5, 6, 7, 8, 9, 10`), 
      where `N` is the total number of elements across all rows.

      Visualizing `.SelectMany`:
      [ [1, 2, 3], [4, 5, 6], [7, 8, 9, 10] ]  ──►  1, 2, 3, 4, 5, 6, 7, 8, 9, 10

   2- `.Sum()` / `.Max()` (Aggregate Operators) — O(N):
      Consumes the flattened stream in a single linear pass to compute the 
      arithmetic total or highest value.
      
   3- `.Where(subArray => ...)` (Row-Level Filter) — O(R):
      Filters the outer array of `R` rows based on a condition on each row 
      (e.g., `subArray.Length > 3`), skipping rows that do not match.
      
   4- `.Select(subArray => subArray.First())` (Row Projection) — O(1) per matched row:
      Transforms each surviving inner `int[]` array into its first element (`subArray[0]`).
================================================================================
*/

using System;
using System.Linq;

namespace LinqWithJaggedArraysPractice;

class Program
{
    static void Main()
    {
        // =====================================================================
        // SETUP: INITIALIZE JAGGED ARRAY
        // =====================================================================
        int[][] jaggedArray =
        {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9, 10 }
        };


        // =====================================================================
        // TASK 1: FLATTEN & SUM ALL ELEMENTS — O(N)
        // =====================================================================
        // Flatten 'jaggedArray' into a single 1D stream using .SelectMany(...)
        // Chain .Sum() to calculate the total across all rows, store in 'totalSum', and print it
        // Expected Output: Total Sum: 55
        int totalSum = jaggedArray.SelectMany(subArray => subArray).Sum();
        Console.WriteLine($"Total Sum: {totalSum}");


        // =====================================================================
        // TASK 2: FIND THE MAXIMUM ELEMENT ACROSS ALL ROWS — O(N)
        // =====================================================================
        // Flatten 'jaggedArray' using .SelectMany(...) and chain .Max()
        // Store the result in 'maxElement' and print it
        // Expected Output: Maximum Element: 10
        int maxElement = jaggedArray.SelectMany(subArray => subArray).Max();
        Console.WriteLine($"Maximum Element: {maxElement}");


        // =====================================================================
        // TASK 3: FILTER LONG ROWS & PROJECT THEIR FIRST ELEMENT — O(R)
        // =====================================================================
        // Goal: Find every inner row in 'jaggedArray' that has more than 3 elements,
        //       grab only the first number from each of those matching rows,
        //       and print them separated by spaces.
        // Expected Output: First Elements of Long Rows: 7
        
        /*
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9, 10 } 
         */

        IEnumerable<int> firsts = jaggedArray
            .Where(sub => sub.Length > 3)
            .Select(sub => sub.First());

        Console.WriteLine("\nFirst Elements of Long Rows:");
        foreach (int i in firsts)
        {
            Console.WriteLine($"{i, -2}");
        }



    }
}