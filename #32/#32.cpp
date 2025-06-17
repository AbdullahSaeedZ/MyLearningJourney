#include <iostream>
using namespace std;

struct stPowers {
    int Number;
    int Power;
};

stPowers ReadNumber()
{
    stPowers Number_Power;

    
    cout << "Enter a number: " << endl;
    cin >> Number_Power.Number;

    cout << "Enter a power:" << endl;
    cin >> Number_Power.Power;

    return Number_Power;
}

float Power(stPowers Number_Power)
{
    float Result = 1;
    for (int Counter = 1; Counter <= Number_Power.Power; Counter++)
    {
       Result = Result * Number_Power.Number;
    }
    return Result;
}

void PrintResult(stPowers Number_Power)
{
    
    cout << Number_Power.Number << " to the power of " << Number_Power.Power << " is :" << Power(Number_Power);
}


int main()
{
    PrintResult(ReadNumber());

    return 0;
}

