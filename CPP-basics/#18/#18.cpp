#include <iostream>
#include <cmath>
using namespace std;

void ReadInputs(float &R)
{
    cout << "enter r value: " << endl;
    cin >> R;
}

float CirclArea(float R)
{
    float Area = 3.14 * pow(R, 2);

    return Area;
}

int main()
{
    float R;
    ReadInputs(R);

    cout << "circle area is: " << ceil(CirclArea(R)) << endl; // using ceil() to round the result to the highest number 


    return 0;
}

