#include <iostream>
#include <vector>
#include <string>
using namespace std;

struct stDate {
    short month = 0, day = 0, year = 0;
};

stDate StringToStDate(string str, string delim = "/")
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

    stDate Date;
    Date.day = stoi(vWords.at(0));
    Date.month = stoi(vWords.at(1));
    Date.year = stoi(vWords.at(2));


    return Date;
}

string stDateToString(stDate Date, string delim = "/")
{
    string str = "";

    str = to_string(Date.day) + delim + to_string(Date.month) + delim + to_string(Date.year);

    
    return str;
}

void PrintDate(stDate Date)
{
    cout << Date.day << "/" << Date.month << "/" << Date.year;
}

int main()
{
    
    string str = "31/3/2022";

    stDate Date = StringToStDate(str);
    
    cout << "\nstDate:" << endl;
    PrintDate(Date);

    cout << "\nstring date:" << endl;
    cout << stDateToString(Date) << endl;


    return 0;
}

