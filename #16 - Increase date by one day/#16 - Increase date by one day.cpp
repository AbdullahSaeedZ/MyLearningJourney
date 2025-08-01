#include <iostream>
using namespace std;

struct stDate {
	short month = 0, day = 0, year = 0;
};

int ReadPositiveNumber(string Message)
{
	int Number = 0;
	do
	{
		cout << Message << endl;
		cin >> Number;

		if (cin.fail())
		{
			// if other than numbers entered system will fail.
			cin.clear();                // to clear the failure
			cin.ignore(10000, '\n');    // to ignore what was entered before, to clean the buffer
			cout << "Invalid input! Please enter a number." << endl;
			continue;
		}

	} while (Number <= 0);

	return Number;
}

stDate ReadDate()
{
	stDate Date;
	Date.day = ReadPositiveNumber("Enter Day:");
	Date.month = ReadPositiveNumber("Enter Month:");
	Date.year = ReadPositiveNumber("Enter year:");

	return Date;
}

bool IsLeapYear(short num)
{
	return ((num % 4 == 0) && (num % 100 != 0)) || ((num % 400 == 0));
}

int NumOfMonthDays(int year, int mon)
{
	return (mon < 1 || mon > 12) ? 0 : (mon == 2) ? ((IsLeapYear(year)) ? 29 : 28) : (mon == 2 || mon == 4 || mon == 6 || mon == 9 || mon == 11) ? 30 : 31;
}

bool IsLastDayInMonth(stDate Date)
{
	return (Date.day == NumOfMonthDays(Date.year, Date.month));
}

bool IsLastMonthInYear(short month)
{
	return (month == 12);
}

stDate IncreaseDateByOneDay(stDate Date)
{
	if (IsLastDayInMonth(Date))
	{
		if (IsLastMonthInYear(Date.month))
		{
			Date.day = 1;
			Date.month = 1;
			Date.year++;
		}
		else
		{
			Date.day = 1;
			Date.month++;
		}
	}
	else
	{
		Date.day++;
	}
	
	return Date;
}

void PrintDate(stDate Date)
{
	cout << Date.day << "/" << Date.month << "/" << Date.year;
}

int main()
{
	stDate Date = ReadDate();
	Date = IncreaseDateByOneDay(Date);

	cout << "\nDate after adding one day: ";
	PrintDate(Date);

    return 0;
}

