#include <iostream>
#include <string>
#include <cctype>
#include <vector>
using namespace std;

// using the overloading concept(polymorphism) where two function similar in name but different in signature (num, order and type of parameters). 


string JoinToString(const vector<string>& vWords, string delim)
{
    string str = "";

    for (const string& word : vWords)
    {
        str = str + word + delim;
    }

    return str.substr(0, str.length() - delim.length());
}

string JoinToString(string array[], short length, string delim)
{
    string str = "";

    for (short i = 0; i < length; i++)
    {
        str = str + array[i] + delim;
    }

    return str.substr(0, str.length() - delim.length());
}


int main()
{
    
    vector<string> vWords = { "Abdullah", "Saeed", "Alzahrani" };
    
    string array[] = { "Abdullah", "Saeed", "Alzahrani" };

    

    cout << "\nVector after join: " << endl;
    cout << JoinToString(vWords, "--") << endl;

    cout << "\nArray after join:" << endl;
    cout << JoinToString(array, 3, "**") << endl;

    return 0;
}