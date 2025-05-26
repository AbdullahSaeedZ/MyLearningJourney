#include <iostream>
using namespace std;

int main()
{

    float Num;

    cout << "Please enter a number:" << endl;
    cin >> Num;

    float Nto2 = Num * Num;
    float Nto3 = Num * Num * Num;
    float Nto4 = Num * Num * Num * Num;

    cout << Num << " to the power of 2 is: " << Nto2 << endl;
    cout << Num << " to the power of 3 is: " << Nto3 << endl;
    cout << Num << " to the power of 4 is: " << Nto4 << endl;

    return 0;
}
