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
// in function we shouldnt include reading or printing codes only things that require a return of value
// we use a procedure to include reading and printing codes only.
// the above funcitons are only for the homework eventhouh i wrote a funcion with reading and printing.

int main()
{
    SumProcedure();
    cout << SumFunction() << endl;

    return 0;
}

