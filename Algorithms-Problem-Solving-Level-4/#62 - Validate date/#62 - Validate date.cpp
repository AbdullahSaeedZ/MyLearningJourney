#include <iostream>
#include "dt.h"
using namespace std;
using namespace dt;


bool IsValidDate(stDate Date)
{
    return  ((Date.year >= 1) && (Date.month >= 1 && Date.month <= 12 ) && (Date.day >= 1 ) && (Date.day <= NumOfMonthDays(Date.year, Date.month)));
}



int main()
{
    stDate Date = ReadDate();

    if (IsValidDate(Date))
        cout << "\nYes, Date is valid" << endl;
    else
        cout << "\nNo, Date is not valid" << endl;
    



    return 0;
}