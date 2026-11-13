/*
================================================================================
Using LINQ with Non-Generic Collections (.Cast<T>() & .OfType<T>())
================================================================================

1. THE PROBLEM:
- Standard LINQ operators (`.Where()`, `.Select()`, `.OrderBy()`) are extension 
  methods defined strictly on `IEnumerable<T>`.
- Legacy non-generic collections in `System.Collections` (`ArrayList`, `Queue`, 
  `Stack`, `Hashtable`, `BitArray`) and older UI collections (e.g., WinForms 
  `ControlCollection`) only implement non-generic `IEnumerable`—yielding 
  untyped `object` elements.
- Calling `collection.Where(...)` directly fails to compile because the compiler 
  cannot infer `T`.


2. CORE IDEA (BRIDGING `IEnumerable` TO `IEnumerable<T>`):
- `.Cast<T>()` and `.OfType<T>()` are the only two LINQ operators defined 
  directly on non-generic `IEnumerable`.
- They wrap any untyped collection in a deferred, streaming `IEnumerable<T>` 
  pipeline, unboxing/casting elements on the fly so standard LINQ methods can 
  chain onto them.


3. `.Cast<T>()` VS. `.OfType<T>()`:
┌──────────────────┬───────────────────────────────────┬───────────────────────────────────┐
│ Method           │ Behavior on Mismatched Type       │ When to Use                       │
├──────────────────┼───────────────────────────────────┼───────────────────────────────────┤
│ `.Cast<T>()`     │ Throws `InvalidCastException`     │ All elements are guaranteed to be │
│                  │ immediately at runtime.           │ type `T` (fail-fast validation).  │
├──────────────────┼───────────────────────────────────┼───────────────────────────────────┤
│ `.OfType<T>()`   │ Silently skips elements that are  │ Mixed-type collections where you  │
│                  │ not of type `T` (safe filtering). │ only want items of type `T`.      │
└──────────────────┴───────────────────────────────────┴───────────────────────────────────┘


4. WHEN TO AVOID:
- Never introduce non-generic collections in new C# code—they incur heap boxing 
  on insert and runtime unboxing on LINQ enumeration. Prefer `List<T>`, 
  `Queue<T>`, `Stack<T>`, and `Dictionary<TKey, TValue>`.
================================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NonGenericLinqBridge;

class Program
{
    static void Main()
    {
        // Works the same for non-generic Queue, Stack, Hashtable, etc.
        ArrayList arrayList = new ArrayList { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // 1. .Cast<int>() bridges IEnumerable -> IEnumerable<int> (unboxes object -> int)
        // 2. .Where(...) chains onto IEnumerable<int> with compile-time type safety
        IEnumerable<int> evenNumbers = arrayList
            .Cast<int>()
            .Where(num => num % 2 == 0);

        Console.WriteLine("All even numbers:");
        foreach (int num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
}