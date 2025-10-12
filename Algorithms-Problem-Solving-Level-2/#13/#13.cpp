#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);

    return Number;
}

void PrintPattern(int Num)
{

    for (int Counter = 1; Counter <= Num; Counter++)
    {
        for (int Counter2 = 1;Counter2 <= Counter; Counter2++)
        {
            cout << Counter;
        }

        cout << endl;
    }
}

int main()
{
    PrintPattern(ReadPositiveNumber("Enter a number to print in inverted pattern:"));

    return 0;
}

