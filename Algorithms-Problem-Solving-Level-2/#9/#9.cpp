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


void AllFreq(int Num)
{
    
    for (short int Counter = 0; Counter < 10; Counter++)
    {
        short int DigitFreq = 0;

        DigitFreq = GetFreq(Num, Counter);   // checks frequency of Counter in the number.

        if (DigitFreq > 0)                   // if counter has freq (repeated more than 0 times), then it will print its info. 
        {
            cout << "Digit " << Counter << " frequency is " << DigitFreq << " Time(s)." << endl;
        }
    }

    
}



int main()
{
    AllFreq(ReadPositiveNumber("Enter a positive number: "));

    return 0;
}

