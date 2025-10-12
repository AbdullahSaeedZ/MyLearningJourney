#include <iostream>
using namespace std;



void Swap(int* n1, int* n2)
{
    int temp = 0;
    temp = *n1;
    *n1 = *n2;
    *n2 = temp;
}


int main()
{
    
    int a = 1, b = 2;

    cout << "\nbefore swap: " << endl;
    cout << "a: " << a << endl;
    cout << "b: " << b << endl;

    Swap(&a, &b); // we send the addresses of variables.

    cout << "\nafter swap: " << endl;
    cout << "a: " << a << endl;
    cout << "b: " << b << endl;
    
    
    
    return 0;
}

