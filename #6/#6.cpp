#include <iostream>
using namespace std;

enum enNameOrder {FirstLast = 0, LastFirst = 1};

struct stFullName {

    string FirstName;
    string LastName;
};

stFullName ReadFullName()
{
    stFullName FullName;

    cout << "Enter your first name: " << endl;
    cin >> FullName.FirstName;
    cout << "Enter your last name: " << endl;
    cin >> FullName.LastName;

    return FullName;
}

string GetFullName(stFullName FullName, enNameOrder PrintOrder)
{

    string FullNameForm;

    if (PrintOrder)
    FullNameForm = FullName.LastName + ". " + FullName.FirstName;
    else 
    FullNameForm = FullName.FirstName + " " + FullName.LastName;

    return FullNameForm;

}

void PrintFullName(string GetFullName)
{
    cout << "Your Full Name is: " << GetFullName << endl;

}


int main()
{
    PrintFullName(GetFullName(ReadFullName(), FirstLast));

    return 0;
}

