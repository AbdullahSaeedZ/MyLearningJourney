/*
================================================================================
Hands-On: Working with SortedDictionary<TKey, TValue>
================================================================================

Core Mechanics to Practice:
1. Instantiation & Adding elements (observing automatic key sorting in a BST).
2. Key-based retrieval & updates (dict[key], TryGetValue).
3. Containment checks (ContainsKey, ContainsValue) & tree node removal (Remove).
4. Ordered iteration over KeyValuePair<TKey, TValue>.
5. Key restriction: Unlike SortedList, positional indexing (dict.Keys[0]) is NOT 
   supported because elements live in linked tree nodes, not flat arrays.
================================================================================
*/

using System;
using System.Collections.Generic;

namespace SortedDictionaryPractice;

class Program
{
    static void Main()
    {
        // =====================================================================
        // TASK 1: INSTANTIATION & AUTOMATIC KEY SORTING
        // =====================================================================
        // Declare and initialize a SortedDictionary<int, string> named 'serverNodes'
        SortedDictionary<int, string> serverNodes = new SortedDictionary<int, string>();

        // Insert 4 entries out of key order using .Add():
        //   Key 40 -> "Cache-Server"
        //   Key 10 -> "Auth-Server"
        //   Key 30 -> "Database-Primary"
        //   Key 20 -> "API-Gateway"
        serverNodes.Add(40, "Cache-Server");
        serverNodes.Add(10, "Auth-Server");
        serverNodes.Add(30, "Database-Server");
        serverNodes.Add(20, "API-Server");
        
        // duplicate key will throw
        // serverNodes.Add(20, "API-Server");

        // Attempt to insert a duplicate key (e.g., 20) using .TryAdd() and print the boolean result
        Console.WriteLine($"inserting duplicate key success: {serverNodes.TryAdd(20, "API-Server")}");

        // Iterate over 'serverNodes' using foreach and print each Key and Value
        // (Verify ascending order: 10 -> 20 -> 30 -> 40)
        Console.WriteLine("printing dictionary pairs sorted automatically:");
        foreach (KeyValuePair<int, string> pair in serverNodes)
        {
            Console.WriteLine($"Key: {pair.Key}, value: {pair.Value}");
        }

        // =====================================================================
        // TASK 2: KEY-BASED LOOKUP & VALUE MUTATION
        // =====================================================================
        // Safely look up Key 30 using .TryGetValue() and print its value
        Console.WriteLine($"\n\nsafe key 30 look up: {serverNodes.TryGetValue(30, out string value)}, Value: {value}");

        // Attempt to look up non-existent Key 99 using .TryGetValue() and print a fallback message
        Console.WriteLine($"safe key 999 look up: {serverNodes.TryGetValue(999, out string nonExistent)}, Value: {nonExistent ?? "Not Found"}");

        // Update the value of Key 20 to "API-Gateway-v2" using the key indexer (serverNodes[20] = ...)
        string old = serverNodes[20];
        serverNodes[20] = "API-Gateway-v2";
        Console.WriteLine($"updating key 20 value from {old} to {serverNodes[20]}");

        // =====================================================================
        // TASK 3: CONTAINMENT CHECKS & REMOVAL
        // =====================================================================
        // Check if Key 40 exists using .ContainsKey() (O(log n) tree traversal) and print the result
        if (serverNodes.ContainsKey(40))
            Console.WriteLine($"dictionary has key 40: true, value: {serverNodes[40]}");
        else
            Console.WriteLine("dictionary has key 40: false");            

        // Check if value "Auth-Server" exists using .ContainsValue() (O(n) full tree scan) and print the result
        if (serverNodes.ContainsValue("Auth-Server"))
            Console.WriteLine($"dictionary has value \"Auth-Server\": true");
        else
            Console.WriteLine("dictionary has value \"Auth-Server\": false");  

        // Remove Key 40 using .Remove() (O(log n) pointer update) and print the boolean result
        Console.WriteLine($"removing pair of key 30: {serverNodes.Remove(40)}");

        // Print the current Count and iterate over 'serverNodes' to verify the remaining sorted entries
        Console.WriteLine($"\nCount of sorted dictionary: {serverNodes.Count}");
        foreach (KeyValuePair<int, string> pair in serverNodes)
        {
            Console.WriteLine($"Key: {pair.Key}, value: {pair.Value}");
        }
    }
}