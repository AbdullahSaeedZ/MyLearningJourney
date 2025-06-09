#include <iostream>
using namespace std;

void ReadInputs(short int& Num1, short int& Num2, char& Operator)
{
	cout << "Enter first number: " << endl;
	cin >> Num1;
	cout << "Enter second number: " << endl;
	cin >> Num2;
	cout << "Enter the operator: " << endl;
	cin >> Operator;
}

void PrintResult(short int Num1, short int Num2, char Operator)
{
	switch (Operator)            //case means if value of Operator is equal to '+' then print the code inside it. 
	{
	case '+': cout << "Result is: " << Num1 + Num2 << endl; break;    //if condition is met then we put break so that it ignores the rest.
	case '-': cout << "Result is: " << Num1 - Num2 << endl; break;	  //if we didnt put break then the rest of conditions will be printed eventhough condition is not met.
	case '*': cout << "Result is: " << Num1 * Num2 << endl; break;
	case '/': cout << "Result is: " << Num1 / Num2 << endl; break;

	default: cout << "Wrong Operator, Try Again!" << endl;           // default will be running if no condition of the above was met. it is like (else)
	}

}



int main()
{
	short int Num1, Num2;
	char Operator;
	ReadInputs(Num1, Num2, Operator);
	PrintResult(Num1, Num2, Operator);
}

