#include <iostream>
#include <cmath>
using namespace std;

void ReadInputs(float& D)
{
    cout << "please enter the diameter:" << endl;
    cin >> D;

}

float CalculateArea(float D)
{
    float Area = (3.141592653589793 * pow(D, 2)) / 4;

    return Area;
}


int main()
{

    float D;
    ReadInputs(D);

    cout << "the Area of the circle is: " << ceil(CalculateArea(D)) << endl;


    return 0;
}
