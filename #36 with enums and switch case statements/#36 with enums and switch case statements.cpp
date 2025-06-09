#include <iostream>
using namespace std;

enum enOperators {Add=1, Subtract=2, Multiply=3, Divide=4};

void ReadInputs(short int& Num1, short int& Num2, short int &UserOperator)
{
	cout << "Enter first number: " << endl;
	cin >> Num1;
	cout << "Enter second number: " << endl;
	cin >> Num2;
	
	cout << "****************************" << endl;
	cout << "Choose operation desired: " << endl;
	cout << "(1) Addition" << endl;
	cout << "(2) Subtraction" << endl;
	cout << "(3) Multiplication" << endl;
	cout << "(4) Division" << endl; 
	cin >> UserOperator;
}

void PrintResult(short int Num1, short int Num2, short int UserOperator)
{

	enOperators Operator = (enOperators)UserOperator;

	switch (Operator)
	{
		case enOperators::Add: 
			cout << "Addition result is: " << Num1 + Num2 << endl;
			break;
		case enOperators::Multiply: 
			cout << "Multiplication result is: " << Num1 * Num2 << endl; 
			break;
		case enOperators::Divide:
			cout << "Division result is: " << Num1 / Num2 << endl;
			break;
		case enOperators::Subtract: 
			cout << "Subtraction result is: " << Num1 - Num2 << endl;
			break;
		default: cout << "Wrong Operator, Try Again!" << endl;

	}
}



int main()
{
	short int Num1, Num2, UserOperator;
	ReadInputs(Num1, Num2, UserOperator);
	PrintResult(Num1, Num2, UserOperator);
}

