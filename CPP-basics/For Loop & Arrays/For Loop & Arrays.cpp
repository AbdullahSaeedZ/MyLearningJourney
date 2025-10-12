#include <iostream>
using namespace std;

void ReadArrayData(int Array[100], int& Length)
{
	cout << "How many numbers do you want to enter (from 1 to 100): " << endl;
	cin >> Length;
	
	for (int Counter = 0; Counter < Length; Counter++)
	{
		
		cout << "Enter number " << Counter + 1 << " :" << endl;
		cin >> Array[Counter];
	}

}

void PrintArrayData(int Array[100], int Length)
{
	
	

	for (int Counter = 0; Counter < Length; Counter++)
	{
		

		cout << "Number ["<< Counter + 1 << "] :" << endl;
		cout <<  Array[Counter] << endl;

	}

	
}

int Sum(int Array[100], int Length)
{
	int Sum = 0;

	for (int Counter = 0; Counter < Length; Counter++)
	{
		
		Sum += Array[Counter];            //Sum = Sum + Array[Counter];

	}

	return Sum;
}

float Average(int Array[100], int Length)
{

	return (float)Sum(Array, Length) / Length;     /*this is REUSABLITY, first do casting from int to float(average might be in deci)
												     then apply the sum function divided by length, which is average formula. */
}


int main()
{
	int Array[100], Length = 0;
	ReadArrayData(Array, Length);
	PrintArrayData(Array, Length);

	cout << "**************" << endl;
	cout << "Sum: " << Sum(Array, Length) << endl;
	cout << "Average: " << Average(Array, Length) << endl;   

	return 0;
}


	/*the Average will call the sum function , and we already called it above, so for better optimization, we can
	make a small change to increase speed of the program by decreasing the times we call the Sum function as the following:

	
	int Array[100], Length = 0;
	ReadArrayData(Array, Length);
	PrintArrayData(Array, Length);

	int sum = Sum(Array, Length);
	cout << "**************" << endl;
	cout << "Sum: " << Sum << endl;
	cout << "Average: " Sum / Length << endl;
	*/