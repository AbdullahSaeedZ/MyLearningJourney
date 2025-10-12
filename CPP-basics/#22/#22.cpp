#include <iostream>
using namespace std;

void ReadInputs(float& A, float& B)
{
	cout << "please enter A then B: " << endl;
	cin >> A;
	cin >> B;
}

float CalculateArea(float A, float B)
{
	float Area = 3.141592653589793 * (pow(B, 2) / 4) * ((2 * A - B) / (2 * A + B));
	return Area;
}

int main()
{
  
	float A, B;
	ReadInputs(A, B);

	cout << "the area is: " << floor(CalculateArea(A, B)) << endl;

	return 0;
}

