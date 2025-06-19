#include <iostream>
using namespace std;

enum enPrimeNoPrime {Prime = 1, NotPrime = 2};

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

void PrintNumberType(int Number)
{
    switch (CheckNumber(Number))
    {
    case enPrimeNoPrime::Prime: cout << "Number is Prime" << endl; break;
    case enPrimeNoPrime::NotPrime: cout << "Number is not Prime" << endl; break;
    }
}

int main()
{
    PrintNumberType(ReadNumber("Enter a Positive Number:"));

    return 0;
}
