#include <iostream>
using namespace std;

short GetWeekDayOrder(short year, short month, short day)
{
    int a = ((14 - month) / 12);
    int y = year - a;
    int m = (month + (12 * a)) - 2;

    // Gregorian formula:
    // result starts from 0 = sunday ..etc.
    int dayIndex = (day + y + (y / 4) - (y /100) + (y / 400) + ((31 * m)/ 12) )% 7;

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

void PrintBirthInfo(short year, short month, short day)
{
    short DayOrder = GetWeekDayOrder(year, month, day);
    string DayName = DayWeekName(DayOrder);

    cout << "\nDate: " << day << "/" << month << "/" << year << endl;
    cout << "Day order: " << DayOrder << endl;
    cout << "Day Name: " << DayName<< endl;
}

int main()
{
    
    short year = 0, month = 0, day = 0;
    cout << "enter a year: ";
    cin >> year;

    cout << "enter a month: ";
    cin >> month;

    cout << "enter a day: ";
    cin >> day;

    PrintBirthInfo(year, month, day);


    return 0;
}

