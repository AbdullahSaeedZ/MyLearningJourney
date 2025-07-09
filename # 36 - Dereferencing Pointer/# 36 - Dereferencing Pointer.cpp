#include <iostream>
using namespace std;

// Dereferencing a pointer is to modify the value of that variable the pointer is linked to.

int main()
{
    int a = 10;

    cout << "\nValue of a: " << a << endl;
    cout << "Address of a: " << &a << endl;

    int* P;
    P = &a;

    cout << "\nValue of P: " << P << endl;
    cout << "Value of *P : " << *P << endl;


    // so a pointer will store the address of another value, but to access the value of that another variable, we do it using *P then we can do anything and it will affect the original variable.

    *P = 20;
    cout << "\nValue of *P after changing value: " << *P << endl;
    cout << "Value of a after changing value by using *P: " << a << endl;



    // here also when we modify the value of a, it will also change in *P since *P has access of variable a.
    a = 30;
    cout << "\nValue of *P after changing value from a: " << *P << endl;
    cout << "Value of a: " << a << endl;






    return 0;
}

