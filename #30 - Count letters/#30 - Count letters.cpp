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

char ReadChar(string Message)
{
    char c = ' ';

    cout << Message << endl;
    cin >> c;

    return c;
}

int CountLetterInString(string str, char Letter)
{
    int Count = 0;

    for (int i = 0; i < str.length(); i++)
    {
        if (str[i] == Letter)
            Count++;
    }

    return Count;
}



int main()
{

    string str = ReadString("\nenter a string:");
    char c = ReadChar("\nenter a letter to count:");

    cout << "\nLetter " << c << " count in string is: " << CountLetterInString(str, c) << endl;
    





    return 0;
}