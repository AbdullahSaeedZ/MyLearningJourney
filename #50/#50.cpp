#include <iostream>
#include <cmath>
using namespace std;

float ReadNumber(string Message)
{
    float Number = 0;

    cout << Message << endl;
    cin >> Number;


    return Number;
}

float Mysqrt(float Num)
{
    
    return pow(Num, 0.5);
    
}

int main()
{

    float Num = ReadNumber("Enter a number to get sqrted value : \n");

    cout << "My sqrt value:" << Mysqrt(Num) << endl;

    cout << "C++ sqrt value:" << sqrt(Num) << endl;
    return 0;
}