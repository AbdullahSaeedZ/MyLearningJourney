using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _42___Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // In C#, arrays are bound (fixed size) — you cannot exceed their limits.
            // If you try to access an index outside the array's range, 
            // the runtime will throw an IndexOutOfRangeException.
            // Note:
            // In C++, this would cause undefined behavior (no error message),
            // but in C#, it throws a runtime exception for safety.

            // Example:
            int[] numbers = { 1, 2, 3 };

            numbers[0] = 1; // valid
            numbers[1] = 2; // valid
            numbers[2] = 3; // valid

            numbers[3] = 4; // ❌ ERROR: IndexOutOfRangeException
                            // because valid indexes are only 0, 1, and 2

            ////////////////////////////////////////////////////////////////////////////////////////////////


            // ===============================
            // C# Array Declaration
            // ===============================

            // Syntax:
            // dataType[] arrayName;

            // Example:
            int[] age;
            // 'int' = data type (can be int, string, char, etc.)
            // 'age' = array name (identifier)
            // ✅ Arrays in C# are reference types — even if they hold value types like int.
            // This means 'age' only holds a reference (memory address) to where the array
            // is stored in the heap, not the actual elements.

            // ===============================
            // Memory Allocation
            // ===============================

            // We must allocate memory to define how many elements it can hold:
            age = new int[5];
            // This creates space for 5 integer elements (size = 5) in the heap.
            // Indexes will be: 0, 1, 2, 3, 4
            // Default values = 0 for all elements (because int is a value type).

            // ===============================
            // Combined Declaration and Allocation
            // ===============================

            int[] Values = new int[5];
            // This is a one-line declaration + memory allocation.

            // ===============================
            // Declaration + Initialization Shortcut
            // ===============================

            int[] arr = { 1, 2, 3 };
            // This syntax declares, allocates, and initializes the array in one line.
            // The compiler automatically determines the array size (3 elements).
            // It’s still a reference type stored in the heap, with 'arr' holding the reference.


            ///////////////////////////////////////////////////////////////////////////////////////////////



            // ===============================
            // C# Two-Dimensional Array
            // ===============================

            // Declaration:
            int[,] v = new int[2, 3];
            // 2 rows, 3 columns → total 6 elements (2 * 3).
            // The comma [,] means it's a 2D array.

            // Initialization during declaration:
            int[,] nums = { { 1, 2, 3 }, { 3, 4, 5 } };
            // First row: {1, 2, 3}
            // Second row: {3, 4, 5}

            // Declaration + explicit size + initialization:
            int[,] matrix = new int[2, 3] { { 1, 2, 3 }, { 3, 4, 5 } };
            // Same result — size defined explicitly (2x3).






        }
    }
}
