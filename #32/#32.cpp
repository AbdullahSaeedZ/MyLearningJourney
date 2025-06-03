#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    
    short int Number, Power;
    cout << "enter a number and the power: " << endl;
    cin >> Number >> Power;

    float Result = pow(Number, Power);
    cout << "the result is: " << round(Result) << endl;



    return 0;
}
