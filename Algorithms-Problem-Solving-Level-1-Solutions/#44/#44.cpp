#include <iostream>
#include <string>
using namespace std;

enum enWeekDays {Sunday = 1, Monday = 2, Tuesday = 3, Wednesday = 4, Thursday = 5, Friday = 6, Saturday = 7};

void ShowDays()
{
    cout << "[1]Sunday\n[2]Monday\n[3]Tuesday\n[4]Wednesday\n[5]Thursday\n[6]Friday\n[7]Saturday" << endl;
}

int ReadPositiveNumber(string Message, int From, int To)
{
    int Number = 0;

    ShowDays();

    cout << Message << endl;
    cin >> Number;

    while (Number < From || Number > To)
    {
        cout << "Wrong Number, enter a valid Number" << endl;
        cin >> Number;
    }

    return Number;
}

enWeekDays CheckDay()
{
    return (enWeekDays)ReadPositiveNumber("Choose a number from the menu to show the day", 1, 7);
}

string PrintDay(enWeekDays Day)
{
    switch (Day)
    {
    case enWeekDays::Sunday: return "Sunday";
    case enWeekDays::Monday: return "Monday";
    case enWeekDays::Tuesday: return "Tuesday";
    case enWeekDays::Wednesday: return "Wednesday";
    case enWeekDays::Thursday: return "Thursday";
    case enWeekDays::Friday: return "Friday";
    case enWeekDays::Saturday: return "Saturday";
    default: return "Invalid Day";
    }
}


int main()
{
    
    cout << "You seleted: " << PrintDay(CheckDay());
    return 0;
}

