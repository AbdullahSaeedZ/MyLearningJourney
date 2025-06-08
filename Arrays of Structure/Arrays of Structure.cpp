#include <iostream>
using namespace std;


struct stInfo {

    string FirstName;
    string LastName;
    int Age;
    string Phone;

};

void ReadInfo(stInfo &Persons)
{
    cout << "Enter your first name: " << endl;
    cin >> Persons.FirstName;
    cout << "Enter your last name: " << endl;
    cin >> Persons.LastName;
    cout << "Enter your Age: " << endl;
    cin >> Persons.Age;
    cout << "Enter your phone number: " << endl;
    cin >> Persons.Phone;
}

void PrintUser(stInfo Persons)
{
    cout << "*****************************" << endl;
    cout << "First name: " << Persons.FirstName << endl;
    cout << "Last name: " << Persons.LastName << endl;
    cout << "Age: " << Persons.Age << endl;
    cout << "phone number: " << Persons.Phone << endl;
    cout << "*****************************" << endl;
}
void ReadUsers(stInfo Persons[2])
{
    ReadInfo(Persons[0]);
    ReadInfo(Persons[1]);
}

void PrintUsersInfo(stInfo Persons[2])
{
    cout << "*****************" << endl;
    PrintUser(Persons[0]);
    cout << "*****************" << endl;
    PrintUser(Persons[1]);
}

int main()
{
     stInfo Persons[2];

     ReadUsers(Persons);
     PrintUsersInfo(Persons);
    
    

    return 0;
}

