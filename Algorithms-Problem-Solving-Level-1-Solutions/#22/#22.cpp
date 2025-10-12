#include <iostream>
#include <cmath>
using namespace std;

struct Values {
    float A;
    float B;
};

Values ReadInput()
{

    Values Inputs;
    cout << "Enter value of A:" << endl;
    cin >> Inputs.A;
    cout << "Enter value of B:" << endl;
    cin >> Inputs.B;

    return Inputs;
}
float CalculateArea(Values Inputs)
{
    const float PI = 3.141592653589793238;
    return PI * (pow(Inputs.B, 2)/4) * ((2 * Inputs.A - Inputs.B)/(2 * Inputs.A + Inputs.B));
}

void PrintArea(float CalculateArea)
{
    cout << "Area of Circle is: " << CalculateArea << endl;
}




int main()
{
    PrintArea(CalculateArea(ReadInput()));

    return 0;
}