#include <iostream>
using namespace std;

// check the las problem first


void RecursiveFib(int prev1, int prev2, int length)
{
    int FibNum = 0;

    if (length > 0)
    {
        
        FibNum = prev1 + prev2;
        cout << FibNum << "    ";
        prev2 = prev1;
        prev1 = FibNum;
        

        RecursiveFib( prev1, prev2, length - 1); // the idea here is to control the recursion (loop) by decreasing the length every recursion till reaching 0
    }
}



int main()
{

    RecursiveFib(0, 1, 10);


    return 0;
}

