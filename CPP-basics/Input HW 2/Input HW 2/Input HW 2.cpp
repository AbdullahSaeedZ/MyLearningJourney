#include <iostream>
using namespace std;

int main()
{

	float Value1;
	float Value2;
	float Value3;

	cout << "Enter a Number: " << endl;
	cin >> Value1;

	cout << "Enter the second number: " << endl;
	cin >> Value2;

	cout << "Enter the third number: " << endl;
	cin >> Value3;

	float Total = Value1 + Value2 + Value3;

	cout << Value1 << " +\n" << Value2 << " +\n" << Value3 << endl;
	cout << "_______________\n\n" << "Total is: " << Total << endl;

	return 0;


}