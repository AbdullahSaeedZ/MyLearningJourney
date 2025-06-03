#include <iostream>
using namespace std;

int main()
{
  
	float A, B;

	cout << "please enter A then B: " << endl;
	cin >> A;
	cin >> B;

	float Area = 3.141592653589793 * (pow(B, 2) / 4) * ((2 * A - B) / (2 * A + B));

	cout << "the area is: " << floor(Area) << endl;

	return 0;
}

