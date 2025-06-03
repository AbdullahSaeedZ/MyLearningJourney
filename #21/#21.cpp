#include <iostream>
using namespace std;

int main()
{
   
	float L;
	
	cout << "Enter L to calculate circle area along the circumference" << endl;
	cin >> L;

	float Area = pow(L, 2) / (4 * 3.141592653589793);

	cout << " Area is: " << floor(Area) << endl; // using floor() function to round to the lowest number.



	return 0;
}

