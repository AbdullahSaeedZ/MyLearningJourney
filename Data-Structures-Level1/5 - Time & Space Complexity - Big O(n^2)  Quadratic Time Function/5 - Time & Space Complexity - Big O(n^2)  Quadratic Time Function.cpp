int MultiplicationSum(short n)
{
    int Sum = 0;                    // Step 1: Initialize sum

    for (int i = 1; i <= n; i++)    // Outer loop: runs n times
    {
        for (int j = 1; j <= n; j++) // Inner loop: runs n times for each i
        {
            Sum = Sum + (i * j);     // Step 2: Calculate and add product
        }
    }

    return Sum;                     // Step 3: Return result
}

/*
Time Complexity Analysis:

Operations outside loops = 4 steps:
1. int Sum = 0 → O(1)
2. int i = 1 → O(1)
3. return Sum → O(1)
4. function setup → O(1)
Total = O(4) = O(1)

Operations inside inner loop = 5 steps per iteration:
1. j <= n → O(1) (check inner loop condition)
2. i * j → O(1) (multiplication)
3. Sum + (i * j) → O(1) (addition)
4. Sum = → O(1) (assignment)
5. j++ → O(1) (increment j)

Inner loop analysis:
- Inner loop runs n times for each value of i
- Operations per inner loop = 5 × n = O(5n) = O(n)

Outer loop analysis:
- Outer loop runs n times
- Each iteration contains: inner loop O(n) + outer loop management O(1)
- Operations per outer loop = O(n) + O(1) = O(n)

Total calculation:
- Outer loop runs n times
- Each iteration takes O(n) time
- Total = n × O(n) = O(n²)

Final Big O:
Big O = Operations outside + Operations inside nested loops
Big O = O(1) + O(n²) = O(n²)

Why O(4 + 5n²) becomes O(n²)?
- Remove constants: 5n² → n²
- Remove smaller terms: +4 is ignored (since n² grows much faster)
- Final result: O(n²)

Practical Example:
- n = 5: 5² = 25 inner loop iterations + 4 operations = ~129 operations
- n = 10: 10² = 100 inner loop iterations + 4 operations = ~504 operations
- n = 100: 100² = 10,000 inner loop iterations + 4 operations = ~50,004 operations

Pattern: When input doubles, operations quadruple → O(n²)

Nested Loop Rule:
- One loop = O(n)
- Two nested loops = O(n²)
- Three nested loops = O(n³)
*/