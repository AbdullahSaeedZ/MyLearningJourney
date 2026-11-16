/*
   ================================================================================
   Jagged Arrays (T[][]) — "Array of Arrays" Architecture, Internals & Trade-offs
   ================================================================================
   
   1. THE PROBLEM (WHY RECTANGULAR `T[,]` ARRAYS WASTE MEMORY ON UNEVEN ROWS):
   - Suppose we want to store 3 rows of numbers with DIFFERENT lengths:
       Row 0: 10, 20, 30       (3 items)
       Row 1: 40, 50, 60, 70   (4 items)
       Row 2: 80               (1 item)
       
   - A rectangular multidimensional array (`int[3, 4]`) forces every row to have 
     the exact same number of columns (4 columns, because Row 1 needs 4).
   - In RAM, C# creates **1 single unbroken block** of 3 × 4 = 12 slots, wasting 
     empty `0` slots in shorter rows:
   
     Rectangular Matrix (`int[3, 4]`) — ONE Rigid Box (4 Wasted Slots):
     Logical Shape (Forced Rectangle):       Actual Heap Memory (1 Single Block):
            Col 0  Col 1  Col 2  Col 3       ┌────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┬────┐
     Row 0 [  10  |  20  |  30  |  0   ]     │ 10 │ 20 │ 30 │ 0  │ 40 │ 50 │ 60 │ 70 │ 80 │ 0  │ 0  │ 0  │
     Row 1 [  40  |  50  |  60  |  70  ]     └────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┴────┘
     Row 2 [  80  |  0   |  0   |  0   ]      ◄───── Row 0 ─────► ◄───── Row 1 ─────► ◄───── Row 2 ─────►
                              ▲                               ▲                             ▲  ▲  ▲
                              └───────────────────────────────┴─────────────────────────────┴──┴──┘
                                                 4 wasted `0` slots just to keep it rectangular!
   
   
   2. CORE IDEA (A JAGGED ARRAY IS A FOLDER HOLDING SEPARATE ARRAYS):
   - A **Jagged Array** (`T[][]` in C#) is literally an **"array of arrays"**.
   - Instead of 1 giant grid, C# creates **4 separate objects** on the Heap:
     1. **1 Master outer array** (`int[3][]`) that holds **pointers (memory addresses)**, NOT numbers.
     2. **3 completely independent inner `int[]` arrays** scattered on the Heap—each 
        sized to fit ONLY its own data (lengths 3, 4, and 1, with zero wasted slots!).
   
     Jagged Array (`int[3][]`) — 1 Pointer Array + 3 Separate Inner Arrays:
     Master Array (`jagged`)                  Separate Inner Arrays (Each has its own length!)
     ┌─────────────────────────┐                         ┌────┬────┬────┐
     │ jagged[0] (Pointer) ────┼─────── new int[3] ─────►│ 10 │ 20 │ 30 │                  (Length = 3, zero waste)
     ├─────────────────────────┤                         └────┴────┴────┘
     │ jagged[1] (Pointer) ────┼─────── new int[4] ┐     ┌────┬────┬────┬────┐
     ├─────────────────────────┤                   └────►│ 40 │ 50 │ 60 │ 70 │             (Length = 4, zero waste)
     │ jagged[2] (Pointer) ────┼─┐                       └────┴────┴────┴────┘
     └─────────────────────────┘ │                       ┌────┐
                                 └────── new int[1] ────►│ 80 │                            (Length = 1, zero waste)
                                                         └────┘
   
   
   3. HOW IT WORKS INTERNALLY (TWO-STEP LOOKUP & ROW INDEPENDENCE):
   - **Two-Step Lookup (`jagged[row][col]`):**
     1. `jagged[row]` reads the memory pointer stored at slot `row` of the outer 
        array to locate that row's inner array object on the Heap.
     2. `[col]` jumps directly to `InnerBaseAddress + (col × sizeof(T))`.
     
   - **Why C# Often Executes `T[][]` Faster Than `T[,]`:**
     * Rectangular `T[,]` requires multiplication math (`row * cols + col`) plus 
       two-axis bounds checks on every access, and the CLR JIT compiler optimizes 
       1D `T[]` bounds-check elimination far more aggressively.
       
     * Because each inner row of `T[][]` is a genuine 1D `T[]` array, you can 
       pass a single row (`jagged[1]`) directly to methods expecting `int[]`, 
       sort one row with `Array.Sort(jagged[1])`, or swap/replace an entire row 
       in **O(1)** simply by swapping its pointer—without touching any other row!
       
   - **Trade-Off (Memory & Cache):**
     * Each inner array carries its own CLR object header (~24 bytes on 64-bit) 
       and sits at a separate heap address, giving slightly weaker cross-row CPU 
       cache locality than a single contiguous `T[,]` block.
   
   
   4. COMPARISON (`Jagged T[][]` vs. `Rectangular T[,]`):
   ┌────────────────────────────┬──────────────────────────┬──────────────────────────┐
   │ Feature / Metric           │ Jagged Array (`T[][]`)   │ Rectangular (`T[,]`)     │
   ├────────────────────────────┼──────────────────────────┼──────────────────────────┤
   │ Memory Layout              │ 1 outer `T[][]` + N      │ 1 single contiguous      │
   │                            │ separate `T[]` objects   │ Row-Major memory block   │
   │ Row Lengths                │ Can vary per row (or be  │ Strictly uniform across  │
   │                            │ `null`)                  │ all rows                 │
   │ Indexing Syntax            │ `arr[row][col]`          │ `arr[row, col]`          │
   │ Swap / Replace Whole Row   │ O(1) (swap reference)    │ O(cols) (copy every cell)│
   │ Pass Single Row as `T[]`   │ Yes (`arr[0]` is `T[]`)  │ No (must copy out first) │
   │ Object Header Overhead     │ 1 header per inner array │ 1 header total           │
   └────────────────────────────┴──────────────────────────┴──────────────────────────┘
   
   
   5. WHEN TO USE VS. AVOID:
   - USE WHEN:
     * Rows have different lengths (uneven tables, adjacency lists for graphs, 
       grouped buckets, or triangular matrices).
     * You need to pass individual rows as standard `T[]` arrays, sort rows 
       independently, or swap/resize single rows in O(1).
   - AVOID WHEN:
     * Your data is a true fixed-size rectangular grid (images, game boards, 
       math matrices) where uniform bounds and single-block allocation are cleaner.
   ================================================================================
   */
   
   using System;

