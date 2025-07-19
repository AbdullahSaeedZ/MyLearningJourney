#include <iostream>
#include <string>
#include <vector>
using namespace std;

string ReadString(string Message)
{
    string str = "";

    cout << Message << endl;
    getline(cin, str);

    return str;
}

void Print1stLettersOfWords(string str)
{
    bool IsFirstLetter = true;

    for (int i = 0; i < str.size(); i++)
    {
        
        if (str[i] != ' ' && IsFirstLetter) // will run only if the it is first letter and it is a letter.
            cout << str[i] << endl;

        IsFirstLetter = (str[i] != ' ') ? false : true; // it will be false for all indexes till a new space comes then it will be true.
        
    }

}



int main()
{
    
    Print1stLettersOfWords(ReadString("enter string:"));




    return 0;
}

