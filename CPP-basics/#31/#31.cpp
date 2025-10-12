#include <iostream>
#include <cmath>
using namespace std;

void ReadInputs(float& Num)
{
    cout << "Please enter a number:" << endl;
    cin >> Num;
}

void PowerThree(float Num)
{
    cout << "power of 2 = " << round(pow(Num, 2)) << endl;
    cout << "power of 3 = " << round(pow(Num, 3)) << endl;
    cout << "power of 4 = " << round(pow(Num, 4)) << endl;

}



int main()
{
    float Number;
    ReadInputs(Number);
    PowerThree(Number);

    
    return 0;
}

