#include <iostream>
#include <string>
using namespace std;

void UserName()
{
    string Name;
    cout << "enter your name: " << endl;
    cin.ignore(0, '\n');
    getline(cin, Name);
     
    cout << Name << endl;
}

int main()
{
    UserName();

    return 0;
}

