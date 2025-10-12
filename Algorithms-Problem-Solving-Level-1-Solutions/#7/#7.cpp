#include <iostream>
using  namespace std;

int ReadNumber()
{
    int Number;
    cout << "Enter a number: " << endl;
    cin >> Number;

    return Number;

}

float GetHalfNumber(int Number)
{
    return (float)Number / 2;
}

void PrintHalfNumber(int Number)
{
    cout << "Half of " << Number << " is: " << GetHalfNumber(Number) << endl;
}



int main()
{
    PrintHalfNumber(ReadNumber());

    return 0;
}

