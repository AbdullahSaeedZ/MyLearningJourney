/*
================================================================================
Arrays (T[]) — Contiguous Memory Architecture, Internals & Trade-offs
================================================================================

1. THE PROBLEM (WHY SCATTERED VARIABLES DO NOT SCALE):
- Storing 1,000 related values in separate variables (`score1`, `score2`, ...) 
  makes looping, sorting, or searching impossible without hardcoded logic.
- Furthermore, if elements are scattered randomly in RAM (like a `LinkedList<T>`), 
  the CPU cannot jump directly to the 500th item—it must follow pointers one by 
  one, losing hardware cache speed.


2. CORE IDEA (FIXED-SIZE, CONTIGUOUS BLOCK OF MEMORY):
- An **Array** (`T[]` in C#, inheriting from `System.Array`) is the most 
  fundamental data structure: a **fixed-size** sequence of elements of the 
  **exact same type**, laid out strictly side-by-side in one unbroken block of 
  memory.
- Memory Allocation: In C#, every array is a reference type whose object header 
  and contiguous data block are allocated on the managed **Heap** (while the 
  variable holding the reference lives on the Stack if declared locally).

Visual Layout (`int[] numbers = { 10, 20, 30, 40 }`):

  Stack                        Managed Heap (Contiguous 4-byte `int` slots)
  ┌──────────────┐             ┌──────────┬──────────┬──────────┬──────────┐
  │ numbers ─────┼────────────►│    10    │    20    │    30    │    40    │
  └──────────────┘             └──────────┴──────────┴──────────┴──────────┘
   (Reference)        Address:   0x1000     0x1004     0x1008     0x100C
                      Index:     [ 0 ]      [ 1 ]      [ 2 ]      [ 3 ]


3. HOW IT WORKS INTERNALLY (O(1) ADDRESS MATH & CACHE LOCALITY):
- **Instant O(1) Random Access:** Because every element has the exact same byte 
  size (`sizeof(T)`) and sits side-by-side, reading `numbers[i]` requires zero 
  looping—the CPU calculates the exact RAM address in one math step:
      `Element Address = Base Address + (Index × Element Size)`
      Example for `numbers[2]`: `0x1000 + (2 × 4 bytes) = 0x1008` -> `30`
      
- **CPU Cache Locality:** Because elements are adjacent in RAM, when the CPU 
  fetches `numbers[0]`, it automatically pulls neighboring elements into ultra-fast 
  L1/L2 CPU cache lines, making array loops faster than any pointer-based structure.
  
- **Value Types vs. Reference Types Inside `T[]`:**
  * `int[]` (Value types): The actual `int` values live directly inside the 
    contiguous array slots (zero boxing).
  * `string[]` (Reference types): The contiguous slots hold 8-byte memory 
    addresses pointing to `string` objects elsewhere on the Heap.


4. PERFORMANCE & COMPLEXITY:
- Index Read / Write (`arr[i]`): O(1) — Single memory offset calculation.
- Search Unsorted (`Array.IndexOf`): O(n) — Linear scan from index 0.
- Search Sorted (`Array.BinarySearch`): O(log n) — Halves search space each step.
- Insert / Delete in Middle: NOT SUPPORTED natively (requires creating a new 
  array or manually shifting elements in O(n) time).
- Resize (`Array.Resize`): O(n) — Allocates a brand-new array and copies all 
  elements over; arrays cannot grow in place.


5. WHEN TO USE VS. AVOID:
- USE WHEN:
  * The exact number of items is known upfront and will not change (e.g., 7 days 
    of the week, fixed sensor buffers, image pixel grids, lookup tables).
  * You are building low-level, performance-critical code (arrays are the 
    underlying engine powering `List<T>`, `Stack<T>`, `Queue<T>`, and `Dictionary<TKey, TValue>`).
- AVOID WHEN:
  * You need to frequently add or remove items dynamically—use `List<T>` instead, 
    which manages array resizing automatically for you.
================================================================================
*/