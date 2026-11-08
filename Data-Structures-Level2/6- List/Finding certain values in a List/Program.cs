/*
 * ============================================================================
 * LESSON: FINDING VALUES IN A LIST IN C#
 * ============================================================================
 * 
 * 1. SEARCHING BY VALUE VS. SEARCHING BY CONDITION
 * ------------------------------------------------
 * In List<T>, you can search either by an exact literal value or by testing 
 * elements against a conditional predicate (lambda).
 * 
 * 
 * 2. CORE SEARCH METHODS & RETURN TYPES
 * -------------------------------------
 * - Contains(value) -> bool:
 *   * Direct equality lookup (uses EqualityComparer<T>.Default).
 *   * Returns true as soon as an exact match is found; otherwise false.
 * 
 * - Exists(predicate) -> bool:
 *   * Built-in List<T> method. Checks if at least one item satisfies the condition.
 *   * Stops scanning at the first match.
 * 
 * - Any(predicate) -> bool:
 *   * LINQ extension method (System.Linq). 
 *   * Functionally equivalent to Exists, but works across all IEnumerable<T> types.
 * 
 * - Find(predicate) -> T:
 *   * Returns the FIRST element matching the condition.
 *   * If no element matches, returns default(T) (0 for int, null for reference types).
 * 
 * - FindAll(predicate) -> List<T>:
 *   * Scans the entire list and returns a NEW List<T> containing every matching element.
 *   * Similar to LINQ's Where(), but returns an immediate concrete List<T> rather than deferred IEnumerable<T>.
 */

namespace _9__Finding_certain_values_in_a_List;

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 44, 22, -55, 666, 9, -6, 345, 11, 3, 3 };
        
        // Using built-in Contains method:
        // Returns boolean (exact value search)
        Console.WriteLine("List contains value 9:\n" + numbers.Contains(9));
        
        // Using built-in Exists, with a matching predicate:
        // Returns boolean at first match
        Console.WriteLine("List contains a negative number:\n" + numbers.Exists(number => number < 0));
        
        // Using built-in Find, returns the item at first match:
        // Returns the element itself (or default(T) if not found)
        Console.WriteLine("First Negative number in list:\n" + numbers.Find(number => number < 0));
        
        // Using built-in FindAll:
        // Returns a new List<T> containing all matches
        Console.WriteLine("List of negative numbers:\n" + string.Join(", ", numbers.FindAll(number => number < 0)));
        
        // Using LINQ Any method:
        // Returns boolean at first match (available on any IEnumerable)
        Console.WriteLine("List has any number greater than 300? :\n" + numbers.Any(number => number > 300));
        
        // ------------------------------ On Strings ------------------------------
        
        List<string> words = new List<string> { "apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "honeydew" };

        Console.WriteLine("\n\non strings:");
        // Built-in List<T>.Contains method (checks exact string match in collection):
        Console.WriteLine("Words contain banana?:\n" + words.Contains("banana")); 
        
        // Exists: checks condition across elements
        Console.WriteLine("List contains words with over 9 chars?:\n" + words.Exists(word => word.Length > 9));
        
        // Find: retrieves first matching element
        Console.WriteLine("First word that starts with letter a:\n" + words.Find(word => word.StartsWith("a")));
        
        // FindAll: filters and returns a new list of matches
        Console.WriteLine("List of words ending with letter e:\n" + string.Join(", ", words.FindAll(word => word.EndsWith("e"))));
        
        // Any: LINQ check for existence
        Console.WriteLine("List has any word with length of 3? :\n" + words.Any(word => word.Length == 3));
    }
}