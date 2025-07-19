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

int CountCapitalLetters(string str)
{
    int Count = 0;

    for (int i = 0; i < str.length(); i++)
    {
        if (isupper(str[i]))
            Count++;
    }

    return Count;
}

int CountSmallLetters(string str)
{
    int Count = 0;

    for (int i = 0; i < str.length(); i++)
    {
        if (islower(str[i]))
            Count++;
    }

    return Count;
}


int main()
{
 
    string str = ReadString("enter a string:");

    cout << "\n\nString length: " << str.length() << endl;
    cout << "\nCapital letters count: " << CountCapitalLetters(str) << endl;
    cout << "\nSmall letters count: " << CountSmallLetters(str) << endl;





	return 0;
}

