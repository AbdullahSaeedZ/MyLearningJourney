// Algorithm 1 - Direct Access
char GetLastCharacter(string S1)
{
    return S1[S1.length() - 1];
}
/*
Explanation: This algorithm directly accesses the last character using indexing.
It calculates the last position (length - 1) and returns that character immediately.

Big O Notation: O(1) - Constant Time
Why O(1)? Because no matter how long the string is (10 characters or 10,000 characters),
it always performs exactly ONE operation - direct access to the last index.
The execution time doesn't change with input size.
*/

// Algorithm 2 - Loop-based Approach
char GetLastCharacter2(string S1)
{
    int n = S1.length() - 1;

    for (int i = 0; i <= n; i++)
    {
        if (i == n)
        {
            return S1[n];
        }
    }
}
/*
Explanation: This algorithm uses a for loop to iterate through the string from
start to end, checking at each position if it reached the last character.

Big O Notation: O(n) - Linear Time
Why O(n)? Because if the string has n characters, the loop will run n times.
For a string of length 5, it loops 5 times. For length 100, it loops 100 times.
The execution time grows proportionally with the input size.
*/