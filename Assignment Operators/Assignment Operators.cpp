#include <iostream>
using namespace std;

int main()
{
    
    short int A = 10, B = 20;

    A += B; // this is a shortcut of A = A + B
    cout << "A = " << A << endl;

    A -= B; // this is a shortcut of A = A - B
    cout << "A = " << A << endl;

    A *= B; // this is a shortcut of A = A * B
    cout << "A = " << A << endl;

    A /= B; // this is a shortcut of A = A / B
    cout << "A = " << A << endl;

    A %= B; // this is a shortcut of A = A % B
    cout << "A = " << A << endl;


    return 0;
}

