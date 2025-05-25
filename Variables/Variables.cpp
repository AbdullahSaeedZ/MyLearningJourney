#include <iostream>
using namespace std;

int main()
{
	string MyName = "Abdullah Alzahrani";
	short int MyAge = 27;
	string MyJob = "programmer";
	short int Number = 23;
	float FloatNumber = 27.5;
	double NumberWithDecimels = 27.5453345;
	char MyLetter = 'A';
	bool Boolean = true;

	cout << "hi there! my name is " << MyName << ", im " << MyAge << " years old " << "and im a " << MyJob << endl;

	cout << MyAge << endl;

	short int x = 3;
	short int y = 5;
	short int Sum = x + y;

	cout << Sum << endl;

	char char1 = 'A', char2 = 'B', char3 = 'C';

	cout << "letters are = " << char1 << char2 << char3 << " and reverse is = " << char3 << char2 << char1 << endl;

	// const is a constant which is unchangeable and read-only value unlike a variable 
	
	const short int Age = 27;
	const string Name = "Abdullah";

	cout << "my name is " << Name << " and my age is " << Age << endl;

	return 0;

}
// 2nd test
// 2nd test
// 2nd test
// 2nd test