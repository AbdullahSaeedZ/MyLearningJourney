#include <iostream>
using namespace std;

void ReadInputs(float Grade[3])  // the parameters here when dealing with arrays, are takeing it by-reference by default, no need to use &.
{
	cout << "Enter first grade: " << endl;
	cin >> Grade[0];
	cout << "Enter second grade: " << endl;
	cin >> Grade[1];
	cout << "Enter third grade: " << endl;
	cin >> Grade[2];
	cout << endl; 
}

float Average(float Grade[3])
{
	return (Grade[0] + Grade[1] + Grade[2]) / 3;
}

void Print(float Grade[3])
{
	cout << "The average of grades is: " << Average(Grade) << endl;
}

int main()
{
	float Grade[3];
	ReadInputs(Grade);
	Print(Grade);


	return 0;

}