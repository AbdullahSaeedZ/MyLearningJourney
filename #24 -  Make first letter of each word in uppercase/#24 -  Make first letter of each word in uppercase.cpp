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

void UppercaseFirstLetters(string str)
{
    bool IsFirstLetter = true;

    for (int i = 0; i < str.size(); i++)
    {

        if (str[i] != ' ' && IsFirstLetter)
            str[i] = toupper(str[i]);

        IsFirstLetter = (str[i] != ' ') ? false : true; 

    }

    cout << str << endl;
}



int main()
{

    UppercaseFirstLetters(ReadString("enter string:"));




    return 0;
}