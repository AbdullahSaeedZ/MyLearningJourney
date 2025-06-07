#include <iostream>
#include <cmath>
using namespace std;

void ReadValues(float& A, float& B)
{
    cout << "enter A value: " << endl;
    cin >> A ;
    cout << "enter B value: " << endl;
    cin >> B;
}

float Area(float A, float B)  // no need for referencing, cuz i will only apply the function and print the result, i dont want the original variables to be changed.
{
    float Result = A * sqrt(pow(B, 2) - pow(A, 2));  // using sqrt() and pow(base, power) math functions.

    return Result;

}


int main()
{
    float Value1, Value2;

    ReadValues(Value1, Value2);

    cout << "the rectangle area is: " << Area(Value1, Value2) << endl;


    return 0;
}
