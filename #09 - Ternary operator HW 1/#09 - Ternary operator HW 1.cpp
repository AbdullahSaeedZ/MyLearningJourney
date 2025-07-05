#include <iostream>
#include "C:\Users\asz14\Documents\CPP-Level2\MyLibrary\MyLib.h"
using namespace std;
using namespace MyLib;

void CheckNumber(int Num)
{
    
    (Num >= 0) ? cout << "Number is Positive" : cout << "Number is negative" ;
}

int main()
{
    int Num = 0;

    cout << "Enter a number: " << endl;
    cin >> Num;

    CheckNumber(Num);


    return 0;

}

