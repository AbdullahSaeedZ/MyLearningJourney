#include <iostream>
#include <cmath>
using namespace std;

int main()
{
    short int r;

    cout << "enter r value: " << endl;
    cin >> r;

    float Area = 3.14 * pow(r, 2);

    cout << "circle area is: " << ceil(Area) << endl; // using ceil() to round the result to the highest number 





    return 0;
}

