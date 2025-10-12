#include <iostream>
#include <string>
#include <cctype>
#include "MyLib.h"
using namespace std;
using namespace MyLib;

// my solution

//string ReplaceWord(string str, string OldWord, string NewWord)
//{
//    short pos = 0;
//    while ((pos = str.find(OldWord)) != string::npos)
//    {
//        str.erase(pos, OldWord.length());
//        str.insert(pos, NewWord);
//    }
//        
//    return str;
//}


// using replace method:
string ReplaceWord(string str, string OldWord, string NewWord)
{
    short pos = 0;
    while ((pos = str.find(OldWord)) != string::npos)
    {

        str = str.replace(pos, OldWord.length(), NewWord);

    }

    return str;
}

int main()
{
    string str = "welcome to saudi, saudi is a nice country";
    cout << str << endl;

    str = ReplaceWord(str, "Saudi", "UAE");
    cout << "\nstring after replaceing:" << endl;
    cout << str << endl;
    
    
    
    return 0;
}

