#include <iostream>
using namespace std;

// Num1 and Num2 between brackets are called parameters 
short int Parameters(int Num1, int Num2)
{
    return Num1 + Num2;
}


int main()
{
    cout << Parameters(1, 2) << endl;

// we can apply the function this way:

    short int Num1, Num2; // the naming here is outside our function above, do i used the same naming Num1 and Num2 but nothing is wrong cuz they are seperate from the function 
    cin >> Num1;
    cin >> Num2;

    cout << "result of addition is: " << Parameters(Num1, Num2) << endl;

    return 0;

}

