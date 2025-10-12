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

void PrintInverted(int Num)
{
    for (int Counter = Num; Counter >= 1; Counter--)
    {
        for (int Counter2 = Counter; Counter2 > 0; Counter2--)
        {
            cout << Counter;
        }

        cout << endl;
    }
}

int main()
{
    PrintInverted(ReadPositiveNumber("Enter a number to print in inverted pattern:"));

    return 0;
}

