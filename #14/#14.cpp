#include <iostream>
using namespace std;

int main()
{
	
	short int Num1, Num2;

	cout << "Please enter the first number: " << endl;
	cin >> Num1;
	cout << "please enter the second number: " << endl;
	cin >> Num2;

	cout << Num1 << endl << Num2 << endl << endl;
	
	short int Temp = Num1;
	Num1 = Num2;
	Num2 = Temp;

	cout << Num1 << endl << Num2 << endl << endl;


	return 0;
}