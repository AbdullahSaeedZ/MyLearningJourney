#include <iostream>
using namespace std;

// here is used short int& Num1 notice the & written with the int so the parameter will give its value to the 
void ShowNumber(short int& Num1, short int& Num2)
{
	cout << "Please enter the first number: " << endl;
	cin >> Num1;
	cout << "please enter the second number: " << endl;
	cin >> Num2;

	cout << Num1 << endl << Num2 << endl;
}

short int Swap(short int& Num1,short int& Num2)
{

	short int Temp = Num1;
	Num1 = Num2;
	Num2 = Temp;

	return Num1, Num2;
}

int main()
{
	short int Num1, Num2;
	ShowNumber(Num1, Num2);
	
	Swap(Num1, Num2);
	cout << Num1 << endl << Num2 << endl;


	return 0;
}