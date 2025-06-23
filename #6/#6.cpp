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

int DigitsSum(int Num)
{
    int Sum = 0;
    int Remainder = 0;

    while (Num > 0)
    {
        Remainder = Num % 10;
        Num = Num / 10;
        Sum += Remainder;
    }

    return Sum;
}

void PrintSum(int Num)
{
    cout << "The sum of digits : " << DigitsSum(Num) << endl;
}

int main()
{
    PrintSum(ReadPositiveNumber("Enter a positive number: "));

    return 0;
}

