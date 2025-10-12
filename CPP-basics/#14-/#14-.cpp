#include <iostream>
using namespace std;

void ReadInputs(short int& Num1, short int& Num2)
{
	cout << "Please enter the first number: " << endl;
	cin >> Num1;
	cout << "please enter the second number: " << endl;
	cin >> Num2;

	cout << Num1 << endl << Num2 << endl;
}

struct Swapping {

	int First;
	int Second;

};


Swapping Swap(int Num1, int Num2)
{
	short int Temp = Num1;
	Num1 = Num2;
	Num2 = Temp;

	Swapping Result;
	Result.First = Num1;
	Result.Second = Num2;


	return Result;
}

void Print(Swapping Final)
{
	
	cout << Final.First << endl << Final.Second << endl;

	

}

int main()
{
	short int Num1, Num2;
	ReadInputs(Num1, Num2);

	Swapping Final = Swap(Num1, Num2);

	Print(Final);


	return 0;
}