#include <iostream>
#include <cmath>
using namespace std;

void ReadInputs(float& A)
{
	cout << "Enter the Area:" << endl;
	cin >> A;
}

float CalculateArea(float A)
{
	float Area = (3.141592653589793 * pow(A, 2)) / 4;
	return Area;
}

int main()
{
  
	float A;
	ReadInputs(A);
	
	cout << " the circle area is: " << ceil(CalculateArea(A)) << endl;

	return 0;
}
