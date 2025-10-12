#include <iostream>
using namespace std;

void ReadValues(short int& A, short int& B) // no need to redeclare A, B variables since i reference the parameters.
{
	
	cout << "plaese enter the value of A:" << endl;
	cin >> A;
	cout << "Please enter the value of B:" << endl;
	cin >> B;

}

short int Area(short int A, short int B)
{
	short int Area = A * B;
	return Area;

}

int main()
{
	short int Value1, Value2;

	ReadValues(Value1, Value2);

	cout << "Area is: " << Area(Value1, Value2) << endl;


	return 0;
}

