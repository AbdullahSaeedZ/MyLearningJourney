#include <iostream>
using namespace std;

void SumProcedure()
{
    short int Num1, Num2;
    cout << "enter Number1: " << endl;
    cin >> Num1;
    cout << "enter Number2: " << endl;
    cin >> Num2;

    cout << "********" << endl;
    cout << Num1 + Num2 << endl;

}

short int SumFunction()
{
    short int Num1, Num2;
    cout << "enter Number1: " << endl;
    cin >> Num1;
    cout << "enter Number2: " << endl;
    cin >> Num2;
    cout << "********\n";

    return Num1 + Num2;
}


int main()
{
    SumProcedure();
    cout << SumFunction() << endl;

    return 0;
}

