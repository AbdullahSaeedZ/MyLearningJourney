#include <iostream>
using namespace std;

void ReadInputs(float (&Grade)[3])  // to use by reference, we use (&Grade)[3] to tell him that there is an array called Grade and has 3 elements
                                    // if we dont put brackets, he will look for the third elemnt in Grade array.
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