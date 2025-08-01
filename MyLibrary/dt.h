#pragma once

#include <iostream>
using namespace std;

namespace dt
{
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

	void PrintYearCalendar(short year)
	{
		printf("\n  -----------------------------");
		printf("\n           Calendar - %d", year);
		printf("\n  -----------------------------\n");

		for (short i = 1; i <= 12; i++)
		{
			PrintMonthCalendar(year, i);
			printf("\n  ---------------------------------\n");
		}
	}

	short DaysNumFromYearBeginning(short year, short month, short day)
	{
		short DaysCount = 0;

		for (short i = 1; i < month; i++)
		{
			DaysCount += NumOfMonthDays(year, i);
		}

		DaysCount += day;

		return DaysCount;
	}

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

	stDate DateAfterAddingDays(stDate CurrentDate, short DaysToAdd)
	{
		short RemingDays = DaysToAdd + DaysNumFromYearBeginning(CurrentDate.year, CurrentDate.month, CurrentDate.day);

		while (RemingDays > (IsLeapYear(CurrentDate.year) ? 366 : 365))
		{
			RemingDays -= (IsLeapYear(CurrentDate.year) ? 366 : 365);
			CurrentDate.year++;

		}

		CurrentDate = DateOfDayNumberInYear(CurrentDate.year, RemingDays);

		return CurrentDate;
	}

	bool IsDate1MoreThanDate2(stDate Date1, stDate Date2)
	{
		return (Date1.year > Date2.year) ? true : (Date1.year == Date2.year) ? ((Date1.month > Date2.month) ? true : ((Date1.month == Date2.month) ? ((Date1.day > Date2.day) ? true : false ) : false)): false;
	}

	bool IsDate1EqualToDate2(stDate Date1, stDate Date2)
	{
		return (Date1.year == Date2.year) ? ((Date1.month == Date2.month) ? ((Date1.day == Date2.day) ? true : false) : false) : false;
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

}
