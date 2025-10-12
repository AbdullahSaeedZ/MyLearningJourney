#include <iostream>
#include <string>
using namespace std;

string ReadName()
{
    string Name;

    cout << "Please enter your full name: " << endl;
    cin.ignore(0, '\n');
    getline(cin, Name);

    return Name;
}


void PrintName(string Name)
{
    cout << "Name: " << Name << endl;
}



int main()
{
    PrintName(ReadName());

    return 0;
}

