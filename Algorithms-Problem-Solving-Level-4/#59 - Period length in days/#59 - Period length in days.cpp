#include <iostream>
using namespace std;

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

bool IsDate1BeforeDate2(stDate Date1, stDate Date2)
{
	return  (Date1.year < Date2.year) ? true : ((Date1.year == Date2.year) ? (Date1.month < Date2.month ? true : (Date1.month == Date2.month ? Date1.day < Date2.day : false)) : false);
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


short PeriodLengthInDays(stPeriod Period , bool IncludeEndDate = true)
{
	return DaysDiffOfTwoDates(Period.StartDate, Period.EndDate, IncludeEndDate);
}



int main()
{
	stPeriod Period1;
	cout << "\nStart Date:" << endl;
	Period1.StartDate = ReadDate();
	cout << "\nEnd Date: " << endl;
	Period1.EndDate = ReadDate();

	cout << "\n\nLength: " << PeriodLengthInDays(Period1, false) << endl;
	cout << "Length with end date: " << PeriodLengthInDays(Period1) << endl;
    
    
    return 0;
}

