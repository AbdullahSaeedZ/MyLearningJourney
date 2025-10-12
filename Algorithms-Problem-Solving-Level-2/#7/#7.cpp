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
    int New = 0, Remainder = 0;

    while (Num > 0)
    {
        Remainder = Num % 10;      //this takes last digit.
        Num = Num / 10;            //this removes last digit.
        New = New * 10 + Remainder;  // * 10 is to move digits from ones to tens then hundreds while adding digits from Remainder variable to result in the end with a reversesed number.

    }
    return New;
}

void PrintReverseNumber(int Num)
{
    cout << "Number reversed is: " << GetReverse(Num) << endl;
    
}


int main()
{
    PrintReverseNumber(ReadPositiveNumber("Enter a number"));

    return 0;
}

