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


bool IsDate1MoreThanDate2(stDate Date1, stDate Date2)
{
	if (Date1.year > Date2.year)
		return true;
	else if (Date1.year == Date2.year)
	{
		if (Date1.month > Date2.month)
			return true;
		else if (Date1.month == Date2.month)
		{
			if (Date1.day > Date2.day)
				return true;
		}
	}

	return false;
}


// this is in one line but hard to read
//bool IsDate1MoreThanDate2(stDate Date1, stDate Date2)
//{
//	return (Date1.year > Date2.year) ? true : (Date1.year == Date2.year) ? ((Date1.month > Date2.month) ? true : ((Date1.month == Date2.month) ? ((Date1.day > Date2.day) ? true : false ) : false)): false;
//}

int main()
{
	cout << "Date1: " << endl;
	stDate Date1 = ReadDate();
	cout << "\n";
	cout << "Date2: " << endl;
	stDate Date2 = ReadDate();

	if (IsDate1MoreThanDate2(Date1, Date2))
		cout << "Date 1 is more than Date 2" << endl;
	else
		cout << "Date 1 is less than Date 2" << endl;


    return 0;
}

