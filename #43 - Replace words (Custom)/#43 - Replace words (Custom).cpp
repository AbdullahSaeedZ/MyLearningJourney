#include <iostream>
#include <string>
#include <cctype>
#include <vector>
using namespace std;

// this is a custom function that works like replace method, just to practice.

vector<string> SplitStringToVector(string str, string delim = " ")
{
    vector<string> vWords;

    short pos = 0;
    string sWord;

    while ((pos = str.find(delim)) != string::npos)
    {
        sWord = str.substr(0, pos);

        if (sWord != "")
            vWords.push_back(sWord);

        str.erase(0, pos + delim.length());
    }

    if (str != "")
        vWords.push_back(str);

    return vWords;
}

string LowercaseAllString(string str)
{
    for (int i = 0; i < str.length(); i++)
    {
        str[i] = tolower(str[i]);
    }

    return str;
}

string JoinToString(const vector<string>& vWords, string delim)
{
    string str = "";

    for (const string& word : vWords)
    {
        str = str + word + delim;
    }

    return str.substr(0, str.length() - delim.length());
}

string ReplaceWord(string str, string OldWord, string NewWord, bool MatchCase)
{
    vector<string> vWords = SplitStringToVector(str, " ");

    for (string& word : vWords)
    {
        if (MatchCase)
        {
            if (word == OldWord)
                word = NewWord;
        }
        else
        {
            if (LowercaseAllString(word) == LowercaseAllString(OldWord))
                word = NewWord;
        }
    }

    str = JoinToString(vWords, " ");

    return str;
}




int main()
{
    string str = "Welcome to Saudi and Saudi is a nice country";
    cout << str << endl;

    
    cout << "\nreplace with match case:" << endl;
    cout << ReplaceWord(str, "saudi", "UAE", true) << endl;

    cout << "\nreplace without match case:" << endl;
    cout << ReplaceWord(str, "saudi", "UAE", false) << endl;



    return 0;
}