#include <iostream>
using namespace std;

struct stDate {
	short month = 0, day = 0, year = 0;
};

bool IsLeapYear(short num)
{
	return ((num % 4 == 0) && (num % 100 != 0)) || ((num % 400 == 0));
}

void PrintDate(stDate Date)
{
	cout << Date.day << "/" << Date.month << "/" << Date.year;
}

int NumOfMonthDays(int year, int mon)
{
	return (mon < 1 || mon > 12) ? 0 : (mon == 2) ? ((IsLeapYear(year)) ? 29 : 28) : (mon == 2 || mon == 4 || mon == 6 || mon == 9 || mon == 11) ? 30 : 31;
}

short GetWeekDayOrder(short year, short month, short day)
{
	int a = ((14 - month) / 12);
	int y = year - a;
	int m = (month + (12 * a)) - 2;

	// Gregorian formula:
	// result starts from 0 = sunday ..etc.
	int dayIndex = (day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7;

	return dayIndex;
}

bool IsLastDayInMonth(stDate Date)
{
	return (Date.day == NumOfMonthDays(Date.year, Date.month));
}

bool IsLastMonthInYear(short month)
{
	return (month == 12);
}


stDate DecreaseDateByOneDay(stDate Date)
{
	if (Date.day == 1)
	{
		if (Date.month == 1)
		{
			Date.year--;
			Date.month = 12;
			Date.day = 31;
		}
		else
		{
			Date.month--;
			Date.day = NumOfMonthDays(Date.year, Date.month);
		}
	}
	else
	{
		Date.day--;
	}

	return Date;
}

stDate DecreaseDateByXDays(stDate Date, short x)
{
	for (short i = 1; i <= x; i++)
	{
		Date = DecreaseDateByOneDay(Date);
	}

	return Date;
}

stDate DecreaseDateBy1Week(stDate Date)
{
	for (short i = 1; i <= 7; i++)
	{
		Date = DecreaseDateByOneDay(Date);
	}

	return Date;
}

stDate DecreaseDateByXWeek(stDate Date, short x)
{
	for (short i = 1; i <= x; i++)
	{
		Date = DecreaseDateBy1Week(Date);
	}

	return Date;
}

stDate DecreaseDateBy1Month(stDate Date)
{
	if (Date.month == 1)
	{
		Date.month = 12;
		Date.year--;
	}
	else
	{
		--Date.month;
	}

	short EndDay = NumOfMonthDays(Date.year, Date.month);
	if (Date.day > EndDay)
		Date.day = EndDay;


	return Date;
}

stDate DecreaseDateByXMonth(stDate Date, short x)
{
	for (short i = 1; i <= x; i++)
	{
		Date = DecreaseDateBy1Month(Date);
	}

	return Date;
}

stDate DecreaseDateBy1Year(stDate Date)
{
	--Date.year;

	short EndDay = NumOfMonthDays(Date.year, Date.month);

	if (IsLeapYear(Date.year) && Date.day > EndDay)
		Date.day = EndDay;

	return Date;
}

stDate DecreaseDateByXYear(stDate Date, short x)
{
	for (short i = 1; i <= x; i++)
	{
		Date = DecreaseDateBy1Year(Date);
	}
	return Date;
}

stDate DecreaseDateByXYearFaster(stDate Date, short x)
{
	Date.year -= x;
	return Date;
}

stDate DecreaseDateBy1Decade(stDate Date)
{
	Date.year -= 10;
	return Date;
}

stDate DecreaseDateByXDecade(stDate Date, short x)
{
	for (short i = 1; i <= x; i++)
	{
		Date = DecreaseDateBy1Decade(Date);
	}
	return Date;
}

stDate DecreaseDateByXDecadeFaster(stDate Date, short x)
{
	Date.year -= 10 * x;
	return Date;
}

stDate DecreaseDateBy1Century(stDate Date)
{
	Date.year -= 100;
	return Date;
}

stDate DecreaseDateBy1Millennium(stDate Date)
{
	Date.year -= 1000;
	return Date;
}

int main()
{

	stDate Date;
	Date.day = 31;
	Date.month = 12;
	Date.year = 2022;
	PrintDate(Date);

	cout << "\nDate after:" << endl;

	Date = DecreaseDateByOneDay(Date);
	cout << "\n1- Subtracting one day: ";
	PrintDate(Date);
	//----------

	Date = DecreaseDateByXDays(Date, 10);
	cout << "\n2- Subtracting 10 day: ";
	PrintDate(Date);
	//----------

	Date = DecreaseDateBy1Week(Date);
	cout << "\n3- Subtracting one week: ";
	PrintDate(Date);
	//----------

	Date = DecreaseDateByXWeek(Date, 10);
	cout << "\n4- Subtracting 10 weeks: ";
	PrintDate(Date);
	//----------

	Date = DecreaseDateBy1Month(Date);
	cout << "\n5- Subtracting one month: ";
	PrintDate(Date);
	//----------

	Date = DecreaseDateByXMonth(Date, 5);
	cout << "\n6- Subtracting 5 months: ";
	PrintDate(Date);
	//----------

	Date = DecreaseDateBy1Year(Date);
	cout << "\n7- Subtracting one year: ";
	PrintDate(Date);
	//----------

	Date = DecreaseDateByXYear(Date, 10);
	cout << "\n8- Subtracting 10 years: ";
	PrintDate(Date);
	//----------

	Date = DecreaseDateByXYearFaster(Date, 10);
	cout << "\n9- Subtracting 10 years (faster function): ";
	PrintDate(Date);
	//----------

	Date = DecreaseDateBy1Decade(Date);
	cout << "\n10- Subtracting one decade(10 years): ";
	PrintDate(Date);
	//----------

	Date = DecreaseDateByXDecade(Date, 10);
	cout << "\n11- Subtracting 10 decades: ";
	PrintDate(Date);
	//----------

	Date = DecreaseDateByXDecadeFaster(Date, 10);
	cout << "\n12- Subtracting 10 decades (faster function): ";
	PrintDate(Date);
	//----------

	Date = DecreaseDateBy1Century(Date);
	cout << "\n13- Subtracting one century(100 year): ";
	PrintDate(Date);
	//----------

	Date = DecreaseDateBy1Millennium(Date);
	cout << "\n14- Subtracting one millennium (1000 year): ";
	PrintDate(Date);

	cout << "\n\n\n" << endl;



	return 0;;
}

