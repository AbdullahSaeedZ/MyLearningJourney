#include <iostream>
#include <cmath>
using namespace std;



float ReadInput()
{
    float Radius;
    cout << "Enter value of Diameter:" << endl;
    cin >> Radius;
    return Radius;
}
float CalculateArea(float Radius)
{
    const float PI = 3.141592653589793238;
    return PI * pow(Radius, 2);
}

void PrintArea(int Radius)
{
    cout << "Area of Circle is: " << CalculateArea(Radius) << endl;
}




int main()
{
    PrintArea(ReadInput());

    return 0;
}

