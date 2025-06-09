#include <iostream>
using namespace std;

void ReadMarks(float Mark[3])
{
	cout << "Please enter mark 1: " << endl;
	cin >> Mark[0];
	cout << "Please enter mark 2: " << endl;
	cin >> Mark[1];
	cout << "Please enter mark 3: " << endl;
	cin >> Mark[2];

}

float Average(float Mark[3])
{
	return ((Mark[0] + Mark[1] + Mark[2]) / 3);
}

void Print(float Mark[3])    // here we told him that you will recive an array variable
{
	if (Average(Mark) >= 50)   // here we told him take array by giving it the name of the varible, and he knows that this variable is an array cuz we told him earlier
	{
		cout << "Pass" << endl;

	}
	else
	{
		cout << "Fail" << endl;

	}

}
int main()
{
	float Mark[3];
	ReadMarks(Mark);
	Print(Mark);

	


	return 0;
}

