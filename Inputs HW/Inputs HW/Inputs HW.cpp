#include <iostream>
using namespace std;

int main()
{
	string UserName;
	string Age;
	string City;
	string Country;
	float MonthlySalary;
	char Gender;
	bool IsMarried;


	cout << "Enter Your Name:" << endl;
	cin >> UserName;

	cout << "Enter your Age:" << endl;
	cin >> Age;

	cout << "Enter your City Name:" << endl;
	cin >> City;

	cout << "Enter your Country Name:" << endl;
	cin >> Country;

	cout << "Enter your Monthly Salary:" << endl;
	cin >> MonthlySalary;

	cout << "Enter your Gender M or F:" << endl;
	cin >> Gender;

	cout << "If you are married, type 1 if not type 0:" << endl;
	cin >> IsMarried;

	cout << "******" << endl;
	cout << "Name: " << UserName << endl;
	cout << "Age: " << Age << endl;
	cout << "City: " << City << endl;
	cout << "Country: " << Country << endl;
	cout << "Monthly Salary: " << MonthlySalary << endl;
	cout << "Yearly salary: " << MonthlySalary * 12 << endl;
	cout << "Gender: " << Gender << endl;
	cout << "Married: " << IsMarried << endl;
	cout << "******" << endl;

	return 0;
}