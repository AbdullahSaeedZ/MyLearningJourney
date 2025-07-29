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

	string MonthName(short monthNum)
	{
		string MonthName;

		switch (monthNum)
		{
		case 1: MonthName = "JAN"; break;
		case 2: MonthName = "FEB"; break;
		case 3: MonthName = "MAR"; break;
		case 4: MonthName = "APR"; break;
		case 5: MonthName = "MAY"; break;
		case 6: MonthName = "JUN"; break;
		case 7: MonthName = "JUL"; break;
		case 8: MonthName = "AUG"; break;
		case 9: MonthName = "SEP"; break;
		case 10: MonthName = "OCT"; break;
		case 11: MonthName = "NOV"; break;
		case 12: MonthName = "DEC"; break;
		default: "None"; break;
		}

		return MonthName;
	}

	void PrintMonthCalendar(short year, short month)
	{
		string Mon = MonthName(month);
		short Day1 = GetWeekDayOrder(year, month, 1);
		short NumOfDays = NumOfMonthDays(year, month);

		printf("\n  _______________%s_______________\n\n", Mon.c_str());
		printf("  Sun  Mon  Tue  Wed  Thu  Fri  Sat\n");

		short i;
		for (i = 0; i < Day1; i++)
			printf("     ");

		for (short num = 1; num <= NumOfDays; num++)
		{
			printf("%5d", num);
			i++;

			if (i == 7)
			{
				i = 0;
				printf("\n");
			}
		}
	}

}
