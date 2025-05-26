#include <iostream>
using namespace std;

int main()
{

    int TotalSeconds;

    cout << "Enter number of seconds: " << endl;
    cin >> TotalSeconds;

    int SecondsPerDay = 60 * 60 * 24;
    short int SecondsPerHour = 60 * 60;
    short int SecondsPerMinute = 60;

    short int NumberOfDays = floor(TotalSeconds / SecondsPerDay); //floor() is to round down the result and ignore the remaining number after decieml
    short int Remainder = TotalSeconds % SecondsPerDay; /* here we want to take the number after the decimel that we ignored
        earlier cuz it has all values ecxept Days,so we can use it to get houres and the other values.*/

    float NumberOfHours = floor(Remainder / SecondsPerHour);
    Remainder = Remainder % SecondsPerHour;

    short int NumberOfMinutes = floor(Remainder / SecondsPerMinute);
    Remainder = Remainder % NumberOfMinutes;

    short int NumberOfSeconds = Remainder;

    cout << NumberOfDays << ":" << NumberOfHours << ":" << NumberOfMinutes << ":" << NumberOfSeconds << endl;
    



    return 0;
}
