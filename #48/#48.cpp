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

int MyFloor(float Num)
{

    int IntPart = (int)Num;
    if (Num >= 0 || Num == IntPart)
        return IntPart;
    else
        return IntPart - 1;
   
}

int main()
{

    float Num = ReadNumber("Enter a number to get floored value : \n");

    cout << "My floor value:" << MyFloor(Num) << endl;

    cout << "C++ floor value:" << floor(Num) << endl;
    return 0;
}