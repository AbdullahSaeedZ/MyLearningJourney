#include <iostream>
#include <cmath>
using namespace std;



float ReadInput()
{
    float A;
    cout << "Enter value of Diameter:" << endl;
    cin >> A;
    return A;
}
float CalculateArea(float A)
{
    const float PI = 3.141592653589793238;
    return (PI * pow(A, 2)) / 4;
}

void PrintArea(int A)
{
    cout << "Area of Circle is: " << CalculateArea(A) << endl;
}




int main()
{
    PrintArea(ReadInput());

    return 0;
}

