#include <iostream>
using namespace std;

enum enWeek { Sunday =1, Monday=2, Tuesday=3, Wednseday=4, Thursday=5, Friday=6, Saturday=7};

void ReadDay(short int& Day)
{
    cout << "Choose which day of the week: " << endl << endl;
    cout << "(1)First day of the week" << endl;
    cout << "(2)Second day of the week" << endl;
    cout << "(3)Third day of the week" << endl;
    cout << "(4)Fourth day of the week" << endl;
    cout << "(5)Fifth day of the week" << endl;
    cout << "(6)Sixth day of the week" << endl;
    cout << "(7)Seventh day of the week" << endl;
    cin >> Day;
}

void PrintDay(short int Day)
{

    enWeek InputDay = (enWeek)Day;

    switch (InputDay)
    {
    case enWeek::Sunday: cout << "It is Sunday!" << endl;
        break;
    case enWeek::Monday:cout << "It is Monday!" << endl;
        break;
    case enWeek::Tuesday:cout << "It is Tuesday!" << endl;
        break;
    case enWeek::Wednseday: cout << "It is Wednseday!" << endl;
        break;
    case enWeek::Thursday:  cout << "It is Thursday!" << endl;
        break;
    case enWeek::Friday: cout << "It is Friday!" << endl;
        break;
    case enWeek::Saturday:cout << "It is Saturday!" << endl;
        break;
    default: cout << "Wrong Number, Try Again!" << endl;

    }
}
    

int main()
{
    short int Day;
    ReadDay(Day);
    PrintDay(Day);

    return 0;
}

