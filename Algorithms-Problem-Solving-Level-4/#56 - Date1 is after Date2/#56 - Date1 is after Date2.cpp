#include <iostream>
using namespace std;

struct stDate {
	short month = 0, day = 0, year = 0;
};

int ReadPositiveNumber(string Message)
{
	int Number = 0;
	do
	{
		cout << Message << endl;
		cin >> Number;

		if (cin.fail())
		{
			// if other than numbers entered system will fail.
			cin.clear();                // to clear the failure
			cin.ignore(10000, '\n');    // to ignore what was entered before, to clean the buffer
			cout << "Invalid input! Please enter a number." << endl;
			continue;
		}

	} while (Number <= 0);

	return Number;
}

stDate ReadDate()
{
	stDate Date;
	Date.day = ReadPositiveNumber("Enter Day:");
	Date.month = ReadPositiveNumber("Enter Month:");
	Date.year = ReadPositiveNumber("Enter year:");

	return Date;
}

bool IsDate1BeforeDate2(stDate Date1, stDate Date2)
{
	return  (Date1.year < Date2.year) ? true : ((Date1.year == Date2.year) ? (Date1.month < Date2.month ? true : (Date1.month == Date2.month ? Date1.day < Date2.day : false)) : false);
}

bool IsDate1EqualToDate2(stDate Date1, stDate Date2)
{
	return (Date1.year == Date2.year) ? ((Date1.month == Date2.month) ? ((Date1.day == Date2.day) ? true : false) : false) : false;
}

// reuse previous functions to make new functions instead of creatring new code and logic from zero
bool IsDate1AfterDate2(stDate Date1, stDate Date2)
{
	return  (!IsDate1BeforeDate2(Date1, Date2) && !IsDate1EqualToDate2(Date1, Date2));
}


int main()
{
	cout << "Date1: " << endl;
	stDate Date1 = ReadDate();
	cout << "\n";
	cout << "Date2: " << endl;
	stDate Date2 = ReadDate();

	if (IsDate1AfterDate2(Date1, Date2))
		cout << "Date 1 is After Date 2" << endl;
	else
		cout << "Date 1 is not after Date 2" << endl;


	return 0;
}