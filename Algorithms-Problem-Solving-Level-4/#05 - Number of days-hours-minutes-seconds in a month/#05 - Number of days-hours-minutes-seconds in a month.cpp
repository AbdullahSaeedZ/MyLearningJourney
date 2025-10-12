#include <iostream>
using namespace std;

bool IsLeapYear(int num)
{
	return ((num % 4 == 0) && (num % 100 != 0)) || ((num % 400 == 0));
}

int NumOfMonthDays(int num, int mon)
{
	if (mon < 0 || mon > 12)
		return 0;

	if (mon == 2)
		return (IsLeapYear(num)) ? 29 : 28;

	short arrOfDays[7] = {1,3,5,7,8,10,12};

	for (short i = 1; i <= 7; i++)
	{
		if (mon == arrOfDays[i - 1])
			return 31;
	}

	return 30;
}

int NumOfMonthHours(int num, int mon)
{
	return NumOfMonthDays(num, mon) * 24;
}

int NumOfMonthMinutes(int num, int mon)
{
	return NumOfMonthHours(num, mon) * 60;
}

int NumOfMonthSeconds(int num, int mon)
{
	return NumOfMonthMinutes(num, mon) * 60;
}

int main()
{

	int num;
	cout << "enter a year:" << endl;
	cin >> num;

	int mon;
	cout << "enter a month:" << endl;
	cin >> mon;

	cout << "Number of days in month " << mon << " is " << NumOfMonthDays(num, mon) << endl;
	cout << "Number of hours in month " << mon << " is " << NumOfMonthHours(num, mon) << endl;
	cout << "Number of minutes in month " << mon << " is " << NumOfMonthMinutes(num, mon) << endl;
	cout << "Number of seconds in month " << mon << " is " << NumOfMonthSeconds(num, mon) << endl;





	return 0;
}