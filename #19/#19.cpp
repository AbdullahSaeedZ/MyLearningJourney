#include <iostream>
using namespace std;

int main()
{

    float D;

    cout << "please enter the diameter:" << endl;
    cin >> D;

    float Area = (3.141592653589793 * pow(D, 2)) / 4;

    cout << "the Area of the circle is: " << ceil(Area) << endl;



    return 0;
}
