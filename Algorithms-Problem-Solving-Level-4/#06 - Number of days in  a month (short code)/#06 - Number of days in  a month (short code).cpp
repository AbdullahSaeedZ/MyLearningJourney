#include <iostream>
using namespace std;

bool IsLeapYear(int year)
{
	return ((year % 4 == 0) && (year % 100 != 0)) || ((year % 400 == 0));
}

//int NumOfMonthDays(int year, int mon)
//{
//	if (mon < 0 || mon > 12)
//		return 0;
//
//	if (mon == 2)
//		return (IsLeapYear(year)) ? 29 : 28;
//
//	short arrOfDays[7] = { 1,3,5,7,8,10,12 };
//
//	for (short i = 1; i <= 7; i++)
//	{
//		if (mon == arrOfDays[i - 1])
//			return 31;
//	}
//
//	return 30;
//}

int NumOfMonthDays(int year, int mon)
{
	return (mon < 1 || mon > 12) ? 0 : (mon == 2) ? ((IsLeapYear(year)) ? 29 : 28) : (mon == 2 || mon == 4 || mon == 6 || mon == 9 || mon == 11) ? 30 : 31;
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






	return 0;
}