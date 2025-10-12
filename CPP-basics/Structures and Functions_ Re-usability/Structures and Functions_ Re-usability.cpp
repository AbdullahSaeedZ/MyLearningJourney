#include <iostream>
#include <string>
using namespace std;

// the project is an info card where user enters his info then the card info is printed

struct stInfo
{
    string Name;
    short int Age;
    string City;
    string Country;
    int MonthlySalary;
    string Gender;
    string IsMarried;
};

void ReadInputs(stInfo &Info)
{
    cout << "Enter your name: " << endl;
    cin.ignore(0, '\n');
    getline(cin, Info.Name);

    cout << "Enter your age: " << endl;
    cin >> Info.Age;

    cout << "Enter your city: " << endl;
    cin >> Info.City;

    cout << "Enter your country: " << endl;
    cin >> Info.Country;

    cout << "Enter your monthly salary: " << endl;
    cin >> Info.MonthlySalary;

    cout << "Enter your gender: " << endl;
    cin >> Info.Gender;

    cout << "Are you Married ?" << endl;
    cin >> Info.IsMarried;

}

void PrintResults(stInfo Info)
{
    cout << "*************" << endl;
    cout << "Name: " << Info.Name << endl;
    cout << "Age: " << Info.Age << endl;
    cout << "City: " << Info.City << endl;
    cout << "Country: " << Info.Country << endl;
    cout << "Monthly Salary: " << Info.MonthlySalary << endl;
    cout << "Yearly Salary: " << Info.MonthlySalary * 12 << endl;
    cout << "Gender: " << Info.Gender << endl;
    cout << "Married: " << Info.IsMarried << endl;
    cout << "*************" << endl;
    cout << endl << endl;
}

int main()
{
    
    stInfo Person1Info;
    ReadInputs(Person1Info);
    PrintResults(Person1Info);


    // reusability is when we have the procedures ready with structures so we can re use them whenever we need to add more users info:

    stInfo Person2Info;
    ReadInputs(Person2Info);
    PrintResults(Person2Info);

    return 0;
}

