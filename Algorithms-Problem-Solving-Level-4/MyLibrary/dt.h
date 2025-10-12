#pragma once

#include <iostream>
#include <string>
#include <vector>
using namespace std;

namespace dt
{

	struct stDate {
		short month = 0, day = 0, year = 0;
	};

	struct stPeriod {

		stDate StartDate;
		stDate EndDate;

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

	stPeriod ReadPeriod()
	{
		stPeriod Period;
		cout << "\nEnter start date:" << endl;
		Period.StartDate = ReadDate();
		cout << "\nEnter End date:" << endl;
		Period.EndDate = ReadDate();

		return Period;
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

	bool IsDate1BeforeDate2(stDate Date1, stDate Date2)
	{
		return  (Date1.year < Date2.year) ? true : ((Date1.year == Date2.year) ? (Date1.month < Date2.month ? true : (Date1.month == Date2.month ? Date1.day < Date2.day : false)) : false);
	}

	bool IsDate1EqualToDate2(stDate Date1, stDate Date2)
	{
		return (Date1.year == Date2.year) ? ((Date1.month == Date2.month) ? ((Date1.day == Date2.day) ? true : false) : false) : false;
	}

	bool IsDate1AfterDate2(stDate Date1, stDate Date2)
	{
		return  (!IsDate1BeforeDate2(Date1, Date2) && !IsDate1EqualToDate2(Date1, Date2));
	}

	enum enDateComparison { Before = -1, Equal = 0, After = 1 };

	enDateComparison CompareTwoDates(stDate Date1, stDate Date2)
	{
		return (IsDate1AfterDate2(Date1, Date2)) ? enDateComparison::After : (IsDate1BeforeDate2(Date1, Date2) ? enDateComparison::Before : enDateComparison::Equal);
	}

	bool IsOverlapPeriod(stPeriod Period1, stPeriod Period2)
	{
		// these two cases if there is no overlaping;
		return (CompareTwoDates(Period2.EndDate, Period1.StartDate) == enDateComparison::Before || CompareTwoDates(Period2.StartDate, Period1.EndDate) == enDateComparison::After) ? false : true;
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

	void PrintDate(stDate Date)
	{
		cout << Date.day << "/" << Date.month << "/" << Date.year;
	}

	stDate GetSystemDate()
	{
		stDate Date;

		time_t t = time(0);
		tm* now = localtime(&t);

		Date.day = now->tm_mday;
		Date.month = now->tm_mon + 1;
		Date.year = now->tm_year + 1900;

		return Date;
	}

	void  SwapDates(stDate& Date1, stDate& Date2)
	{
		stDate TempDate;
		TempDate.year = Date1.year;
		TempDate.month = Date1.month;
		TempDate.day = Date1.day;

		Date1.year = Date2.year;
		Date1.month = Date2.month;
		Date1.day = Date2.day;

		Date2.year = TempDate.year;
		Date2.month = TempDate.month;
		Date2.day = TempDate.day;

	}

	short DaysDiffOfTwoDates(stDate Date1, stDate Date2, bool IncludeEndDay = false)
	{
		int Days = 0;
		short SawpFlagValue = 1;

		if (!IsDate1BeforeDate2(Date1, Date2))
		{
			//Swap Dates 
			SwapDates(Date1, Date2);
			SawpFlagValue = -1;
		}

		while (IsDate1BeforeDate2(Date1, Date2))
		{
			Days++;
			Date1 = IncreaseDateByOneDay(Date1);
		}
		return (IncludeEndDay) ? ++Days * SawpFlagValue : Days * SawpFlagValue;

	}

	short PeriodLengthInDays(stPeriod Period, bool IncludeEndDate = true)
	{
		return DaysDiffOfTwoDates(Period.StartDate, Period.EndDate, IncludeEndDate);
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

	

	bool IsEndOfWeek(stDate Date)
	{
		return (GetWeekDayOrder(Date) == 6);
	}

	bool IsBusinessDay(stDate Date)
	{
		return (GetWeekDayOrder(Date) <= 4);
	}

	bool IsWeekEnd(stDate Date)
	{
		return (GetWeekDayOrder(Date) >= 5);
	}

	short DaysUntilEndOfWeek(stDate Date)
	{
		return 6 - (GetWeekDayOrder(Date));
	}

	short DaysUntilEndOfMonth(stDate Date)
	{
		return (NumOfMonthDays(Date.year, Date.month)) - Date.day;
	}

	short DaysUntilEndOfYear(stDate Date)
	{
		return ((IsLeapYear(Date.year)) ? 366 : 365) - (DaysNumFromYearBeginning(Date.year, Date.month, Date.day));
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

	bool IsDateWithinPeriod(stPeriod Period, stDate Date)
	{
		return  !(CompareTwoDates(Date, Period.StartDate) == enDateComparison::Before || CompareTwoDates(Date, Period.EndDate) == enDateComparison::After);
	}

	short GetPeriodsOverlapDays(stPeriod Period1, stPeriod Period2)
	{
		if (!IsOverlapPeriod(Period1, Period2))
			return 0;
		// take the farest start date of the two periods
		stDate Start = (CompareTwoDates(Period1.StartDate, Period2.StartDate) == enDateComparison::Before) ? Period2.StartDate : Period1.StartDate;

		// take the closest end date of the two periods
		stDate End = (CompareTwoDates(Period1.EndDate, Period2.EndDate) == enDateComparison::Before) ? Period1.EndDate : Period2.EndDate;

		return PeriodLengthInDays({ Start, End });
	}

	bool IsValidDate(stDate Date)
	{
		return  ((Date.year >= 1) && (Date.month >= 1 && Date.month <= 12) && (Date.day >= 1) && (Date.day <= NumOfMonthDays(Date.year, Date.month)));
	}

	stDate StringToStDate(string str, string delim = "/")
	{
		vector<string> vWords;

		short pos = 0;
		string sWord;

		while ((pos = str.find(delim)) != string::npos)
		{
			sWord = str.substr(0, pos);

			if (sWord != "")
				vWords.push_back(sWord);

			str.erase(0, pos + delim.length());
		}

		if (str != "")
			vWords.push_back(str);

		stDate Date;
		Date.day = stoi(vWords.at(0));
		Date.month = stoi(vWords.at(1));
		Date.year = stoi(vWords.at(2));


		return Date;
	}

	string stDateToString(stDate Date, string delim = "/")
	{
		string str = "";

		str = to_string(Date.day) + delim + to_string(Date.month) + delim + to_string(Date.year);


		return str;
	}

	string ReplaceExactWord(string str, string OldWord, string NewWord)
	{
		short pos = 0;
		while ((pos = str.find(OldWord)) != string::npos)
		{

			str = str.replace(pos, OldWord.length(), NewWord);

		}

		return str;
	}

	string PrintDateFormat(stDate Date, string Format = "dd/mm/yyyy")
	{
		string Formatted = "";
		Formatted = ReplaceExactWord(Format, "dd", to_string(Date.day));
		Formatted = ReplaceExactWord(Formatted, "mm", to_string(Date.month));
		Formatted = ReplaceExactWord(Formatted, "yyyy", to_string(Date.year));

		return Formatted;
	}


}
