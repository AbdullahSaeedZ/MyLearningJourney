#pragma once

#include <iostream>
using namespace std;

namespace dt
{

	bool IsLeapYear(short num)
	{
		return ((num % 4 == 0) && (num % 100 != 0)) || ((num % 400 == 0));
	}

	short NumOfYearDays(short num)
	{
		return (IsLeapYear(num)) ? 366 : 365;
	}

	short NumOfYearHours(short num)
	{
		return NumOfYearDays(num) * 24;
	}

	short NumOfYearMinutes(short num)
	{
		return NumOfYearHours(num) * 60;
	}

	short NumOfYearSeconds(short num)
	{
		return NumOfYearMinutes(num) * 60;
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

	string DayWeekName(short DayOrder)
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

}
