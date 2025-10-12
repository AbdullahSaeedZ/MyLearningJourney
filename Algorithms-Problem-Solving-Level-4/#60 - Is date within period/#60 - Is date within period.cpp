#include <iostream>
#include "dt.h"
using namespace std;
using namespace dt;


bool IsDateWithinPeriod(stPeriod Period, stDate Date)
{
    return  !(CompareTwoDates(Date, Period.StartDate) == enDateComparison::Before || CompareTwoDates(Date, Period.EndDate) == enDateComparison::After);
}


int main()
{
    
    stPeriod Period;
    cout << "Enter start date: " << endl;
    Period.StartDate = ReadDate();
    cout << "\nEnter end date: " << endl;
    Period.EndDate = ReadDate();

    cout << "\nEnter Date To check:" << endl;
    stDate Date = ReadDate();


    if (IsDateWithinPeriod(Period, Date))
        cout << "\nYes, date is within period" << endl;
    else
        cout << "\nNo, date is not within period" << endl;


    return 0;
}

