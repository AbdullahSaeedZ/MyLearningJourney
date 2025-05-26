#include <iostream>
using namespace std;

int main()
{

	short int Mark1, Mark2, Mark3;

	cout << "please enter the first mark:" << endl;
	cin >> Mark1;
	cout << "please enter the first mark:" << endl;
	cin >> Mark2;
	cout << "please enter the first mark:" << endl;
	cin >> Mark3;

	short int Average = (Mark1 + Mark2 + Mark3) / 3;

	cout << "the average mark is: " << Average << endl;

	return 0;
}