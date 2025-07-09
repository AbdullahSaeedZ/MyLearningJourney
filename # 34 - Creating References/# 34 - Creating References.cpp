#include <iostream>
using namespace std;


int main()
{
    
    // a was declared and new slot in memory was taken.
    // x will not take a new slot cuz of the &.
    // x here is used to be linked to the same (a) memory slot, and now they act as two names for the same address, any change on either will affect all of them cuz both have same address. 

    int a = 10;
    int& x = a;

    cout << a << endl;
    cout << &a << endl;

    cout << x << endl;
    cout << &x << endl;


    return 0;
}

