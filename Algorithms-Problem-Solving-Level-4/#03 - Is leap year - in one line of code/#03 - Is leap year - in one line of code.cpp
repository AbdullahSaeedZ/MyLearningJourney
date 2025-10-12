#include <iostream>
using namespace std;


bool IsLeapYear(int num)
{
	// if year is divisible by 4 AND not divisible by 100
	// OR if year is divisible by 400
	// then it is a leap year
	return ((num % 4 == 0) && (num % 100 != 0)) || ((num % 400 == 0));
}

int main()
{

	cout << IsLeapYear(1200);


	return 0;
}