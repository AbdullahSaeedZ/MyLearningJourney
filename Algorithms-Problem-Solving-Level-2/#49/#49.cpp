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

int Myceil(float Num)
{

    int IntPart = (int)Num;

    if (IntPart < Num)
        return IntPart + 1;
    else 
        return IntPart;

}

int main()
{

    float Num = ReadNumber("Enter a number to get ceiled value : \n");

    cout << "My ceil value:" << Myceil(Num) << endl;

    cout << "C++ ceil value:" << ceil(Num) << endl;
    return 0;
}