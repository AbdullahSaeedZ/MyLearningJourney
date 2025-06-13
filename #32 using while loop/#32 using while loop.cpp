#include <iostream>
using namespace std;

void ReadInput(int& Number, int &Power)
{
	cout << "Enter a number: " << endl;
	cin >> Number;
	cout << "Enter a Power: " << endl;
	cin >> Power;
}

int Result(int Number, int Power)
{
	int Counter = 2, Sum = Number;

	while (Counter <= Power)
	{
		Sum = Sum * Number;

		Counter++;

	}
	
	return Sum;
}

void Print(int Number, int Power)
{
	cout << "Result is: " << Result(Number, Power) << endl;
}

int main()
{
	int Number, Power;
	ReadInput(Number, Power);
	Print(Number, Power);
}
