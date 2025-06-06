#include <iostream>

using namespace std;


void Procedure()
{
    cout << "this is a procedure" << endl;
}

// define the data type (string or int and so on) then choose what the purpose of the function in the return value
string Function()
{
    return "this is a function and there must be a return valu.";
}

float Function1()
{
    float X = 10.6, Y = 20.7;

    return X * Y;
}

int main()
{
    Procedure();
    cout << Function() << endl;
    cout << Function1() << endl;

    // a function is a variable (user-defined type) so we can do whatever applies on variables.

    float Result = Function1() + 100;
    cout << Result << endl;

    // or apply a function on the function 

    Result = floor(Function1()) +100;
    cout << Result << endl;

    return 0;
}

