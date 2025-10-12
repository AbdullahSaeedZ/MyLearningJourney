#include <iostream>
using namespace std;





int ReadNumber()
{
    int Number = 0;

    cout << "Enter a number: " << endl;
    cin >> Number;

    return Number;
}

int ReadPower()
{
    int Power = 0;
    cout << "Enter a power:" << endl;
    cin >> Power;

    return Power;
}



float Power(int Number, int Power)
{
    if (Power == 0)
    {
        // a rule in Math, if a power is 0 then result is 1.

        return 1; // the return in functions will exit the function and skip the remaining code inside its body.
    }

    float Result = 1;
    for (int Counter = 1; Counter <= Power; Counter++)
    {
        Result = Result * Number;
    }
    return Result;
}

void PrintResult(float Power)
{

    cout << "Result is: " << Power << endl;
}


int main()
{
	PrintResult(Power(ReadNumber(), ReadPower()));  /*if we use two functions inside a function like Power() in our case, the call stack will start from right to left,
													so first ReadPower will be called then ReadNumber, but result will be correct. it is a compiler thing. */

    return 0;
}

