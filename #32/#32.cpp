#include <iostream>
#include <cmath>
using namespace std;

void ReadInputs(float& Num, float& P)
{
    cout << "enter a number: " << endl;
    cin >> Num;
    cout << "Enter a Power number: " << endl;
    cin >> P;

}

float PowerOf(float Number, float Power)
{
    float Counter = Power;
    float Sum = Number;

    for (Counter; Counter != 1; Counter--)
    {
        Sum = Sum * Number;
    }

    return Sum;
}

void ShowResult(float Number, float Power)
{
    cout << "the result is: " << PowerOf(Number, Power) << endl;
}

int main()
{
    
    float Number, Power;
    ReadInputs(Number, Power);
    ShowResult(Number, Power);


    return 0;
}
