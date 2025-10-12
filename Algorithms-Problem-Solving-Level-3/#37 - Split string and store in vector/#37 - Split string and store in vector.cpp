#include <iostream>
#include <string>
#include <cctype>
#include <vector>
using namespace std;


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

void PrintVectorTokens(vector <string>& vWords) // token is like a piece, three words are three tokens.
{
    cout << "Tokens = " << vWords.size() << endl;
    for (string& item : vWords)
    {
        cout << item << endl;
    }
}

int main()
{

    string str = "Abdullah-Saeed---Alzahrani";
    cout << str << endl;


    vector<string> vWords = SplitStringToVector(str, "-");
    PrintVectorTokens(vWords);
    

    return 0;
}

