#include <iostream>
using namespace std;

int ReadInput()
{
    int Number;
    cout << "Enter a number to add its odd numbers: " << endl;
    cin >> Number;

    return Number;

}

int SumOdd(int Input)
{
    int Sum = 0;
    int Counter = 1;
    while (Counter <= Input)
    {
        if ((Counter % 2) != 0)
        {
            Sum += Counter;
        }

        Counter++;
    }

    
    return Sum;

}


void Print(int SumOdd)
{
    cout << "Sum of odd numbers is: " << SumOdd << endl;
}

int main()
{
    int Number = ReadInput();

    Print(SumOdd(Number));

    return 0;

}

