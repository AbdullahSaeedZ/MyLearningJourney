#include <iostream>
#include <cmath>

using namespace std;

float GetFractionPart(float Number)
{
    // Subtract the integer part of the number from the original number to get the fractional part.
    return Number - int(Number);
}

float ReadNumber(string Message)
{
    float Number = 0;

    cout << Message << endl;
    cin >> Number;


    return Number;
}

int MyRound(float Number)
{
    float FractionsPart = GetFractionPart(Number);

                                     // If the absolute value of the fractional part is 0.5 or more, round the number accordingly.
    if (abs(FractionsPart) >= 0.5)
    {
                                     // If the number is positive, round up.
        if (Number > 0)
            return ++Number;
                                     // If the number is negative, to increase we have to round down.
        else
            return --Number;
    }
    else
    {
                        // If the fractional part is less than 0.5, keep Number as it is in int type (fraction will be deleted).
        return Number;
    }
}

int main()
{

    float Num = ReadNumber("Enter a number to get Rounded value : \n");

    cout << "My Round value:" << MyRound(Num) << endl;

    cout << "C++ Round value:" << round(Num) << endl;
    return 0;
}