#include <iostream>
using namespace std;

int main()
{
	short int A;
	short int B;

	cout << "Enter the first number: " << endl;
	cin >> A;
	cout << "Enter the second number: " << endl;
	cin >> B;

	cout << A << "+" << B << "=" << A + B << endl;
	cout << A << "-" << B << "=" << A - B << endl;
	cout << A << "*" << B << "=" << A * B << endl;
	cout << A << "/" << B << "=" << A / B << endl;
	cout << A << "%" << B << "=" << A % B << endl;



	return 0;
}