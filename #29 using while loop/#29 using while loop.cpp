#include <iostream>
using namespace std;

void ReadInput(int& Number)
{
    cout << "Enter a number to add sum of its even numbers: " << endl;
    cin >> Number;

}

int SumEven(int Number)
{
    int Counter = 1;
    int Sum = 0;
    
    while (Counter <= Number)
    {
        if ((Counter % 2) == 0)
        {
            Sum += Counter;
        }

        Counter++;
    }

    return Sum;
}

void PrintSum(int SumEven)
{
    cout << "Sum of even numbers is: " << SumEven << endl;
}

int main()
{
    int Number;
    ReadInput(Number);
    PrintSum(SumEven(Number));

    return 0;
}

