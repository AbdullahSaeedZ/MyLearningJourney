#include <iostream>
using namespace std;

struct stEmployeeInfo
{
    string Name;
    int Salary;
};

int main()
{
    stEmployeeInfo Employee1;
    stEmployeeInfo* p;
    p = &Employee1;

    Employee1.Name = "Abdullah";
    Employee1.Salary = 20000;

    cout << "structure members values using normal way:" << endl;
    cout << Employee1.Name << endl;
    cout << Employee1.Salary << endl;


    cout << "structure members values using pointers: " << endl;

    // accessing values of members using pointers:
    // it is done like this (*p).Name = "koko";   but for an easy way, the compiler convertes it to this syntax:
    p->Name = "koko";  


    cout << p->Name << endl;
    cout << p->Salary << endl;

    // review the addresses from the screen to better understand:
    // each member inside a structure will have different address
    cout << "\nAddress of employee structure using reference: " << &Employee1 << endl;  // the address of the structure will be the same address of first member (Name)
    cout << "Address of employee structure using reference: " << &Employee1.Name << endl;  // here address will be same as address of &Employee1
    cout << "Address of employee structure using reference: " << &Employee1.Salary << endl; // different address

    cout << "Address of employee structure using pointer  : " << p << endl;
    cout << "Address of employee structure using pointer  : " << &p->Name << endl;
    cout << "Address of employee structure using pointer  : " << &p->Salary << endl;


    return 0;
}
