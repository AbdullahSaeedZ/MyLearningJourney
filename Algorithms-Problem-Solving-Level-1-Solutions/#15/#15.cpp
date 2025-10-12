#include <iostream>
using namespace std;


struct AreaParameters {
    int Height;
    int Width;
};

AreaParameters ReadInput()
{
    AreaParameters Area;
    cout << "Enter the Height:" << endl;
    cin >> Area.Height;
    cout << "Enter the Width:" << endl;
    cin >> Area.Width;

    return Area;
}

float CalculateArea(AreaParameters Area)
{
    return Area.Height * Area.Width;
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

