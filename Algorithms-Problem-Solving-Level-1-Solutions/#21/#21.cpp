#include <iostream>
#include <cmath>
using namespace std;



float ReadInput()
{
    float L;
    cout << "Enter value of L:" << endl;
    cin >> L;
    return L;
}
float CalculateArea(float L)
{
    const float PI = 3.141592653589793238;
    return pow(L, 2) / (4 * PI);
}

void PrintArea(int L)
{
    cout << "Area of Circle is: " << CalculateArea(L) << endl;
}




int main()
{
    PrintArea(ReadInput());

    return 0;
}