#include <iostream>
#include <string>
#include <cctype>
using namespace std;

string ReadString(string Message)
{
    string str = "";

    cout << Message << endl;
    getline(cin, str);

    return str;
}

void UppercaseAllLetters(string& str)
{
    for (int i = 0; i < str.length(); i++)
    {
        str[i] = toupper(str[i]);
    }
}

void LowercaseAllLetters(string& str)
{
    for (int i = 0; i < str.length(); i++)
    {
        str[i] = tolower(str[i]);
    }
}

int main()
{
    
    string str = ReadString("Enter a string:");

    UppercaseAllLetters(str);
    cout << "\n\nstring in all uppercase letters:" << endl;
    cout << str << endl;

    LowercaseAllLetters(str);
    cout << "\n\nstring in all lowercase letter:" << endl;
    cout << str << endl;


    return 0;
}
