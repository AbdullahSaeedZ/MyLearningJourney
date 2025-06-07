#include <iostream>
#include <cmath>
using namespace std;

void ReadInputs(float& A, float& B, float& C)
{
    cout << " enter vaules of A, B, C:" << endl;
    cin >> A >> B >> C;
}

float CalculateArea(float a, float b, float c)
{
    float p = (a + b + c) / 2;
    float Area = 3.14 * pow((a * b * c) / (4 * sqrt(p * (p - a) * (p - b) * (p - c))), 2);
    
    return Area;
}


int main()
{
    
    float a, b, c;
    ReadInputs(a, b, c);

    cout << "area is: " << round(CalculateArea(a, b, c)) << endl; // using round() function to round to the nearest number.




    return 0;
}

