#include <iostream>
using namespace std;
int main()
{
  
	float A;

	cout << "Enter the Area:" << endl;
	cin >> A;

	float Area = (3.141592653589793 * pow(A, 2)) / 4;
	
	cout << " the circle area is: " << ceil(Area) << endl;



	return 0;
}
