#include <iostream>
#include <string>
#include <cctype>
using namespace std;

string TrimLeft(string str)
{
    for (short i = 0; i < str.length(); i++)
    {
        if (str[i] != ' ')
            return str.substr(i, str.length() - 1);
    }

    return str;
}

string TrimRight(string str)
{
    for (short i = str.length() -1; i >= 0; i--)  // since length return number of chars starting from 1 not 0, so we put - 1
    {
        if (str[i] != ' ')
            return str.substr(0, i + 1);  // substr(index, how many chars(not index))
    }

    return str;
}

string Trim(string str)
{
    str = TrimLeft(str);
    str = TrimRight(str);

    return str;
}


int main()
{
    string str = "          Abdullah Alzahrani          ";
    cout << "string     : " << str << endl;

    cout << "Trim Left  : " << TrimLeft(str) << endl;
    cout << "Trim Right : " << TrimRight(str) << "." << endl;
    cout << "Trim Left  : " << Trim(str) << endl;





    return 0;
}

