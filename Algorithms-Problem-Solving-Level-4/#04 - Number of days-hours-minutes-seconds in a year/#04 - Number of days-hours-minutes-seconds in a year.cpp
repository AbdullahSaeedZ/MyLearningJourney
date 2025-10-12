#include <iostream>
using namespace std;

bool IsLeapYear(int num)
{
	return ((num % 4 == 0) && (num % 100 != 0)) || ((num % 400 == 0));
}

int NumOfYearDays(int num)
{
	return (IsLeapYear(num)) ? 366 : 365;
}

int NumOfYearHours(int num)
{
	return NumOfYearDays(num) * 24;
}

int NumOfYearMinutes(int num)
{
	return NumOfYearHours(num) * 60;
}

int NumOfYearSeconds(int num)
{
	return NumOfYearMinutes(num) * 60;
}

int main()
{

	int num;
	cout << "enter a year:" << endl;
	cin >> num;

	cout << "Number of days in year " << num << "is " << NumOfYearDays(num) << endl;
	cout << "Number of hours in year " << num << "is " << NumOfYearHours(num) << endl;
	cout << "Number of minutes in year " << num << "is " << NumOfYearMinutes(num) << endl;
	cout << "Number of seconds in year " << num << "is " << NumOfYearSeconds(num) << endl;





    return 0;
}

