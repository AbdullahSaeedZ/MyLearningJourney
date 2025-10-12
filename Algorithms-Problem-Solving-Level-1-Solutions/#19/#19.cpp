#include <iostream>
#include <cmath>
using namespace std;



float ReadInput()
{
    float Diameter;
    cout << "Enter value of Diameter:" << endl;
    cin >> Diameter;
    return Diameter;
}
float CalculateArea(float Diameter)
{
    const float PI = 3.141592653589793238;
    return (PI * pow(Diameter, 2) / 4);
}

void PrintArea(int Diameter)
{
    cout << "Area of Circle is: " << CalculateArea(Diameter) << endl;
}




int main()
{
    PrintArea(ReadInput());

    return 0;
}

