#include <iostream>
using namespace std;

void ReadInputs(float& A)
{
	cout << "Enter L to calculate circle area along the circumference" << endl;
	cin >> A;
}

float CalculateArea(float A)
{
	float Area = pow(A, 2) / (4 * 3.141592653589793);
	return Area;

}

int main()
{
   
	float L;
	ReadInputs(L);

	cout << " Area is: " << floor(CalculateArea(L)) << endl; // using floor() function to round to the lowest number.

	return 0;
}

