#include <iostream>
#include <cmath>
using namespace std;

void ReadInputs(float& Num, float& P)
{
    cout << "enter a number and the power: " << endl;
    cin >> Num >> P;
}

float PowerOf(float Number, float Power)
{
    float Result = pow(Number, Power);

    return Result;
}

void ShowResult(float Number, float Power)
{
    cout << "the result is: " << round(PowerOf(Number, Power)) << endl;
}

int main()
{
    
    float Number, Power;
    ReadInputs(Number, Power);
    ShowResult(Number, Power);


    return 0;
}
