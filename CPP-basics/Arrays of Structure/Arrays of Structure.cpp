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

void ReadUsers(stInfo Persons[100], int &Length)
{
    cout << "How many Persons ?" << endl;
    cin >> Length;

    for (int Counter = 0; Counter < Length; Counter++)
    {
        cout << "Enter info of Person " << Counter + 1 << " :" << endl;
        ReadInfo(Persons[Counter]);
    }
        
    
}

void PrintUsersInfo(stInfo Persons[2], int Length)
{
   
    for (int Counter = 0; Counter < Length; Counter++)
    {
        cout << "Person " << Counter + 1 << " Info :" << endl;
        PrintUser(Persons[Counter]);

    }
}

int main()
{
     stInfo Persons[100];
     int Length = 0;

     ReadUsers(Persons, Length);
     PrintUsersInfo(Persons, Length);
    
    

    return 0;
}

