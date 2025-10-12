#include <iostream>
using namespace std;


int ReadInput()
{
    int Input;
    cout << "Enter a number to give the sum of its even numbers: " << endl;
    cin >> Input;
    cout << endl;

    return Input;
}

int Counter(int UserInput)
{
    int Sum = 0;

    for (int Counter = 0; Counter <= UserInput; Counter = Counter + 1)
    {

        if ((Counter % 2) == 0)        // the IF is used to check wether the number is even or odd , if even then it is added to Sum, if odd then it will be ignored.
        {                              // if you take a number and divide it by 2 and the result is with zero (the zero) then it is an even number.
            Sum = Sum + Counter;
        }

    }

    return Sum;
}

void PrintSum(int UserInput)
{
    cout << Counter(UserInput) << endl;
}


int main()
{
    int UserInput = ReadInput();
    PrintSum(UserInput);

    return 0;
}

