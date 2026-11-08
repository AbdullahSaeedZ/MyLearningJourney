/*
 * ============================================================================
 * LESSON: CONVERTING A LIST TO AN ARRAY AND VICE VERSA
 * ============================================================================
 * 
 * 1. THE PROBLEM: WHY CONVERT BETWEEN THEM?
 * -----------------------------------------
 * - External APIs or legacy libraries often require raw arrays (T[]), while 
 *   your internal logic works better with dynamic List<T>.
 * - Arrays provide strict immutability of size and slight performance edge, 
 *   while Lists provide dynamic resizing, additions, and removals.
 * 
 * 
 * 2. CORE CONVERSION METHODS
 * --------------------------
 * - List<T> to Array: list.ToArray()
 *   * Copies all elements from the List's internal buffer into a brand new T[].
 *   * Time Complexity: O(N) memory allocation and copy.
 * 
 * - Array to List<T>: array.ToList()
 *   * Creates a new List<T> containing copies of the array references/values.
 *   * Time Complexity: O(N) allocation and copy.
 * 
 * - Array to List<T> via Constructor: new List<T>(array)
 *   * Direct constructor initialization; avoids LINQ extension dispatch.
 * 
 * 
 * 3. INDEPENDENCE OF THE COPIES
 * -----------------------------
 * Both conversions create shallow copies:
 * - Adding or removing items in the converted collection never affects the original.
 */

namespace _11__Converting_Between_List_and_Array;

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // 1. Converting List<T> to Array (T[])
        // ----------------------------------------------------
        List<string> languagesList = new List<string> { "C#", "C++", "SQL", "Rust" };

        // Built-in ToArray() creates a new array of the exact size:
        string[] languagesArray = languagesList.ToArray();

        Console.WriteLine("Converted to Array:");
        Console.WriteLine(string.Join(", ", languagesArray));
        Console.WriteLine($"Array Type: {languagesArray.GetType().Name}, Length: {languagesArray.Length}");

        
        
        // 2. Converting Array (T[]) to List<T>
        // ----------------------------------------------------
        int[] scoreArray = new int[] { 95, 88, 72, 100 };

        // Method A: Using LINQ ToList() extension method
        List<int> scoreListA = scoreArray.ToList();

        // Method B: Using List<T> constructor directly (avoids LINQ)
        List<int> scoreListB = new List<int>(scoreArray);

        Console.WriteLine("\nConverted to List (via ToList):");
        Console.WriteLine(string.Join(", ", scoreListA));

        
        
        // 3. Demonstrating Copy Independence
        // ----------------------------------------------------
        // Modifying the list does NOT modify the original array:
        scoreListA.Add(50);

        Console.WriteLine("\nAfter adding 50 to scoreListA:");
        Console.WriteLine("Original Array Length : " + scoreArray.Length); // Still 4
        Console.WriteLine("New List Count        : " + scoreListA.Count);    // Now 5
    }
}