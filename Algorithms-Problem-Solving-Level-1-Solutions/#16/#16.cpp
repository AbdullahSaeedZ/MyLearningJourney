#include <iostream>
#include <cmath>
using namespace std;


struct AreaParameters {
    int A;
    int B;
};

AreaParameters ReadInput()
{
    AreaParameters Area;
    cout << "Enter value of A:" << endl;
    cin >> Area.A;
    cout << "Enter Value of B:" << endl;
    cin >> Area.B;

    return Area;
}

float CalculateArea(AreaParameters Area)
{
    return Area.A * sqrt(pow(Area.B,2) - pow(Area.A,2));
}

void PrintArea(AreaParameters Area)
{
    cout << "Area of rectangle is: " << CalculateArea(Area) << endl;
}




int main()
{
    PrintArea(ReadInput());

    return 0;
}

