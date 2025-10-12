#include <iostream>
#include <cctype>
#include <string>
#include "MyLib.h"
using namespace MyLib;
using namespace std;

//// not perfect
//string RemovePunctInString(string str)
//{
//    for (short i = 0; i < str.length(); i++)
//    {
//        if (ispunct(str[i]))
//            str = str.erase(i, 1);  // once char is removed, the index will be shorter than original length then will cause the counter to jump and skip one index, debug when there is two punct right after each other.
//    }
//    
//    return str;
//}


string RemovePunctInString(string str)
{
    string New = "";

    for (short i = 0; i < str.length(); i++)
    {
        if (!ispunct(str[i]))
            New += str[i];
             
    }
    
    return New;
}

int main()
{
    string str = "welcome to Saudi,, Saudi is a nice country; it`s amazing.";

    cout << "string: " << endl;
    cout << str << endl;

    cout << "Punctuations removed:" << endl;
    cout << RemovePunctInString(str) << endl;





    return 0;
}

