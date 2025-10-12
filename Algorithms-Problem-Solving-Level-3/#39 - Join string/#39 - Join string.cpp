#include <iostream>
#include <string>
#include <cctype>
#include <vector>
using namespace std;


void PrintVectorTokens(vector <string>& vWords) // token is like a piece, three words are three tokens.
{
    cout << "Tokens = " << vWords.size() << endl;
    for (string& item : vWords)
    {
        cout << item << endl;
    }
}

//my solution

//string JoinVectorToString(const vector<string>& vWords, string delim)
//{
//    string str = "";
//
//    for (const string &word : vWords)
//    {
//        str.append(word);
//        if(word != vWords.back())
//            str.append(delim);
//    }
//
//    return str;
//}

string JoinVectorToString(const vector<string>& vWords, string delim)
{
    string str = "";
    
        for (const string &word : vWords)
        {
            str = str + word + delim;
        }
    
        return str.substr(0, str.length() - delim.length());
}

int main()
{

    
    cout << "Vector elements: " << endl;
    vector<string> vWords = { "Abdullah", "Saeed", "Alzahrani"};
    PrintVectorTokens(vWords);

    string JoinedStr = JoinVectorToString(vWords, "--");
    
    cout << "\nstring after join: " << endl;
    cout << JoinedStr << endl;


    return 0;
}