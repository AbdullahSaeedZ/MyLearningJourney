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

stDate IncreaseDateByXDays(stDate Date, short x)
{
	for (short i = 1; i <= x; i++)
	{
		Date = IncreaseDateByOneDay(Date);
	}

	return Date;
}

stDate IncreaseDateBy1Week(stDate Date)
{
	for (short i = 1; i <= 7; i++)
	{
		Date = IncreaseDateByOneDay(Date);
	}

	return Date;
}

stDate IncreaseDateByXWeek(stDate Date, short x)
{
	for (short i = 1; i <= x; i++)
	{
		Date = IncreaseDateBy1Week(Date);
	}

	return Date;
}

stDate IncreaseDateBy1Month(stDate Date)
{
	if (Date.month == 12)
	{
		Date.month = 1;
		Date.year++;
	}
	else
	{
		++Date.month;
	}

	short EndDay = NumOfMonthDays(Date.year, Date.month);
	if (Date.day > EndDay)
		Date.day = EndDay;


	return Date;
}

stDate IncreaseDateByXMonth(stDate Date, short x)
{
	for (short i = 1; i <= x; i++)
	{
		Date = IncreaseDateBy1Month(Date);
	}

	return Date;
}

stDate IncreaseDateBy1Year(stDate Date)
{
	++Date.year;

	short EndDay = NumOfMonthDays(Date.year, Date.month);

	if (IsLeapYear(Date.year) && Date.day > EndDay)
		Date.day = EndDay;

	return Date;
}

stDate IncreaseDateByXYear(stDate Date, short x)
{
	for (short i = 1; i <= x; i++)
	{
		Date = IncreaseDateBy1Year(Date);
	}
	return Date;
}

stDate IncreaseDateByXYearFaster(stDate Date, short x)
{
	Date.year += x;
	return Date;
}

stDate IncreaseDateBy1Decade(stDate Date)
{
	Date.year += 10;
	return Date;
}

stDate IncreaseDateByXDecade(stDate Date, short x)
{
	for (short i = 1; i <= x; i++)
	{
		Date = IncreaseDateBy1Decade(Date);
	}
	return Date;
}

stDate IncreaseDateByXDecadeFaster(stDate Date, short x)
{
	Date.year += 10 * x;
	return Date;
}

stDate IncreaseDateBy1Century(stDate Date)
{
	Date.year += 100;
	return Date;
}

stDate IncreaseDateBy1Millennium(stDate Date)
{
	Date.year += 1000;
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

	Date = IncreaseDateByOneDay(Date);
	cout << "\n1- adding one day: ";
	PrintDate(Date);
	//----------

	Date = IncreaseDateByXDays(Date, 10);
	cout << "\n2- adding 10 day: " ;
	PrintDate(Date);
	//----------

	Date = IncreaseDateBy1Week(Date);
	cout << "\n3- adding one week: " ;
	PrintDate(Date);
	//----------

	Date = IncreaseDateByXWeek(Date, 10);
	cout << "\n4- adding 10 weeks: " ;
	PrintDate(Date);
	//----------

	Date = IncreaseDateBy1Month(Date);
	cout << "\n5- adding one month: " ;
	PrintDate(Date);
	//----------

	Date = IncreaseDateByXMonth(Date, 5);
	cout << "\n6- adding 5 months: " ;
	PrintDate(Date);
	//----------

	Date = IncreaseDateBy1Year(Date);
	cout << "\n7- adding one year: ";
	PrintDate(Date);
	//----------

	Date = IncreaseDateByXYear(Date, 10);
	cout << "\n8- adding 10 years: " ;
	PrintDate(Date);
	//----------

	Date = IncreaseDateByXYearFaster(Date, 10);
	cout << "\n9- adding 10 years (faster function): " ;
	PrintDate(Date);
	//----------

	Date = IncreaseDateBy1Decade(Date);
	cout << "\n10- adding one decade(10 years): " ;
	PrintDate(Date);
	//----------

	Date = IncreaseDateByXDecade(Date, 10);
	cout << "\n11- adding 10 decades: ";
	PrintDate(Date);
	//----------

	Date = IncreaseDateByXDecadeFaster(Date, 10);
	cout << "\n12- adding 10 decades (faster function): " ;
	PrintDate(Date);
	//----------

	Date = IncreaseDateBy1Century(Date);
	cout << "\n13- adding one century(100 year): " ;
	PrintDate(Date);
	//----------

	Date = IncreaseDateBy1Millennium(Date);
	cout << "\n14- adding one millennium (1000 year): " ;
	PrintDate(Date);

	cout << "\n\n\n" << endl;
    
    
    
    return 0;;
}

