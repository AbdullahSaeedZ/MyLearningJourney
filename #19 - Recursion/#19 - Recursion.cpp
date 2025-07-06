#include <iostream>
using namespace std;

// Recursion is a function that calls itself, in another name a recursive call.
// every recursive call is going to a new active frame in a call stack.
// call stack is like a water tank, when the recursion is used with no knowledge, the stack will be overflowed then the program will crash.
// in C++ , the stack limit is kind of big so it might handle the number of stacks, but some languages like python which has small limit of stack will be an issue.
// if the purpose of recurring a function can be made with loops, then just do loops! recursion must be used when you are 100% sure of what will happen.




// here recursion is used till number 1 becomes more than 5 , so there is 5 recursive calls (trace it through debugging mode), that means the stack is filled with 5 calls of this function.
// but when we put a very big number in variable M, then the calls will be too much and the stack will be overflowed and program will fail (try a big number in M).
void PrintNumber(int N, int M)
{
    if (N <= M)
    {
        cout << N << endl;
        PrintNumber(N + 1, M);

    }
}


int main()
{
    
    PrintNumber(1, 4);

    return 0;
}

