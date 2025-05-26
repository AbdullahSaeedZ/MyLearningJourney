#include <iostream>
using namespace std;

int main()
{
   
	float L;
	
	cout << "Enter L to calculate circle area along the circumference" << endl;
	cin >> L;

	float Area = (L * L) / (4 * 3.141592653589793);

	cout << " Area is: " << Area << endl;



	return 0;
}

