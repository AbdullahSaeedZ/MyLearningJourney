/*
================================================================================
Hands-On: Bitwise Operators in BitArray (`And`, `Or`, `Not`, `Xor`)
================================================================================

1. HOW BITWISE METHODS WORK INTERNALLY:
   - Mutates in Place (CRITICAL): Calling `bits1.And(bits2)` overwrites `bits1` 
     directly! To preserve `bits1` for later operations, clone it first using 
     the copy constructor: `new BitArray(bits1)`.
     
   - Length Requirement: For `And`, `Or`, and `Xor`, both `BitArray` instances 
     MUST have the exact same `.Length`, or C# throws `ArgumentException`.
     
   - 32x Hardware Speed: Instead of looping bit-by-bit, each method applies 
     CPU bitwise instructions (`&`, `|`, `~`, `^`) across entire 32-bit `int` 
     chunks at once.


2. CORE BITWISE METHODS (WHAT EACH DOES & ITS BIG-O):
   1- `bits1.And(bits2)` (Bitwise AND `&`) — O(n / 32):
      Returns `1` (`true`) ONLY when **both** bits are `1`; otherwise `0`.
      (Use case: Finding common permissions or set intersection).
      
   2- `bits1.Or(bits2)` (Bitwise OR `|`) — O(n / 32):
      Returns `1` (`true`) when **at least one** bit is `1`; `0` only if both are `0`.
      (Use case: Combining flags or set union).
      
   3- `bits1.Not()` (Bitwise NOT `~`) — O(n / 32):
      Flips every bit (`1` -> `0`, `0` -> `1`). Takes no parameters.
      (Use case: Inverting a mask or toggling all switches).
      
   4- `bits1.Xor(bits2)` (Bitwise Exclusive OR `^`) — O(n / 32):
      Returns `1` (`true`) ONLY when the two bits are **different** (`1` & `0`, 
      or `0` & `1`); returns `0` when both bits are identical (`0` & `0`, or `1` & `1`).
      (Use case: Detecting differences/changes between two bitmasks).

   Truth Table Summary (`bits1` = `1010`, `bits2` = `1110`):
   ┌───────┬───────┬─────┬────┬─────┬──────────┐
   │ bits1 │ bits2 │ AND │ OR │ XOR │ NOT(b1)  │
   ├───────┼───────┼─────┼────┼─────┼──────────┤
   │   1   │   1   │  1  │ 1  │  0  │    0     │
   │   0   │   1   │  0  │ 1  │  1  │    1     │
   │   1   │   1   │  1  │ 1  │  0  │    0     │
   │   0   │   0   │  0  │ 0  │  0  │    1     │
   └───────┴───────┴─────┴────┴─────┴──────────┘
================================================================================
*/

using System;
using System.Collections;

namespace BitArrayBitwisePractice;

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

    static void Main()
    {
        // =====================================================================
        // SETUP: CREATE TWO SOURCE BITARRAYS
        // =====================================================================
        BitArray bits1 = new BitArray(new bool[] { true, false, true, false }); // 1010
        BitArray bits2 = new BitArray(new bool[] { true, true, true, false });  // 1110

        Console.WriteLine("bits1 : " + BitArrayToString(bits1));
        Console.WriteLine("bits2 : " + BitArrayToString(bits2));
        Console.WriteLine("Bitwise Operators:");


        // =====================================================================
        // TASK 1: BITWISE AND (`And`) — O(n / 32)
        // =====================================================================
        // 1. Clone 'bits1' into 'resultAnd' using new BitArray(bits1) so 'bits1' stays intact
        // 2. Call resultAnd.And(bits2)
        // 3. Print bits1, bits2, "------------", and resultAnd
        // Expected Output:
        //   1010
        //   1110
        //   ------------
        //   1010
        BitArray andOperation = new BitArray(bits1);
        andOperation.And(bits2);

        Console.WriteLine("\nAnd Operation:");
        Console.WriteLine(BitArrayToString(bits1));
        Console.WriteLine(BitArrayToString(bits2));
        Console.WriteLine("------------");
        Console.WriteLine(BitArrayToString(andOperation));

        
        // =====================================================================
        // TASK 2: BITWISE OR (`Or`) — O(n / 32)
        // =====================================================================
        // 1. Clone 'bits1' into 'resultOr' using new BitArray(bits1)
        // 2. Call resultOr.Or(bits2)
        // 3. Print bits1, bits2, "------------", and resultOr
        // Expected Output:
        //   1010
        //   1110
        //   ------------
        //   1110
        BitArray orOperation = new BitArray(bits1);
        orOperation.Or(bits2);

        Console.WriteLine("\nOR Operation:");
        Console.WriteLine(BitArrayToString(bits1));
        Console.WriteLine(BitArrayToString(bits2));
        Console.WriteLine("------------");
        Console.WriteLine(BitArrayToString(orOperation));


        // =====================================================================
        // TASK 3: BITWISE NOT (`Not`) — O(n / 32)
        // =====================================================================
        // 1. Clone 'bits1' into 'resultNot' using new BitArray(bits1)
        // 2. Call resultNot.Not()
        // 3. Print bits1, "------------", and resultNot
        // Expected Output:
        //   1010
        //   ------------
        //   0101
        BitArray notOperation = new BitArray(bits1);
        notOperation.Not();

        Console.WriteLine("\nNOT Operation:");
        Console.WriteLine(BitArrayToString(bits1));
        Console.WriteLine("------------");
        Console.WriteLine(BitArrayToString(notOperation));


        // =====================================================================
        // TASK 4: BITWISE XOR (`Xor`) — O(n / 32)
        // =====================================================================
        // 1. Clone 'bits1' into 'resultXor' using new BitArray(bits1)
        // 2. Call resultXor.Xor(bits2)
        // 3. Print bits1, bits2, "------------", and resultXor
        // Expected Output:
        //   1010
        //   1110
        //   ------------
        //   0100
        BitArray xorOperation = new BitArray(bits1);
        xorOperation.Xor(bits2);

        Console.WriteLine("\nXOR Operation:");
        Console.WriteLine(BitArrayToString(bits1));
        Console.WriteLine(BitArrayToString(bits2));
        Console.WriteLine("------------");
        Console.WriteLine(BitArrayToString(xorOperation));
        
        
    }
}