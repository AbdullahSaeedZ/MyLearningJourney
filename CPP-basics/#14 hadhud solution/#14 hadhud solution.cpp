#include <iostream>
using namespace std;

void ReadInputs(int& Num1 ,int& Num2)
{
	cout << "Please enter the first number: " << endl;
	cin >> Num1;
	cout << "please enter the second number: " << endl;
	cin >> Num2;

	cout << Num1 << endl << Num2 << endl;
}


void Swap(int &Num1, int &Num2)
{
	int Temp = Num1;
	Num1 = Num2;
	Num2 = Temp;

}


int main()
{
	int Num1, Num2;
	ReadInputs(Num1, Num2);

	Swap(Num1, Num2);
	cout << Num1 << endl << Num2 << endl;

	return 0;
}