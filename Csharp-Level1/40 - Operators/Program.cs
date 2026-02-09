using System;

class Program
{
    static void Main()
    {

        int v = 10;
        int n = 3;

        // ==========================
        // ARITHMETIC OPERATORS
        // ==========================
        Console.WriteLine("a + b = " + (v + n)); // Addition -> 13
        Console.WriteLine("a - b = " + (v - n)); // Subtraction -> 7
        Console.WriteLine("a * b = " + (v * n)); // Multiplication -> 30
        Console.WriteLine("a / b = " + (v / n)); // Division -> 3 (integer division)
        Console.WriteLine("a % b = " + (v % n)); // Modulus (remainder) -> 1

        // ==========================
        // RELATIONAL OPERATORS
        // ==========================
        Console.WriteLine("a == b : " + (v == n)); // Equal to -> false
        Console.WriteLine("a != b : " + (v != n)); // Not equal -> true
        Console.WriteLine("a > b  : " + (v > n));  // Greater than -> true
        Console.WriteLine("a < b  : " + (v < n));  // Less than -> false
        Console.WriteLine("a >= b : " + (v >= n)); // Greater or equal -> true
        Console.WriteLine("a <= b : " + (v <= n)); // Less or equal -> false


        /////////////////////////////   3rd type is Logical   //////////////////////////////

        // ============================================
        // 1. LOGICAL OPERATORS
        // ============================================
        bool a = true;
        bool b = false;

        // Logical AND (&&) -> true only if BOTH are true
        Console.WriteLine("a && b = " + (a && b)); // false

        // Logical OR (||) -> true if AT LEAST ONE is true
        Console.WriteLine("a || b = " + (a || b)); // true

        // Logical NOT (!) -> reverses the boolean value
        Console.WriteLine("!a = " + (!a)); // false

        // Logical XOR (^) -> true if ONLY ONE is true
        Console.WriteLine("a ^ b = " + (a ^ b)); // true


        // Single & and | also work with booleans but ALWAYS evaluate both sides
        // (no short-circuiting)
        // - If operands are booleans  → they act as LOGICAL operators (no short-circuit).
        // - If operands are numbers   → they act as BITWISE operators (not logical).

        Console.WriteLine("a & b = " + (a & b)); // false
        Console.WriteLine("a | b = " + (a | b)); // true




        // ============================================
        // 2. SHORT-CIRCUIT vs NON SHORT-CIRCUIT
        // ============================================

        int x = 5;
        int y = 5;

        // && short-circuits: if first condition is false, second one is skipped
        if (x > 10 && ++x > 0)
            Console.WriteLine("Inside && block");
        Console.WriteLine("x = " + x); // 5 (did not increment)

        // & does NOT short-circuit: evaluates both sides even if first is false
        if (y > 10 & ++y > 0)
            Console.WriteLine("Inside & block");
        Console.WriteLine("y = " + y); // 6 (incremented)








        // ============================================
        //  BIT SHIFTING OPERATORS (bitwise, not logical)
        // ============================================

        // Shifting changes the position of bits (0s and 1s) inside the number.
        // Each LEFT shift (<<) multiplies by 2.
        // Each RIGHT shift (>>) divides by 2.

        int n1 = 3;  // binary: 0000 0011
        int n2 = 8;  // binary: 0000 1000

        // LEFT SHIFT (<<)
        int left1 = n1 << 1; // move bits 1 step left: 0000 0110 -> 6
        int left2 = n1 << 2; // move bits 2 steps left: 0000 1100 -> 12

        Console.WriteLine("3 << 1 = " + left1); // 6
        Console.WriteLine("3 << 2 = " + left2); // 12

        // RIGHT SHIFT (>>)
        int right1 = n2 >> 1; // move bits 1 step right: 0000 0100 -> 4
        int right2 = n2 >> 2; // move bits 2 steps right: 0000 0010 -> 2

        Console.WriteLine("8 >> 1 = " + right1); // 4
        Console.WriteLine("8 >> 2 = " + right2); // 2


        // ============================================
        // 4. SHIFT ASSIGNMENT OPERATORS (<<=, >>=)
        // ============================================

        int a1 = 5; // binary: 0000 0101
        a1 <<= 1;   // same as: a1 = a1 << 1; (multiply by 2)
        Console.WriteLine("After <<= 1, a1 = " + a1); // 10

        int a2 = 16; // binary: 0001 0000
        a2 >>= 2;    // same as: a2 = a2 >> 2; (divide by 4)
        Console.WriteLine("After >>= 2, a2 = " + a2); // 4
    }
}

