/*
================================================================================
Hands-On: Working with BitArray (System.Collections) — Core Operations & Big-O
================================================================================

1. THREE WAYS TO INITIALIZE A `BitArray`:
   1- `new BitArray(length)` (or `new BitArray(length, defaultValue)`):
      Allocates `(length + 31) / 32` integers on the heap, initializing all bits 
      to `false` (or `defaultValue`).
      
   2- `new BitArray(bool[] values)`:
      Packs an existing `bool[]` array 8x tighter into internal 32-bit integers.
      
   3- `new BitArray(byte[] bytes)` (or `int[]`):
      Reads raw bytes directly into bits. **Note (LSB-First Order):** Index `0` 
      is the rightmost (least significant) bit of `bytes[0]`, and index `7` is 
      the leftmost bit.


2. CORE PROPERTIES & METHODS (WHAT EACH DOES & ITS BIG-O):
   1- `bits[i]` (Indexer Read / Write) — O(1):
      Reads or flips the bit at index `i` using `(i / 32)` and `(i % 32)` bit math.
      
   2- `bits.Set(index, value)` / `bits.Get(index)` — O(1):
      Method equivalents of `bits[index] = value` and `bool val = bits[index]`.
      
   3- `bits.SetAll(value)` — O(n / 32):
      Fills every underlying 32-bit `int` with all `1`s (`-1` in two's complement) 
      or all `0`s in bulk—32x faster than looping bit by bit.
      
   4- `bits.Length` / `bits.Count` — O(1):
      Both return the total logical bit count (`Length` is writable to resize; 
      `Count` is read-only from `ICollection`).
================================================================================
*/

using System;
using System.Collections;

namespace BitArrayPractice;

class Program
{
    static string BitArrayToString(BitArray bitArray)
    {
        char[] chars = new char[bitArray.Length];
        for (int i = 0; i < bitArray.Length; i++)
        {
            chars[i] = bitArray[i] ? '1' : '0';
        }
        return new string(chars);
    }

    static void PrintBits(string label, BitArray bits)
    {
        Console.WriteLine($"\n{label}: {BitArrayToString(bits)}");
        for (int i = 0; i < bits.Count; i++)
        {
            bool bitVal = bits[i];
            Console.WriteLine($"Bit at index {i}: {bitVal}");
        }
    }

    static void Main()
    {
        // =====================================================================
        // TASK 1: INITIALIZE BY SIZE (DEFAULT FALSE) — O(n / 32)
        // =====================================================================
        // Create 'bits1' with 10 bits, all initialized to false
        // Call PrintBits("bits1 content", bits1)
        // Expected string: 0000000000
        BitArray bits1 = new BitArray(10);
        PrintBits("bit1", bits1);


        // =====================================================================
        // TASK 2: INITIALIZE FROM bool[] — O(n)
        // =====================================================================
        // Create bool[] initialValues = { true, false, true, true, false }
        // Create 'bits2' from 'initialValues'
        // Call PrintBits("bits2 content", bits2)   (Fixed bug: reads bits2[i], not bits1[i])
        // Expected string: 10110
        bool[] bools = new[] { true, false, true, true, false };
        BitArray bits2 = new BitArray(bools);
        PrintBits("bits2", bits2);


        // =====================================================================
        // TASK 3: INITIALIZE FROM byte[] (LSB-FIRST ORDER) — O(n / 32)
        // =====================================================================
        // Create byte[] byteArray = { 0xAA, 0x55 }
        // Note: 0xAA (10101010 binary) is stored LSB-first -> 01010101
        //       0x55 (01010101 binary) is stored LSB-first -> 10101010
        // Create 'bits3' from 'byteArray' and call PrintBits("bits3 content", bits3)
        // Expected string: 0101010110101010
        byte[] bytes = new byte[] { 0xAA, 0x55 };
        BitArray bits3 = new BitArray(bytes);
        PrintBits("bits3", bits3);



        // =====================================================================
        // TASK 4: BASIC OPERATIONS (.Set, Indexer [], .SetAll, .Length)
        // =====================================================================
        // 1. Create 'bits4' with 8 bits (00000000)
        // 2. Use .Set(2, true) and .Set(5, true) — O(1)
        // 3. Use indexer bits4[7] = true and bits4[3] = false — O(1)
        // 4. Call PrintBits("bits4 content", bits4)
        //    Expected string: 00100101
        BitArray bits4 = new BitArray(8);
        
        bits4.Set(2, true);
        bits4.Set(5, true);
        
        bits4[7] = true;
        bits4[3] = false;
        
        PrintBits("bits4", bits4);

        // 5. Call bits4.SetAll(true) — O(n / 32) bulk fill, then PrintBits(...)
        //    Expected string: 11111111
        bits4.SetAll(true);
        PrintBits("bits4 after setting all", bits4);

        // 6. Read bits4[3] into 'bitValue' and bits4.Length into 'length', then print both
        //    Expected Output: Bit[3]: False | Length: 8
        bool bitValue = bits4[3];
        int length = bits4.Length;
        Console.WriteLine($"\n\nBit[3]: {bitValue} | Length: {length}");


        // =====================================================================
        // TASK 5: ITERATING THROUGH A BITARRAY — O(n)
        // =====================================================================
        // Create 'bits5' with 8 bits, set all to true using .SetAll(true)
        // Write a manual 'for' loop from 0 to bits5.Count printing each index and bool value
        // Expected string: 11111111
        BitArray bits5 = new BitArray(8);
        bits5.SetAll(true);

        Console.WriteLine("\n\nbits5 Values:");
        for (int i = 0; i < bits5.Length; i++)
        {
            Console.WriteLine($"bit[{i}] = {bits5[i]}");
        }


    }
}