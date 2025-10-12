#include <iostream>
using namespace std;


int ReadInput()
{
    int N;
    cout << "Enter a number to give the sum of its odd numbers: " << endl;
    cin >> N;
    cout << endl;

    return N;
}

int Counter(int UserInput)
{

    int Sum = 0;

    for (int Odd = 1; Odd <= UserInput; Odd = Odd + 2)
    {
        Sum = Sum + Odd;
    }

    return Sum;
}

void PrintSum(int Counter)
{
    cout << Counter << endl;
}

int main()
{
    int UserInput = ReadInput();
    PrintSum(Counter(UserInput));

    return 0;

}

