#include <iostream>
using namespace std;


int ReadInput()
{
    int Input;
    cout << "Enter a number to calculate its factorail:" << endl;
    cin >> Input;
    cout << endl;

    return Input;
}

int GetFactorial(int Input)
{
    int Sum = Input;
    int Counter = --Input;

    for (Counter; Counter >= 1; Counter--)
    {
        Sum = Sum * Counter;
       
    }

    return Sum;
}




int main()
{
    int UserInput = ReadInput();
    cout << GetFactorial(UserInput) << endl;

    return 0;
}

