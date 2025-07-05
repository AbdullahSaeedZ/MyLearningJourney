#include <iostream>
#include "C:\Users\asz14\Documents\CPP-Level2\MyLibrary\MyLib.h"
using namespace std;
using namespace MyLib;

// using ternary, check if number is zero, positive or negative

void CheckNumber(int Num)
{
    
    (Num > 0) ? cout << "Number is Positive" : (Num < 0) ? cout << "Number is negative" : cout << "Number is zero";
}

int main()
{
    int Num = 0;

    cout << "Enter a number: " << endl;
    cin >> Num;

    CheckNumber(Num);


    return 0;

}

