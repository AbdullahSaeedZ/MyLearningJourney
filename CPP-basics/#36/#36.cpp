#include <iostream>
using namespace std;

void ReadInputs(short int& Num1, short int& Num2, string& Operator)
{
	cout << "Enter first number: " << endl;
	cin >> Num1;
	cout << "Enter second number: " << endl;
	cin >> Num2;
	cout << "Enter the operator: " << endl;
	cin >> Operator;
}

void PrintResult(short int& Num1, short int& Num2, string& Operator)
{
	if (Operator == "+")
	{
		cout << "Result is: " << Num1 + Num2 << endl;
	}
	else if (Operator == "-")
	{
		cout << "Result is: " << Num1 - Num2 << endl;
	}
	else if (Operator == "*")
	{
		cout << "Result is: " << Num1 * Num2 << endl;
	}
	else if (Operator == "/")
	{
		cout << "Result is: " << Num1 / Num2 << endl;
	}
	else
	{
		cout << "Enter a correct operator!" << endl;
	}
}

int main()
{
	short int Num1, Num2;
	string Operator;
	ReadInputs(Num1, Num2, Operator);
	PrintResult(Num1, Num2, Operator);

	return 0;
}