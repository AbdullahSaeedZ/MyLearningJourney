/*
================================================================================
LinkedList<T> — Node-Based Architecture, Internals & Trade-offs
================================================================================

1. THE PROBLEM (WHY CONTIGUOUS ARRAYS STRUGGLE WITH MIDDLE EDITS):
- Collections like `List<T>` store elements side-by-side in a single contiguous 
  block of RAM (`T[]`).
  
- While reading by index (`list[3]`) is instant O(1), inserting or removing an 
  item in the middle or front is expensive O(n) because every subsequent item 
  must physically shift in memory, and full arrays must be copied into larger 
  blocks.


2. CORE IDEA (CHAINED NODES SCATTERED IN HEAP MEMORY):
- Instead of one contiguous block of memory, a **Linked List** stores each item 
  inside its own independent heap object called a **Node**.
  
- Nodes sit anywhere in RAM and stay connected by holding memory references 
  (pointers) to their neighbors.
  
- Note on C# `LinkedList<T>` (`System.Collections.Generic`):
  C# implements a **Doubly Linked List**, meaning every node points both 
  forward (`Next`) and backward (`Previous`), while the list object tracks 
  `First` (Head) and `Last` (Tail).

Visual Layout (Doubly Linked List in Memory):
  LinkedList<int>
     ┌───────────────────┐
     │ First ────────────│───────────┐ 
     │ Last  ────────┐   │           │
     │ Count: 3      │   │           │
     └───────────────┼───┘           │
                     │               │
                     │               ▼
                     │ ┌──────────┬───────┬──────────┐      ┌──────────┬───────┬──────────┐      ┌──────────┬───────┬──────────┐
                     │ │ Previous │ Value │   Next   │ ───► │ Previous │ Value │   Next   │ ───► │ Previous │ Value │   Next   │
                     │ │   null   │  10   │          │ ◄─── │          │  20   │          │ ◄─── │          │  30   │   null   │
                     │ └──────────┴───────┴──────────┘      └──────────┴───────┴──────────┘      └──────────┴───────┴──────────┘
                     │                                                                                          ▲
                     └──────────────────────────────────────────────────────────────────────────────────────────┘
                                                                                                      (`Last` points here)


3. HOW IT WORKS INTERNALLY (O(1) POINTER REWIRING):
- Because nodes are not adjacent in memory, inserting or deleting a node never 
  shifts other elements—it only rewires neighbor pointers:

  Inserting Node [15] between [10] and [20]:
    Before:  [10] <═══════════════> [20]

    Step 1:  Create Node [15], set its Next = [20] and Previous = [10]
    Step 2:  Update [10].Next = [15] and [20].Previous = [15]

    After:   [10] <════> [15] <════> [20]   (Zero elements shifted in RAM!)

- Why Index Access (`list[i]`) Does NOT Exist:
  Nodes are scattered across random heap addresses. To reach the 500th node, 
  the CPU cannot calculate a direct memory offset—it must start at `First` and 
  follow `.Next` references 500 times one by one (O(n) traversal).


4. PERFORMANCE & COMPLEXITY (`List<T>` vs. `LinkedList<T>`):
┌────────────────────────────┬────────────────────┬──────────────────────────────────┐
│ Operation / Metric         │ List<T> (Array)    │ LinkedList<T> (Doubly)           │
├────────────────────────────┼────────────────────┼──────────────────────────────────┤
│ Index Access (`list[i]`)   │ O(1)               │ Not Supported (O(n) walk)        │
│ Add / Remove at Front      │ O(n) (shifts all)  │ O(1) (`AddFirst` / `RemoveFirst`)│
│ Add / Remove at End        │ O(1) amortized     │ O(1) (`AddLast` / `RemoveLast`)  │
│ Insert / Remove in Middle  │ O(n) (shifts items)│ O(1) *if you already hold        │
│                            │                    │ the `LinkedListNode<T>`*         │
│ Search by Value (`Find`)   │ O(n) (fast cache)  │ O(n) (slow pointer chasing)      │
│ Memory Overhead per Item   │ 0 extra bytes      │ ~24–32 extra bytes per node      │
│                            │                    │ (object header + 2 refs)         │
└────────────────────────────┴────────────────────┴──────────────────────────────────┘


5. WHEN TO USE VS. AVOID:
- USE WHEN:
  * You already hold a direct `LinkedListNode<T>` reference and frequently 
    insert/delete/move nodes in the middle in O(1) (e.g., LRU Cache combining 
    `Dictionary<TKey, LinkedListNode<T>>` + `LinkedList<T>`, or playlist/editor 
    cursors).
  * You need guaranteed O(1) insertions/removals at **both** ends (a Deque).
- AVOID WHEN:
  * You only need standard iteration, searching, or index access—`List<T>` is 
    dramatically faster in real-world hardware due to CPU cache locality and 
    avoids per-node garbage collection overhead.
================================================================================
*/