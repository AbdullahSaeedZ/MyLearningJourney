#include <iostream>
using namespace std;

int ReadNumber(string Message)
{
    int Number = 0;
    
        cout << Message << endl;
        cin >> Number;
    

    return Number;
}

float Myabs(int Num)
{
    if (Num < 0)
    {
        return Num * -1;
    }
    
    return Num;
}

int main()
{
    
    int Num = ReadNumber("Enter a number to get absolute value : \n");

    cout << "My abs value:" << Myabs(Num) << endl;

    cout << "C++ abs value:" << abs(Num) << endl;
    return 0;
}

