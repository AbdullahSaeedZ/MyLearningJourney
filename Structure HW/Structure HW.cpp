#include <iostream>
using namespace std;


struct ClintInfo {

    string Name, City, Country, Married;
    short int Age, MonthlySalary;
    char Gender;

};


int main()
{
    
    ClintInfo Clint;
    Clint.Name;
    Clint.Age;
    Clint.City;
    Clint.Country;
    Clint.MonthlySalary;
    Clint.Gender;
    Clint.Married;
    
    cout << "type your Name:" << endl;
    cin >> Clint.Name;
    cout << "type your Age:" << endl;
    cin >> Clint.Age;
    cout << "type your City:" << endl;
    cin >> Clint.City;
    cout << "type your Country:" << endl;
    cin >> Clint.Country;
    cout << "type your Monthly Salary:" << endl;
    cin >> Clint.MonthlySalary;
    cout << "type your Gender:" << endl;
    cin >> Clint.Gender;
    cout << "are you Married ?:" << endl;
    cin >> Clint.Married;


    cout << "\nthe clint info is: \nName: " << Clint.Name << endl;
    cout << "Age: " << Clint.Age << endl;
    cout << "City: " << Clint.City << endl;
    cout << "Country: " << Clint.Country << endl;
    cout << "Monthly Salary: " << Clint.MonthlySalary << endl;
    cout << "Yearly Salary: " << Clint.MonthlySalary * 12 << endl;
    cout << "Gender: " << Clint.Gender << endl;
    cout << "Married: " << Clint.Married << endl;
    


    return 0;
}

