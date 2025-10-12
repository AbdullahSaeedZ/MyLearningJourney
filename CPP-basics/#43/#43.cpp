#include <iostream>
using namespace std;

void ReadInputs(int& A)
{
    cout << "Enter number of seconds: " << endl;
    cin >> A;
}

struct TimeFormat{

    int Days;
    int Hours;
    int Minutes;
    int Seconds;

};

TimeFormat CalculateTime(int TotalSeconds)  // used a structure cuz we want to store values of the function inside the members of this structure.
{
    int SecondsPerDay = 60 * 60 * 24;
    short int SecondsPerHour = 60 * 60;
    short int SecondsPerMinute = 60;

    TimeFormat Output; // we create this variable so we store values inside the structure members, so we can return the Output varable only

    Output.Days = floor(TotalSeconds / SecondsPerDay);       //floor() is to round down the result and ignore the remaining number after decieml
    short int Remainder = TotalSeconds % SecondsPerDay;      /* here we want to take the number after the decimel that we ignored
                                                             earlier cuz it has all values ecxept Days,so we can use it to get houres and the other values.*/


    Output.Hours = floor(Remainder / SecondsPerHour);
    Remainder = Remainder % SecondsPerHour;
                                                        // we took number of hours then removed hours from total seconds


    Output.Minutes = floor(Remainder / SecondsPerMinute);
    Remainder = Remainder % SecondsPerMinute;
                                                         // we took number of Minutes then removed Minutes from total seconds

    Output.Seconds = Remainder;
                                                        // since we removed them all, remaining is seconds.

    return Output;                            //this is why we created a structure, cuz we can only return one value and we need 4 values and this did the job.
}

void ShowResult(TimeFormat Result)
{
    cout << Result.Days << ":" << Result.Hours << ":" << Result.Minutes << ":" << Result.Seconds << endl;

}
int main()
{

    int TotalSeconds;
    ReadInputs(TotalSeconds);

    TimeFormat Result = CalculateTime(TotalSeconds);   //the function will do its job and save its members values inside the Result members value.

    ShowResult(Result);  //since Result has members values then this procedure will print those members values 



    return 0;
}
