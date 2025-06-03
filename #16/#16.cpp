#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    short int A, B;

    cout << "enter A value then B: " << endl;
    cin >> A >> B;

    float Area = A * sqrt(pow(B, 2) - pow(A, 2));  // using sqrt() and pow(base, power) math functions.

    cout << "the rectangle area is: " << Area << endl;




    return 0;
}
