#include <iostream>
using namespace std;

enum enPassFail {Fail = 5, Pass = 4};

struct stNumbers {

    int Number1, Number2, Number3;

};

stNumbers ReadNumbers()
{
    stNumbers UserInput;

    cout << "Enter Number 1:" << endl;
    cin >> UserInput.Number1;
    cout << "Enter Number 2:" << endl;
    cin >> UserInput.Number2;
    cout << "Enter Number 3:" << endl;
    cin >> UserInput.Number3;

    return UserInput;
}


int Sum(stNumbers UserInputs)
{
    return UserInputs.Number1 + UserInputs.Number2 + UserInputs.Number3;
}

float Average(stNumbers UserInput)
{
    return (float)Sum(UserInput) / 3;
}

enPassFail IsPassed(float Average)
{

    if (Average >= 50)
        return enPassFail::Pass;
    else
        return enPassFail::Fail;
}


void PrintSum(stNumbers UserInput)
{
    cout << "the Average of numbers entered is: " << Average(UserInput) << endl;
    
    if (IsPassed(Average(UserInput)) == enPassFail::Pass)
        cout << "Pass" << endl;
    else
        cout << "Fail" << endl;
}

int main()
{
    PrintSum(ReadNumbers());

    return 0;
}

