#include <iostream>
using namespace std;

int main()
{

	string Name = "Abdullah Alzahrani";
	int Age = 27;   /* using int here is not professional in memory usage cuz int can have a lot of values and
	im only using a number that will not exceed 100 (age) so we should use */
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


	int x = 20; // or in one variable int x = 20, y = 30, z = 10;
	int y = 30;
	int z = 10;
	int Total = x + y + z;

	cout << x << " +\n" << y << " +\n" << z << endl;
	cout << "----------------" << endl;
	cout << "Total = " << Total << endl;

	return 0;
}


