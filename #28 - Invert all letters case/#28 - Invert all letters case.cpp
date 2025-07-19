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


char InvertCharCase(char c)
{
    return (isupper(c)) ? tolower(c) : toupper(c);
}

string InvertAllLettersCase(string str)
{
    for (int i = 0; i < str.length(); i++)
    {
        str[i] = InvertCharCase(str[i]);
    }

    return str;
}

int main()
{
    string str = ReadString("enter a string to invert all letters:");

    cout << "\n\nstring after inverting all letters:\n" << InvertAllLettersCase(str) << endl;



    return 0;
}