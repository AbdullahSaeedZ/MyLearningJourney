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

int GetFreq(int Num, int Digit)
{
    int Freq = 0, Remainder = 0;

    while (Num > 0)
    {
        Remainder = Num % 10;

        if (Remainder == Digit)
        {
            Freq += 1;
        }

        Num = Num / 10;
    }

    return Freq;
}

void PrintResult(int Num, int Digit)
{
    cout << "Digit " << Digit << " frequency is " << GetFreq(Num, Digit) << " Time(s)." << endl;
}



int main()
{

    int Number = ReadPositiveNumber("Enter a number");
    int Digit = ReadPositiveNumber("Enter a digit to check is frequency");

    PrintResult(Number, Digit);

    return 0;
}

