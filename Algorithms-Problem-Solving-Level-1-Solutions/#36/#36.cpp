#include <iostream>
using namespace std;

enum enOperation {Add = '+', Subtract = '-', multiply = '*', Divide = '/'};

int ReadNumber(string Message)
{
    int Number = 0;
    cout << Message << endl;
    cin >> Number;
    return Number;
}

enOperation ReadOT()
{
    char OT;

    cout << "Please enter an operation type (+ , - , * , /):" << endl;
    cin >> OT;

    return (enOperation)OT;

}

int Calculate(float Number1, float Number2, enOperation OT)
{

    switch (OT)
    {
    case enOperation::Add: return Number1 + Number2;
    case enOperation::Subtract: return Number1 - Number2;
    case enOperation::multiply: return Number1 * Number2;
    case enOperation::Divide: return Number1 / Number2;
    default: return Number1 + Number2;
    }
}


int main()
{
    float Number1 = ReadNumber("Enter Number 1: ");
    float Number2 = ReadNumber("Enter Number 2: ");
    enOperation OT = ReadOT();

    cout << "result is: " << Calculate(Number1, Number2, OT) << endl;

    return 0;   