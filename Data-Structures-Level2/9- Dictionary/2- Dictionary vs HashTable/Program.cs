/*
================================================================================
  Dictionary vs. Hashtable
================================================================================

1. THE PROBLEM:
Both collections store key-value pairs with O(1) lookups, but choosing the wrong 
one leads to runtime casting crashes, boxing overhead, or concurrency bugs.

2. THE CORE IDEA (Direct Comparison):

   +----------------+-----------------------------+-----------------------------+
   | Feature        | Dictionary<TKey, TValue>    | Hashtable                   |
   +----------------+-----------------------------+-----------------------------+
   | Generics       | Generic (Type-safe)         | Non-Generic (Uses object)   |
   | Performance    | Faster (No boxing/unboxing) | Slower with value types     |
   | Thread Safety  | NOT thread-safe             | Has Synchronized wrapper    |
   | Modern Usage   | Standard for modern .NET    | Legacy codebases only       |
   | Ordering       | Unordered                   | Unordered                   |
   +----------------+-----------------------------+-----------------------------+

3. HOW THREAD SAFETY WORKS (Built-in Synchronization Explained):

   A) The Default Problem (Why Collections Break Across Threads):
      By default, standard collections (like List<T> or Dictionary<K,V>) do NOT 
      protect themselves. If Thread A adds an item (triggering an internal array resize) 
      while Thread B reads from it at the exact same microsecond, memory gets mangled, 
      internal pointers corrupt, and C# throws an InvalidOperationException.

   B) The Solution (Built-in Synchronization Mechanisms):
      To save developers from manually placing `lock` statements around every 
      single line of code, some data structures include built-in guards:

      - "Not Thread-Safe" (Dictionary):
        Has ZERO internal guards. It was designed purely for single-threaded speed. 
        If you share it across threads, you MUST lock it manually or use modern 
        concurrency structures like `ConcurrentDictionary<TKey, TValue>`.

      - "Thread-Safe / Synchronized" (Hashtable):
        Has built-in guards from older .NET versions:
        1. Multi-Reader Architecture: Multiple threads can safely read simultaneously 
           by design, as long as only one thread is writing.
        2. Synchronized Wrapper: Calling `Hashtable.Synchronized()` wraps the entire 
           table in an internal lock so you can call read/write methods safely 
           from multiple threads without writing your own locks.

4. PITFALL:
- Assuming `Hashtable.Synchronized` makes compound actions safe. It only locks 
  single calls (like `.Add()`). A "check-then-act" sequence (e.g., checking if 
  a key exists before adding it) still requires an external `lock` so another 
  thread cannot sneak in between those two steps.
================================================================================
*/

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EqualityLessons;

class Lesson11_DictionaryVsHashtable
{
    static void Main()
    {
        // =====================================================================
        // 1. TYPE SAFETY & PERFORMANCE (Downcasting vs. Unboxing vs. Generics)
        // =====================================================================
        
        // Dictionary: Zero boxing, zero casting (Type-Safe)
        var dict = new Dictionary<string, int> { { "Age", 25 } };
        int ageFromDict = dict["Age"]; // Direct value access

        // Hashtable: Stores everything as System.Object
        var table = new Hashtable
        {
            { 1, "Ahmed" },   // Key: 1 is BOXED (int value -> object on Heap)
            { "Age", 25 }     // Value: 25 is BOXED (int value -> object on Heap)
        };

        // DOWNCASTING: object reference -> string reference (No unboxing, string is a class)
        string nameFromTable = (string)table[1];

        // UNBOXING: object reference on Heap -> int value type on Stack
        int ageFromTable = (int)table["Age"];


        // =====================================================================
        // 2. THREAD SAFETY: Standard vs. Built-in Wrapper vs. Concurrent
        // =====================================================================
        
        // Dictionary: Needs manual locking or ConcurrentDictionary for multi-threading
        ConcurrentDictionary<int, string> modernSafeDict = new ConcurrentDictionary<int, string>();
        modernSafeDict.TryAdd(1, "Ahmed");

        // Hashtable: Provides a built-in wrapper with automatic internal locks
        Hashtable oldTable = new Hashtable();
        Hashtable safeTable = Hashtable.Synchronized(oldTable);
        safeTable.Add("SafeKey", "SafeValue");


        Console.WriteLine($"Dictionary Value      : {ageFromDict}");
        Console.WriteLine($"Hashtable Downcast    : {nameFromTable}");
        Console.WriteLine($"Hashtable Unbox       : {ageFromTable}");
        Console.WriteLine($"Is safeTable guarded  : {safeTable.IsSynchronized}"); // True
        Console.WriteLine($"ConcurrentDict Item   : {modernSafeDict[1]}");
    }
}