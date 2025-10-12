#include <iostream>
using namespace std;


int main()
{
    
    int a = 1;

    cout << a << endl;
    cout << &a << endl;

    // this is printing the reference (address of the slot in memory where the variable is saved).
    // note that everytime i run the code, the address will change , cuz it is saved in the RAM, but when using by-reference in functions it will be excecuted on the same address genereted that time.


    return 0;
}

