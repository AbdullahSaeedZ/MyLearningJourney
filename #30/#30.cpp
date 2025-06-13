#include <iostream>
using namespace std;


int ReadInput()
{
    int Input;
    cout << "Enter a positive number to calculate its factorial:" << endl;
    cin >> Input;
    
    while (Input < 0)
    {
        cout << "You entered a negative number! Enter again: " << endl;
        cin >> Input;
    }

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
    cout << "Result is : " << GetFactorial(UserInput) << endl;
     
    return 0;
}

