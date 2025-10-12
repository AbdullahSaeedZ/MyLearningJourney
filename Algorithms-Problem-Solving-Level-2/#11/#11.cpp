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

bool CheckPalindrome(int Num)
{
    return GetReverse(Num) == Num;
}

void PrintResult(int Num)
{
    if (CheckPalindrome(Num))
    {
        cout << "Yes, it is a Palindrome number." << endl;
    }
    else
    {
        cout << "No, it is not a Palindrome number." << endl;
    }
}


int main()
{
    PrintResult(ReadPositiveNumber("Enter a positive number: "));

    return 0;
}

