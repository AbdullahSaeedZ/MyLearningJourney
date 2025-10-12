#include <iostream>
using namespace std;

struct stDate {
    short month = 0, day = 0, year = 0;
};

void PrintDate(stDate Date)
{
    cout << Date.day << "/" << Date.month << "/" << Date.year;
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

// overloading:
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

int main()
{
    
    stDate Date;
    Date.day = 27;
    Date.month = 9;
    Date.year = 2022;


    cout << "\nToday is " << WeekDayName(GetWeekDayOrder(Date)) << " , ";
    PrintDate(Date);


	cout << "\n\nIs it end of week ?" << endl;
	if (IsEndOfWeek(Date))
		cout << "Yes, it is end of week" << endl;
	else
		cout << "No, it is not end of week" << endl;


	cout << "\nIs it weekend ?" << endl;
	if (IsWeekEnd(Date))
		cout << "Yes, it is a week end" << endl;
	else
		cout << "No, it is not a week end" << endl;



	cout << "\nIs it a business day?" << endl;
	if (IsBusinessDay(Date))
		cout << "Yes, it is a business day" << endl;
	else
		cout << "No, it is not a business day" << endl;


	cout << "\nDays until end of week : " << DaysUntilEndOfWeek(Date) << " Days(s)." << endl;
	cout << "Days until end of month : " << DaysUntilEndOfMonth(Date) << " Days(s)." << endl;
	cout << "Days until end of year : " << DaysUntilEndOfYear(Date) << " Days(s)." << endl;




    return 0;
}

