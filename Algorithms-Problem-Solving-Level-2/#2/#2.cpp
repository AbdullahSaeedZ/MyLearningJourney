#include <iostream>
using namespace std;

enum enPrimeNoPrime { Prime = 1, NotPrime = 2 };

int ReadNumber(string Message)
{
    int Number = 0;

    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number < 0);

    return Number;
}

enPrimeNoPrime CheckNumber(int Number)
{
    float M = round(Number / 2);
    for (int Counter = 2; Counter <= M; Counter++)
    {
        if (Number % Counter == 0)
            return enPrimeNoPrime::NotPrime;

    }

    return enPrimeNoPrime::Prime;
}

void PrintPrimeNumbersFrom1ToN(int Number)
{
    cout << "Prime Numbers from 1 to " << Number << " are:" << endl;

    for (int Counter = 1; Counter <= Number; Counter++)
    {
        if (CheckNumber(Counter) == enPrimeNoPrime::Prime)
        {
            cout << Counter << endl;
        }

    }
}



int main()
{
    PrintPrimeNumbersFrom1ToN(ReadNumber("Enter a number to print its prime numbers:"));

    return 0;
}

