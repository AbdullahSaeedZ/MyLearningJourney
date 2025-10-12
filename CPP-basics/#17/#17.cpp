#include <iostream>
using namespace std;

int main()
{

	short int A, B;

	cout << "please enter the value of A then B:" << endl;
	cin >> A;
	cin >> B;

	float Area = 0.5 * A * B; // or 1/2 * A * B which becomes A/2 * B

	cout << "The area of triangle is: " << Area << endl;

	return 0;


}
