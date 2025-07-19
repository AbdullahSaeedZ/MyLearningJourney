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

void LowercaseFirstLetters(string& str)
{
    bool IsFirstLetter = true;

    for (int i = 0; i < str.size(); i++)
    {

        if (str[i] != ' ' && IsFirstLetter)
            str[i] = tolower(str[i]);

        IsFirstLetter = (str[i] != ' ') ? false : true;

    }


}



int main()
{
    string str = ReadString("enter string:");

    LowercaseFirstLetters(str);

    cout << str << endl;


    return 0;
}