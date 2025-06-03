#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    
    short int a, b, c;
    cout << " enter vaules of A, B, C:" << endl;
    cin >> a >> b >> c;

    float p = (a + b + c) / 2;
    float Area = 3.14 * pow((a * b * c) / (4 * sqrt(p * (p - a) * (p - b) * (p - c))), 2);

    cout << "area is: " << round(Area) << endl; // using round() function to round to the nearest number.




    return 0;
}

