/*
 * ============================================================================
 * LESSON: WORKING WITH LISTS IN C#
 * ============================================================================
 * 
 * 1. OVERVIEW
 * -----------
 * Now that we understand the concept behind List<T>, this lesson covers the 
 * basics of creating a list, populating it with data, checking its size, 
 * and accessing elements.
 * 
 * 
 * 2. POPULATING & COUNTING
 * ------------------------
 * - Adding Items: The Add() method appends elements to the end of the list.
 * - Element Count: The Count property gives the exact number of elements 
 *   currently present.
 * 
 * 
 * 3. ACCESSING ELEMENTS (INDEXER VS. LINQ ElementAt)
 * --------------------------------------------------
 * In C#, you have two common ways to read an item by position:
 * 
 * a) The Direct Indexer [i]:
 *    - Uses standard array-like syntax (numbers[0]).
 *    - Always runs in constant time O(1).
 *    - The preferred, idiomatic C# approach for collections backed by arrays.
 * 
 * b) LINQ ElementAt(i):
 *    - An extension method from System.Linq.
 *    - For general IEnumerable<T> collections, ElementAt must iterate item by 
 *      item (O(N) time).
 *    - However, LINQ optimizes internally: if the collection implements 
 *      IList<T> (like List<T> does), it bypasses iteration and uses the 
 *      direct indexer [i] under the hood, running in O(1) time.
 */

namespace _2__Working_with_List;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // 1. Instantiating a new empty List of integers
        List<int> numbers = new List<int>();
        
        // 2. Appending elements to the end of the list sequentially
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
        numbers.Add(4);

        // 3. Inspecting the current number of elements
        Console.WriteLine($"Numbers of items in the list: {numbers.Count}");
        Console.WriteLine($"List capacity: {numbers.Capacity}");

        // 4. Direct index access via the indexer operator [] (O(1) constant time)
        Console.WriteLine($"\nAccessing items by index directly:");
        Console.WriteLine("numbers[0] :" + numbers[0]);
        Console.WriteLine("numbers[1] :" + numbers[1]);
        Console.WriteLine("numbers[2] :" + numbers[2]);
        Console.WriteLine("numbers[3] :" + numbers[3]);

        // 5. Accessing items using the LINQ ElementAt() extension method.
        // Because List<T> implements IList<T>, ElementAt() internally casts
        // and uses the indexer directly, running in O(1) time.
        Console.WriteLine($"\nAccessing items using LINQ ElementAt method:");
        Console.WriteLine("numbers.ElementAt(0) :" + numbers.ElementAt(0));
        Console.WriteLine("numbers.ElementAt(1) :" + numbers.ElementAt(1));
        Console.WriteLine("numbers.ElementAt(2) :" + numbers.ElementAt(2));
        Console.WriteLine("numbers.ElementAt(3) :" + numbers.ElementAt(3));
        
        numbers.Add(5);
        // list capacity
        Console.WriteLine($"\nList capacity after resizing: {numbers.Capacity}");
        
        // changing value of item 1
        numbers[0] = 500;
        Console.WriteLine($"\nChanging value of item 1 to 500: {numbers[0]}");
        
    }
}