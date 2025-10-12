// #02 - Check if year is a leap year.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;


bool IsLeapYear(int num)
{
	// leap year if perfectly divisible by 400
	if (num % 400 == 0)
		return true;

	// not a leap year if divisible by 100
	// but not divisible by 400
	else if (num % 100 == 0)
		return false;

	// leap year if not divisible by 100
	// but divisible by 4
	else if (num % 4 == 0)
		return true;
	// all other years are not leap years
	else
		return false;
}

int main()
{
	
	cout << IsLeapYear(1200);


	return 0;
}

