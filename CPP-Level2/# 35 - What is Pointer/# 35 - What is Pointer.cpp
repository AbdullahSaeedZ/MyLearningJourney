#include <iostream>

using namespace std;


int main()
{
    // Pointers are variables type (container) that stores ADDRESSES of other variables, the pointer will be saved in a new slot and address in the memory.
    // so a pointer with special address, will save or contain an address of another variable. 

    int a = 10;

    cout << "Value of a: " << a << endl;
    cout << "Address of a: " << & a << endl;

    // this is a pointer variable of int data type, which stores the address of variable (a) .  
    
    int* P = &a;
    
    // here will print value of P which is the address of (a), it wont print address of p.

    cout << "Value of P: " << P << endl;


    cout << "Address of pointer p: " << & P << endl;

    return 0;
}

