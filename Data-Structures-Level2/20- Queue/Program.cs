/*
================================================================================
Queue<T> — FIFO Architecture, Internals & Reference Implementation
================================================================================

1. THE PROBLEM (WHY A NORMAL LIST IS SLOW FOR QUEUES):
- A queue works like a real-life checkout line: **First-In, First-Out (FIFO)**. 
  New people join at the back, and the person at the very front is served first.
- If you used a normal `List<T>` and removed the person at the front (`index 0`), 
  the computer would have to shift every single remaining person one step 
  forward in memory to fill the empty space. If 10,000 items are waiting, 
  removing 1 item forces 9,999 shifts—making it slow (O(n)).


2. CORE IDEA (THE CIRCULAR ARRAY TRICK):
- Instead of shifting items forward when the front item leaves, `Queue<T>` uses 
  a normal array internally (`T[]`) combined with two index trackers (pointers):
  1. `head`: Tracks the index of the **oldest** item (the front of the line).
  2. `tail`: Tracks the index where the **next** item will be added (the back).
- Why it is called a **Circular Array**:
  When `Dequeue()` removes an item, the `head` pointer simply moves one step 
  forward (`head + 1`), leaving an empty slot behind it without shifting 
  anything. When `tail` reaches the physical end of the array, it **wraps 
  around** back to index `0` to reuse those empty slots at the front—treating 
  the straight array like a continuous circle.

Visual Walkthrough (Array of size 4):
  Step 1 — Enqueue 10, 20, 30:
    Index:     [ 0 ]   [ 1 ]   [ 2 ]   [ 3 ]
    Value:     [ 10  |  20   |  30   | empty ]
                 ▲                      ▲
                head                   tail

  Step 2 — Dequeue() removes 10 (`head` moves right; zero shifting!):
    Index:     [ 0 ]   [ 1 ]   [ 2 ]   [ 3 ]
    Value:     [empty|  20   |  30   | empty ]
                        ▲               ▲
                       head            tail

  Step 3 — Enqueue 40 (placed at index 3, `tail` wraps around to index 0!):
    Index:     [ 0 ]   [ 1 ]   [ 2 ]   [ 3 ]
    Value:     [empty|  20   |  30   |  40   ]
                 ▲      ▲
                tail   head

  Step 4 — Enqueue 50 (placed at index 0, `tail` moves right to index 1):
    Index:     [ 0 ]   [ 1 ]   [ 2 ]   [ 3 ]
    Value:     [ 50  |  20   |  30   |  40   ]
                        ▲
                    head & tail (Array is now full!)

  Step 5 — Enqueue 60 (`tail` == `head` and Count == 4 -> triggers 2x Resize!):
    Index:     [ 0 ]   [ 1 ]   [ 2 ]   [ 3 ]   [ 4 ]   [ 5 ]   [ 6 ]   [ 7 ]
    Value:     [ 20  |  30   |  40   |  50   |  60   | empty | empty | empty ]
                 ▲                                      ▲
                head                                   tail


3. HOW IT GROWS WHEN FULL:
- Starts empty (capacity 0) and creates a 4-slot array on the first `Enqueue()`.
- If `tail` catches up to `head` (meaning every slot in the circle is full), 
  `Queue<T>` allocates a new array **2x larger**, copies the items in proper 
  front-to-back order starting at index `0`, and resets `head = 0` and 
  `tail = Count`.
- `foreach` reads items starting from `head` and wraps around to `tail` without 
  removing anything.


4. PERFORMANCE & COMPLEXITY:
- `Enqueue(item)`:    O(1) amortized (O(n) only when the array doubles in size).
- `Dequeue()`:        O(1) — Reads `array[head]`, clears it, and moves `head` forward.
- `Peek()`:           O(1) — Reads `array[head]` without removing it.
- `Contains(item)`:   O(n) — Checks items one by one from `head` to `tail`.
- Index Access `[i]`: NOT SUPPORTED (queues only allow access to the front).


5. WHEN TO USE VS. AVOID:
- USE: Task/job schedulers, request buffering, printer queues, and Breadth-First 
  Search (BFS) algorithms.
- AVOID: When you need Last-In, First-Out order (use `Stack<T>`), priority 
  ordering (use `PriorityQueue<TElement, TPriority>`), or direct index access 
  like `list[2]` (use `List<T>`).
================================================================================
*/

using System;
using System.Collections.Generic;

namespace QueueReference;

class Program
{
    static void Main()
    {
        // 1. Instantiation & Enqueuing at the Back/Tail (FIFO)
        Queue<string> printQueue = new Queue<string>();
        printQueue.Enqueue("Doc 1: Invoice.pdf");    // Front (head)
        printQueue.Enqueue("Doc 2: Resume.pdf");
        printQueue.Enqueue("Doc 3: Contract.pdf");   // Back (tail)

        Console.WriteLine($"Count: {printQueue.Count}"); // Output: 3


        // 2. Peeking at the Front Without Removing (O(1))
        // Note: Peek() and Dequeue() throw InvalidOperationException if the queue is empty
        if (printQueue.TryPeek(out string? nextJob))
        {
            Console.WriteLine($"Next in line (Peek): {nextJob}"); // Doc 1: Invoice.pdf
        }


        // 3. Iterating Front-to-Back (Non-Destructive)
        Console.WriteLine("\nQueue contents (Front -> Back):");
        foreach (string doc in printQueue)
        {
            Console.WriteLine($"- {doc}");
        }


        // 4. Dequeuing from the Front/Head (O(1) — FIFO Removal)
        Console.WriteLine("\nProcessing print jobs:");
        while (printQueue.TryDequeue(out string? processedDoc))
        {
            Console.WriteLine($"Printed: {processedDoc} | Remaining: {printQueue.Count}");
        }
        // Order processed: Doc 1 -> Doc 2 -> Doc 3
    }
}