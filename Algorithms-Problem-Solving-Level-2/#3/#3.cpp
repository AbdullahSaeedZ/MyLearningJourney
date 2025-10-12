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

bool IsPerfect(int Num)
{
    int Sum = 0;

    for (int Counter = 1; Counter < Num; Counter++)
    {
        if (Num % Counter == 0)
        {
            Sum += Counter;
        }
    }

    return Sum == Num;    // if its true it returns true, if not, it returns false
}

    

void PrintNumberStatus(int Num)
{
    if (IsPerfect(Num))
        cout << Num << " is Perfect." << endl;
    else
        cout << Num << " is Not Perfect." << endl;
}


int main()
{
    PrintNumberStatus(ReadPositiveNumber("Enter a positive number to check if perfect or not:"));

    return 0;
}

