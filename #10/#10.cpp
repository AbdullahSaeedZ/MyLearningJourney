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


int GetReverse(int Num)
{
    short int Remainder = 0;
    int Num2 = 0;

    while (Num > 0)
    {
        Remainder = Num % 10;
        Num = Num / 10;
        Num2 = Num2 * 10 + Remainder;

        
    }

    return Num2;
}

void PrintNum(int Num2)
{
    short int Remainder = 0;

    while (Num2 > 0)
    {
        Remainder = Num2 % 10;
        cout << Remainder << endl;

        Num2 = Num2 / 10;
    }
}

int main()
{
    PrintNum(GetReverse(ReadPositiveNumber("Enter a number: ")));   // we take the number then reverse it in a new variable, then print its digits in reverse order. this way the digits of number entered will print in order.

    return 0;
}

 
