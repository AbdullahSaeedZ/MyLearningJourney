void fun1(short n)
{
    short x = n;        // Start: x = n

    while (x > 0)       // Keep going while x is positive
    {
        x = x / 2;      // Cut x in half
        cout << x;      // Print x
    }
}

/*
What is Logarithm (Log)?
Simple answer: "How many times can I divide by 2?"

What does this code do?
- Takes a number n
- Keeps cutting it in half until it becomes 0
- Prints each result
- The number of times we divide = log₂(n)

Let's trace it step by step:

If n = 8:
x = 8
Loop 1: x = 8/2 = 4, print 4
Loop 2: x = 4/2 = 2, print 2
Loop 3: x = 2/2 = 1, print 1
Loop 4: x = 1/2 = 0, print 0
x = 0, so stop!
Total loops = 4, so log₂(8) = 4

If n = 16:
x = 16
Loop 1: x = 16/2 = 8, print 8
Loop 2: x = 8/2 = 4, print 4
Loop 3: x = 4/2 = 2, print 2
Loop 4: x = 2/2 = 1, print 1
Loop 5: x = 1/2 = 0, print 0
x = 0, so stop!
Total loops = 5, so log₂(16) = 5

Quick Log Examples:
- log₂(2) = 1 (divide once: 2→1)
- log₂(4) = 2 (divide twice: 4→2→1)
- log₂(8) = 3 (divide 3 times: 8→4→2→1)
- log₂(16) = 4 (divide 4 times: 16→8→4→2→1)

The Pattern:
- n = 8 → 4 loops → log₂(8) = ~3
- n = 16 → 5 loops → log₂(16) = 4
- n = 32 → 6 loops → log₂(32) = 5

Notice: When we double n, we only get 1 extra loop!
That's why it's O(log n) - very slow growth of time when more input size we put!

This code literally shows you what logarithm means!

O(log n) with increasing input:

Input: 1,000 → Time: ~10 operations
Input: 1,000,000 → Time: ~20 operations
Input: 1,000,000,000 → Time: ~30 operations

See the pattern?

Input increased 1000x → Time only increased 2x!
Input increased 1,000,000x → Time only increased 3x!

Compare with bad algorithms:
O(n²) with increasing input:

Input: 1,000 → Time: 1,000,000 operations
Input: 1,000,000 → Time: 1,000,000,000,000 operations 💀

The difference:

O(log n): Input grows HUGE → Time barely changes! ✅
O(n²): Input grows big → Time EXPLODES! ❌
*/