#include <iostream>
#include <vector>
#include "C:\Users\asz14\Documents\CPP-Level2\MyLibrary\MyLib.h"
using namespace std;
using namespace MyLib;

struct stEmployees
{
    string FirstName, LastName;
    int Salary, Age;
};

void ReadEmployeeInfo(vector <stEmployees>& AllEmployees)
{
    int Counter = 1;
    stEmployees OneEmployee;
    string Answer = " ";

    do
    {
        cout << "\n\nEnter info of Employee " << Counter << " :" << endl;
        cout << "First Name: ";
        cin >> OneEmployee.FirstName;
        cout << "Last Name: ";
        cin >> OneEmployee.LastName;
        cout << "Salary: ";
        cin >> OneEmployee.Salary;
        cout << "Age: ";
        cin >> OneEmployee.Age;

        AllEmployees.push_back(OneEmployee);
        Counter++;
        Answer = AskY_N("Do you want to add more employees? Y/N:");

    } while (Answer == "Y" || Answer == "y");
}

void PrintEmployeeInfo(vector <stEmployees>& AllEmployees)
{
    int Counter = 1;
    for (stEmployees& Employee : AllEmployees)
    {
        cout << "\n\nInfo of Employee " << Counter << " :" << endl;
        cout << "First Name: " << Employee.FirstName << endl;
        cout << "Last Name: " << Employee.LastName << endl;
        cout << "Salary: " << Employee.Salary << endl;
        cout << "Age: " << Employee.Age << endl;

        Counter++;
    }
}

int main()
{
    
    vector <stEmployees> AllEmployees;

    ReadEmployeeInfo(AllEmployees);
    PrintEmployeeInfo(AllEmployees);



    return 0;
}

