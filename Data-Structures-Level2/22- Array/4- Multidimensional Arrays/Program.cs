/*
================================================================================
Multidimensional Arrays (T[,]) — Rectangular Grids, Internals & Reference
================================================================================

1. THE PROBLEM (REPRESENTING TABLES, MATRICES & GRIDS):
- A 1D array (`int[]`) represents a single line of values.
- When modeling 2D data—like a chessboard, spreadsheet, or pixel grid—you need 
  row-and-column coordinates (`grid[row, col]`).


2. CORE IDEA (TRUE RECTANGULAR GRID IN ONE CONTIGUOUS BLOCK):
- A **Multidimensional Array** (`T[,]` for 2D, `T[,,]` for 3D) is a single 
  fixed-size object on the **Heap** where every row has the **exact same number 
  of columns**.
- **How it sits in RAM (Row-Major Order):** Even though you index it like a 2D 
  table, RAM is 1-dimensional—the CLR flattens all rows side-by-side into one 
  unbroken contiguous memory block:

  Visual Layout (`int[,] grid = new int[2, 3]` -> 2 rows, 3 columns):
    Logical View:                  Actual Heap Memory (Contiguous Row-Major):
         Col 0  Col 1  Col 2       ┌────┬────┬────┬────┬────┬────┐
  Row 0 [  10  |  20  |  30  ]     │ 10 │ 20 │ 30 │ 40 │ 50 │ 60 │
  Row 1 [  40  |  50  |  60  ]     └────┴────┴────┴────┴────┴────┘
                                    Row 0 (0..2)   Row 1 (3..5)


3. CORE PROPERTIES & INDEXING (WHAT EACH DOES & ITS BIG-O):
   1- `grid[row, col]` (2D Index Read / Write) — O(1):
      Calculates the flat offset directly: `(row * TotalColumns) + col`.
   2- `grid.Length` (Total Element Count) — O(1):
      Returns the total number of cells across ALL dimensions (`rows * cols`).
   3- `grid.GetLength(dimension)` (Axis Size) — O(1):
      Returns the length of a specific axis (`0` = number of rows, `1` = number 
      of columns). Essential for nested `for` loops.
   4- `grid.Rank` (Dimension Count) — O(1):
      Returns the number of dimensions (`2` for `T[,]`, `3` for `T[,,]`).
================================================================================
*/

using System;

namespace MultidimensionalArrayReference;

class Program
{
    static void Main()
    {
        // 1. Two Ways of Initialization
        // Way A: Size-first (2 rows, 3 columns — all slots default to 0)
        int[,] emptyGrid = new int[2, 3];

        // Way B: Inline literal initialization (compiler infers 2 rows x 3 columns)
        int[,] matrix =
        {
            { 10, 20, 30 }, // Row 0
            { 40, 50, 60 }  // Row 1
        };


        // 2. O(1) Indexing & Dimension Metadata
        Console.WriteLine($"Total cells (Length): {matrix.Length}");       // Output: 6
        Console.WriteLine($"Dimensions (Rank):    {matrix.Rank}");         // Output: 2
        Console.WriteLine($"Rows (GetLength(0)):  {matrix.GetLength(0)}"); // Output: 2
        Console.WriteLine($"Cols (GetLength(1)):  {matrix.GetLength(1)}"); // Output: 3

        matrix[1, 2] = 99; // Mutates Row 1, Col 2 (60 -> 99) in O(1)


        // 3. Iterating All Rows & Columns — O(rows * cols)
        Console.WriteLine("\nMatrix contents:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j], 6}");
            }
            Console.WriteLine();
        }
        
    }
}
