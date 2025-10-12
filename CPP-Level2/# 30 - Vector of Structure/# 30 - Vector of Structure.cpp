#include <iostream>
#include "MyLib.h"
using namespace std;
using namespace MyLib;

struct stEmployees
{
    string FirstName, LastName;
    int Salary;
    
};


int main()
{
    vector <stEmployees> Employees;

    // since the push_back only accept the same type of the declared vector (in our case it is stEmployees) , we have to create another structed variable to be able to push info to the vector.
    stEmployees OneEmployeeInfo;


    OneEmployeeInfo.FirstName = "Abdullah";
    OneEmployeeInfo.LastName = "Alzahrani";
    OneEmployeeInfo.Salary = 15000;
    Employees.push_back(OneEmployeeInfo);
    // note here the push back is only taking a structure, we cant write push_back(Employee.FirstName = "Abdullah", ....) cuz that was a string. thats why we created another structered variable for only pushing.

    OneEmployeeInfo.FirstName = "Fawaz";
    OneEmployeeInfo.LastName = "Alzahrani";
    OneEmployeeInfo.Salary = 12000;
    Employees.push_back(OneEmployeeInfo);

    // vectors are using stack data structure so once we push , it will increase its size and save the new valuee and will not or over write the old ones.

    OneEmployeeInfo.FirstName = "Ziyad";
    OneEmployeeInfo.LastName = "Alzahrani";
    OneEmployeeInfo.Salary = 14000;
    Employees.push_back(OneEmployeeInfo);

    for (stEmployees& item : Employees) // Employees is an array (vector) so the item will look for structures in that array. 
    {
        cout << "\nFirst Name: " << item.FirstName << endl;
        cout << "Last Name: " << item.LastName << endl;
        cout << "Salary: " << item.Salary << endl;
    }

    return 0;
}



