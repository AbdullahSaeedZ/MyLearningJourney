#pragma warning(disable : 4996)
#include <iostream>
#include <fstream>
#include <ctime>
using namespace std;

int main()
{
    /* 
    int tm_sec; // seconds of minutes from 0 to 61  
    int tm_min; // minutes of hour from 0 to 59 
    int tm_hour; // hours of day from 0 to 24 
    int tm_mday; // day of month from 1 to 31 
    int tm_mon; // month of year from 0 to 11  
    int tm_year; // year since 1900 
    int tm_wday; // days since Sunday 
    int tm_yday; // days since January 1st 
    int tm_isdst; // hours of daylight savings time
    */


    time_t Seconds = time(0);

    tm* TimeStruct = localtime(&Seconds);

    cout << "Year: " << TimeStruct->tm_year + 1900 << endl;
    cout << "Month: " << TimeStruct->tm_mon + 1 << endl;
    cout << "Day of a month: " << TimeStruct->tm_mday << endl;
    cout << "Hour: " << TimeStruct->tm_hour << endl;
    cout << "Minutes: " << TimeStruct->tm_min << endl;
    cout << "Seconds: " << TimeStruct->tm_sec << endl;
    cout << "Week Day (Days since Sunday): " << TimeStruct->tm_wday << endl;
    cout << "Year Day (Days since Jan 1st): " << TimeStruct->tm_yday << endl;
    cout << "hours of daylight savings:" << TimeStruct->tm_isdst << endl;




    return 0;
}