namespace JaggedArrayPractice;

class Program
{
    static void Main()
    {
        // =====================================================================
        // 1. TWO WAYS TO INITIALIZE A JAGGED ARRAY (T[][])
        // =====================================================================
        // Way A: Allocate outer pointer array first, then allocate each inner row separately
        int[][] jagged = new int[3][];
        jagged[0] = new int[] { 10, 20, 30 };       // Row 0 -> Length 3
        jagged[1] = new int[] { 40, 50, 60, 70 };   // Row 1 -> Length 4
        jagged[2] = new int[] { 80 };               // Row 2 -> Length 1

        // Way B: Inline shorthand initialization (same exact heap layout)
        int[][] inlineJagged =
        {
            new int[] { 10, 20, 30 },
            new int[] { 40, 50, 60, 70 },
            new int[] { 80 }
        };


        // =====================================================================
        // 2. O(1) TWO-STEP INDEXING & ROW INDEPENDENCE
        // =====================================================================
        Console.WriteLine($"Outer row count:    {jagged.Length}");     // Output: 3
        Console.WriteLine($"Row 1 column count: {jagged[1].Length}");  // Output: 4
        Console.WriteLine($"Element [1][2]:     {jagged[1][2]}");      // Output: 60

        // Mutate a single cell — O(1)
        jagged[1][2] = 99;

        // Swap two entire rows in O(1) by swapping pointers (no element copying!)
        int[] tempRow = jagged[0];
        jagged[0] = jagged[2];
        jagged[2] = tempRow;


        // =====================================================================
        // 3. YOUR TASK: ITERATE THROUGH `jagged` AND PRINT ALL ROWS & ELEMENTS
        // =====================================================================
        // Expected Output after row swap & mutation:
        //   Row 0: 80
        //   Row 1: 40 50 99 70
        //   Row 2: 10 20 30

        Console.WriteLine("\n");
        for (int row = 0; row < jagged.Length; row++)
        {
          Console.Write($"Row {row}: ");
          for (int col = 0; col < jagged[row].Length; col++)
          {
            Console.Write($"{jagged[row][col], -4}");
          }
          Console.WriteLine();
        }
        


    }
}