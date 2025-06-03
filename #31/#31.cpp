#include <iostream>
using namespace std;

int main()
{

    float Num;

    cout << "Please enter a number:" << endl;
    cin >> Num;

    float Nto2 = pow(Num, 2);
    float Nto3 = pow(Num, 3);
    float Nto4 = pow(Num, 4);

    cout << Num << " to the power of 2 is: " << Nto2 << endl;
    cout << Num << " to the power of 3 is: " << Nto3 << endl;
    cout << Num << " to the power of 4 is: " << Nto4 << endl;

    return 0;
}
