#include <iostream>
using namespace std;

struct stDate {
    short month = 0, day = 0, year = 0;
};

bool IsDate1BeforeDate2(stDate Date1, stDate Date2)
{
    return  (Date1.year < Date2.year) ? true : ((Date1.year == Date2.year) ? (Date1.month < Date2.month ? true : (Date1.month == Date2.month ? Date1.day < Date2.day : false)) : false);
}

bool IsDate1EqualToDate2(stDate Date1, stDate Date2)
{
    return (Date1.year == Date2.year) ? ((Date1.month == Date2.month) ? ((Date1.day == Date2.day) ? true : false) : false) : false;
}

bool IsDate1AfterDate2(stDate Date1, stDate Date2)
{
    return  (!IsDate1BeforeDate2(Date1, Date2) && !IsDate1EqualToDate2(Date1, Date2));
}

enum enDateComparison { Before = -1, Equal = 0, After = 1 };

enDateComparison CompareTwoDates(stDate Date1, stDate Date2)
{
    return (IsDate1AfterDate2(Date1, Date2)) ? enDateComparison::After : (IsDate1BeforeDate2(Date1, Date2) ? enDateComparison::Before : enDateComparison::Equal);
}

int main()
{
    
    stDate Date1;
    Date1.day = 1;
    Date1.month = 1;
    Date1.year = 2000;

    stDate Date2;
    Date2.day = 1;
    Date2.month = 1;
    Date2.year = 2022;

    cout << "\nCompare result = " << CompareTwoDates(Date1, Date2) << endl;
    
    
    
    return 0;
}

