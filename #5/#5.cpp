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

void PrintDigits(int Num)
{
    int Remainder = 0;

    while (Num > 0)
    {
        Remainder = Num % 10;     //this will take the last digit and save it in this variable.
        cout << Remainder << endl;

        Num = Num / 10;          // this will delete the last digit and prepare the new value for the next process.
    }


}


int main()
{
    PrintDigits(ReadPositiveNumber("Enter a positive number to print it reversly:"));

    return 0;
}