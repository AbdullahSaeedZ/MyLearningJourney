#include <iostream>
using namespace std;

int main()
{

	string Name = "Abdullah Alzahrani";
	short int Age = 27;   /* using int here is not professional in memory usage cuz it has a big rang of data and
	im only using a number that will not exceed 100 (age) so we should use short int */
	string City = "Dammam";
	string Country = "KSA";
	float MonthlySalary = 5000; // i wrote int at first then i changed it to float cuz salaries have deciemls ex: 6.549 SAR. better use float.
	float Yearly_Salary = 60000; // we can use cout << MonthlySalary * 12 << endl; instead of creating a new variable for that.
	char Gender = 'M';
	bool IsMarried = true;

	cout << "*********\n";
	cout << "Name: " << Name << endl;
	cout << "City: " << City << endl;
	cout << "Country: " << Country << endl;
	cout << "Monthly Salary: " << MonthlySalary << endl;
	cout << "Yearly Salary: " << Yearly_Salary << endl;
	cout << "Gender: " << Gender << endl;
	cout << "Married: " << IsMarried << endl;
	cout << "**********\n" << endl;


	short int x = 20; // or in one variable int x = 20, y = 30, z = 10;
	short int y = 30;
	short int z = 10;
	short int Total = x + y + z;

	cout << x << " +\n" << y << " +\n" << z << endl;
	cout << "----------------" << endl;
	cout << "Total = " << Total << endl;

	return 0;
}


