#include <iostream>
using namespace std;

void ReadDay(short int& Day)
{
    cout << "Enter the number of day in a week: " << endl;
    cin >> Day;
}

void PrintDay(short int Day)
{
    if (Day == 1)
    {
        cout << "It is Sunday!" << endl;
    }
    else if (Day == 2)
    {
        cout << "It is Monday!" << endl;
    }
    else if (Day == 3)
    {
        cout << "It is tuesday!" << endl;
    }
    else if (Day == 4)
    {
        cout << "It is Wednseday!" << endl;
    }
    else if (Day == 5)
    {
        cout << "It is Thursday!" << endl;
    }
    else if (Day == 6)
    {
        cout << "It is Friday!" << endl;
    }
    else if (Day == 7)
    {
        cout << "It is Sunday!" << endl;
    }
    else
    {
        cout << "Wrong Number, Try Again!" << endl;
    }
}

int main()
{
    short int Day;
    ReadDay(Day);
    PrintDay(Day);

    return 0;
}

