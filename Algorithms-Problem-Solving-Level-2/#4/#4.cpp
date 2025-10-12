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

bool IsPerfect(int Num)
{
    int Sum = 0;

    for (int Counter = 1; Counter < Num; Counter++)
    {
        if (Num % Counter == 0)
        {
            Sum += Counter;
        }
    }

    return Sum == Num;    // if its true it returns true, if not, it returns false
}

void PrintPerfectNumbers(int Num)
{
    cout << "Perfect numbers from 1 to " << Num << " are:" << endl;

    for (int Counter = 1; Counter <= Num; Counter++)
    {
        if (IsPerfect(Counter))
        {
            cout << Counter << endl;
        }

    }

}

int main()
{
    PrintPerfectNumbers(ReadPositiveNumber("Enter a positive number to print all of its perfect numbers:"));

    return 0;
}

