char GetLastCharacter2(string S1)
{
    int n = S1.length() - 1;    // Step 1: Calculate last index

    for (int i = 0; i <= n; i++) // Step 2: Start loop
    {
        if (i == n)              // Step 3: Check condition
        {
            return S1[n];       // Step 4: Return result
        }
    }
}

/*
Time Complexity Analysis:

Operations outside loop = 4 steps:
1. S1.length() → O(1)
2. -1 → O(1)
3. int n = → O(1)
4. int i = 0 → O(1)
Total = O(4) = O(1)      not related to input size

Operations inside loop = 6 steps per iteration:
1. i <= n → O(1) (check loop condition)
2. i == n → O(1) (check if condition)
3. i++ → O(1) (increment variable)
4. S1[n] → O(1) (access index)
5. return → O(1) (return value)
6. loop management → O(1)

The loop runs n times (where n = string length)
So: Operations inside loop = 6 × n = O(6n) = O(n)      related to input size

Final Calculation:
Big O = Operations outside loop + Operations inside loop
Big O = O(1) + O(n) = O(n)

Why does O(6n + 4) become O(n)?
- Remove constants: 6n → n
- Remove smaller terms: +4 is ignored
- Final result: O(n)

Practical Example:
- String of 5 chars: 5 iterations + 4 operations = 34 operations
- String of 100 chars: 100 iterations + 4 operations = 604 operations
- String of 1000 chars: 1000 iterations + 4 operations = 6004 operations

Pattern: As string length increases, operations increase linearly → O(n)
*/