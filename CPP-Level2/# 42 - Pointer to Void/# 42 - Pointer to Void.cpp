#include <iostream>
using namespace std;

// when using pointers, we declare it with a certain data type and later can point it to another variable but with the same data type (from int to int and so on).
// but in some advanced cases if we need the same pointer to work with different data types, we can do as the following:


int main()
{
    int x = 10;
    float y = 5.5;

    // now it can store address of any data type:
    void* p = &x;

    // we can show the address stores in p using normal way:
    cout << "address of void p: " << p << endl;

    // but to access values of address stored in a void pointer, we must cast into the proper data type:
    cout << "value of void p after casting to int: " << *(static_cast<int*>(p)) << endl;

    p = &y;  // we point it to the y float variable, the cast it again to print it:
    cout << "value of void p after casting to float: " << *(static_cast<float*>(p)) << endl;


    


    return 0;
}

