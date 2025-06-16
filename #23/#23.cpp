#include <iostream>
#include <cmath>
using namespace std;

struct Values {
    float A;
    float B;
    float C;
};

Values ReadInput()
{

    Values Inputs;
    cout << "Enter value of A:" << endl;
    cin >> Inputs.A;
    cout << "Enter value of B:" << endl;
    cin >> Inputs.B;
    cout << "Enter value of C:" << endl;
    cin >> Inputs.C;

    return Inputs;
}
double CalculateArea(Values Inputs)
{
    float P = (Inputs.A + Inputs.B + Inputs.C) / 2;
    const float PI = 3.141592653589793238;


    return PI * pow(((Inputs.A * Inputs.B * Inputs.C) / (4 * sqrt(P * (P - Inputs.A) * (P - Inputs.B) * (P - Inputs.C)))), 2);
}

void PrintArea(double CalculateArea)
{
    cout << "Area of Circle is: " << CalculateArea << endl;
}




int main()
{
    PrintArea(CalculateArea(ReadInput()));

    return 0;
}