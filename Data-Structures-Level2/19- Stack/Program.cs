/*
================================================================================
Stack<T> — LIFO Architecture, Internals & Reference Implementation
================================================================================

1. THE PROBLEM (WHY `List<T>` IS TOO PERMISSIVE):
- `List<T>` allows unrestricted access anywhere in memory (`list[i]`, `Insert`, 
  `RemoveAt`).
- When an algorithm requires strict **Last-In, First-Out (LIFO)** ordering—like 
  undo/redo history, call stacks, browser back navigation, or bracket parsing—
  exposing random index mutation invites bugs and violates the domain contract.


2. CORE IDEA (STRICT LIFO ACCESS):
`Stack<T>` (`System.Collections.Generic`) is a generic, array-backed collection 
that restricts insertion and removal strictly to one end: the **Top** of the stack.

Visual Layout:
                    ┌───────────┐
   Push(30) ──────► │    30     │ ◄── Top (`_size - 1`) — Pop() / Peek()
                    ├───────────┤
                    │    20     │
                    ├───────────┤
                    │    10     │ ◄── Bottom (`index 0`)
                    └───────────┘


3. HOW IT WORKS INTERNALLY:
- Backing Store: Wraps a single contiguous `T[] _array` and an integer `_size`.
- Dynamic Growth: Starts at capacity 0 (jumps to 4 on first `Push`), doubling 
  its internal array via `Array.Copy` whenever `_size == _array.Length`.
- Zero Element Shifting: Unlike `Queue<T>`, `Stack<T>` only adds/removes at the 
  end (`_array[_size - 1]`), so no circular wrap-around or element shifting is 
  needed. Calling `Pop()` decrements `_size` and clears the slot (`default(T)`) 
  to prevent memory leaks on reference types.
- Iteration Order: `foreach` walks the array **backwards** from `_size - 1` 
  down to `0` (Top to Bottom) without removing elements.


4. PERFORMANCE & COMPLEXITY:
- `Push(item)`:       O(1) amortized (O(n) only when internal array doubles).
- `Pop()`:            O(1) — Reads & clears `_array[--_size]`.
- `Peek()`:           O(1) — Reads `_array[_size - 1]` without removing.
- `Contains(item)`:   O(n) — Linear scan across `_array`.
- `Clear()`:          O(n) for reference types (nulls references for GC); O(1) for unmanaged value types.
- Index Access `[i]`: NOT SUPPORTED (enforces LIFO discipline).


5. WHEN TO USE VS. AVOID:
- USE: Undo/redo stacks, expression/syntax parsing, depth-first search (DFS), 
  and backtracking algorithms.
- AVOID: When you need FIFO (First-In, First-Out) processing (use `Queue<T>`), 
  or random index access `list[i]` (use `List<T>`).
================================================================================
*/

using System;
using System.Collections.Generic;

namespace StackReference;

class Program
{
    static void Main()
    {
        // 1. Instantiation & Pushing onto the Top (LIFO)
        Stack<string> history = new Stack<string>();
        history.Push("Page 1: Home");
        history.Push("Page 2: Products");
        history.Push("Page 3: Checkout"); // Top of stack

        Console.WriteLine($"Count: {history.Count}"); // Output: 3


        // 2. Peeking at the Top Without Removing (O(1))
        // Note: Peek() and Pop() throw InvalidOperationException if stack is empty
        if (history.TryPeek(out string? currentTop))
        {
            Console.WriteLine($"Current Top (Peek): {currentTop}"); // Page 3: Checkout
        }


        // 3. Iterating Top-to-Bottom (Non-Destructive)
        Console.WriteLine("\nStack contents (Top -> Bottom):");
        foreach (string page in history)
        {
            Console.WriteLine($"- {page}");
        }


        // 4. Popping from the Top (O(1) — LIFO Removal)
        Console.WriteLine("\nPopping pages:");
        while (history.TryPop(out string? poppedPage))
        {
            Console.WriteLine($"Popped: {poppedPage} | Remaining: {history.Count}");
        }
        // Order popped: Page 3 -> Page 2 -> Page 1
    }
}