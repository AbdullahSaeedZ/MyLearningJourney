#include <iostream>
using namespace std;

struct stDate {
	short month = 0, day = 0, year = 0;
};

string WeekDayName(short DayOrder)
{
	string DayName;

	switch (DayOrder)
	{
	case 0: DayName = "Sunday"; break;
	case 1: DayName = "Monday"; break;
	case 2: DayName = "Tuesday"; break;
	case 3: DayName = "Wednesday"; break;
	case 4: DayName = "Thursday"; break;
	case 5: DayName = "Friday"; break;
	case 6: DayName = "Saturday"; break;
	default: "None"; break;
	}

	return DayName;
}

void PrintDate(stDate Date)
{
	cout << Date.day << "/" << Date.month << "/" << Date.year;
}

short GetWeekDayOrder(stDate Date)
{
	int a = ((14 - Date.month) / 12);
	int y = Date.year - a;
	int m = (Date.month + (12 * a)) - 2;

	// Gregorian formula:
	// result starts from 0 = sunday ..etc.
	int dayIndex = (Date.day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7;

	return dayIndex;
}

bool IsLeapYear(short num)
{
	return ((num % 4 == 0) && (num % 100 != 0)) || ((num % 400 == 0));
}

int NumOfMonthDays(int year, int mon)
{
	return (mon < 1 || mon > 12) ? 0 : (mon == 2) ? ((IsLeapYear(year)) ? 29 : 28) : (mon == 2 || mon == 4 || mon == 6 || mon == 9 || mon == 11) ? 30 : 31;
}

bool IsWeekEnd(stDate Date)
{
	return (GetWeekDayOrder(Date) >= 5);
}

bool IsLastDayInMonth(stDate Date)
{
	return (Date.day == NumOfMonthDays(Date.year, Date.month));
}

bool IsLastMonthInYear(short month)
{
	return (month == 12);
}

bool IsDate1EqualToDate2(stDate Date1, stDate Date2)
{
	return (Date1.year == Date2.year) ? ((Date1.month == Date2.month) ? ((Date1.day == Date2.day) ? true : false) : false) : false;
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

short GetVacationDays(stDate StartDate, stDate EndDate)
{
	short Counter = 0;

	while (!IsDate1EqualToDate2(StartDate, EndDate))
	{
		StartDate = IncreaseDateByOneDay(StartDate);

		if (!IsWeekEnd(StartDate))
			++Counter;
	}
	return Counter;
}

stDate GetVacationReturnDate(stDate Date1, short VacationDays)
{
	short WeekEndCounter = 0;

	// if start day is a weekend then we get rid of it, then start the process wih a business day for the vacation
	while (IsWeekEnd(Date1))
	{
		Date1 = IncreaseDateByOneDay(Date1);
	}

	//now we increase the date to  reach the return date, once we face a weekend day, we increase weekend counter to control the loop condition
	for (short i = 1; i <= VacationDays + WeekEndCounter; i++)
	{
		if (IsWeekEnd(Date1))
			WeekEndCounter++;

		Date1 = IncreaseDateByOneDay(Date1);
	}

	// if return dates happens to be in weekend, we increase till we reach a business day
	while (IsWeekEnd(Date1))
	{
		Date1 = IncreaseDateByOneDay(Date1);
	}

	return Date1;
}

int main()
{

	stDate Date1;
	Date1.day = 1;
	Date1.month = 1;
	Date1.year = 2022;

	short VacationDays = 23;

	stDate ReturnDate = GetVacationReturnDate(Date1, VacationDays);
	cout << "\nReturn Date: " << WeekDayName(GetWeekDayOrder(ReturnDate)) << " , ";
	PrintDate(ReturnDate);



	return 0;
}