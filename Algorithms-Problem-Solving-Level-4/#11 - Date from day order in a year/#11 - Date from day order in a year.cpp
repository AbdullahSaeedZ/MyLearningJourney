#include <iostream>
using namespace std;

short ReadDay()
{
	short Day;
	cout << "\nPlease enter a Day? ";
	cin >> Day;
	return Day;
}

short ReadMonth()
{
	short Month;
	cout << "\nPlease enter a Month? ";
	cin >> Month;

	return Month;
}

short ReadYear()
{
	short Year;
	cout << "\nPlease enter a Year? ";
	cin >> Year;

	return Year;
}

bool IsLeapYear(short num)
{
	return ((num % 4 == 0) && (num % 100 != 0)) || ((num % 400 == 0));
}

int NumOfMonthDays(int year, int mon)
{
	return (mon < 1 || mon > 12) ? 0 : (mon == 2) ? ((IsLeapYear(year)) ? 29 : 28) : (mon == 2 || mon == 4 || mon == 6 || mon == 9 || mon == 11) ? 30 : 31;
}

short DaysFromYearBeginning(short year, short month, short day)
{
	short DaysCount = 0;

	for (short i = 1; i < month; i++)
	{
		DaysCount += NumOfMonthDays(year, i);
	}

	DaysCount += day;

	return DaysCount;
}

struct stDate {
	short month = 0, day = 0, year = 0;
};

stDate DateOfDayNumberInYear(short year, short DayNum)
{
	stDate Date;
	short monthDays = 0;
	short RemainingDays = DayNum;

	Date.month = 1;
	Date.year = year;
	
	while (true)
	{
		monthDays = NumOfMonthDays(year, Date.month);

		if (RemainingDays > monthDays)
		{
			RemainingDays -= monthDays;
			Date.month++;
		}

		if (RemainingDays < monthDays)
		{
			Date.day = RemainingDays;
			break;
		}
	}

	return Date;
}

int main()
{
	short day = ReadDay();
	short month = ReadMonth();
	short year = ReadYear();
	short DayNumber = DaysFromYearBeginning(year, month, day);

	stDate Date = DateOfDayNumberInYear(year, DayNumber);

	cout << "\nNumber of Days from the beginning of the year is " << DayNumber << endl;

	cout << "\nDate for " << DayNumber << " is : " << Date.day << "/" << Date.month << "/" << Date.year << endl;


	return 0;
}