#include <iostream>
#include "dt.h"
using namespace std;
using namespace dt;


short GetPeriodsOverlapDays(stPeriod Period1, stPeriod Period2)
{
    if (!IsOverlapPeriod(Period1, Period2))
        return 0;
    // take the farest start date of the two periods
    stDate Start = (CompareTwoDates(Period1.StartDate, Period2.StartDate) == enDateComparison::Before) ? Period2.StartDate : Period1.StartDate;

    // take the closest end date of the two periods
    stDate End = (CompareTwoDates(Period1.EndDate, Period2.EndDate) == enDateComparison::Before) ? Period1.EndDate : Period2.EndDate;

    return PeriodLengthInDays({ Start, End });
}



int main()
{
    
    stPeriod Period1;
    cout << "\nEnter start date:" << endl;
    Period1.StartDate = ReadDate();
    cout << "\nEnter End date:" << endl;
    Period1.EndDate = ReadDate();

    stPeriod Period2;
    cout << "\nEnter start date:" << endl;
    Period2.StartDate = ReadDate();
    cout << "\nEnter End date:" << endl;
    Period2.EndDate = ReadDate();

    cout << "\nOverlap days: " << GetPeriodsOverlapDays(Period1, Period2) << endl;


    return 0;
}

