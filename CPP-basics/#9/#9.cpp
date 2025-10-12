#include <iostream>
using namespace std;

int main()
{

	short int Num1, Num2, Num3;

	cout << "Enter the first number: " << endl;
	cin >> Num1;
	cout << "Enter the second number: " << endl;
	cin >> Num2;
	cout << "Enter the third number: " << endl;
	cin >> Num3;
	
	short int Sum = Num1 + Num2 + Num3;

	cout << "the sum of the three numbers is " << Sum << endl;

	return 0;
}