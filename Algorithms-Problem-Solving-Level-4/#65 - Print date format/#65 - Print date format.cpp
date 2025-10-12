#include <iostream>
#include <vector>
#include "dt.h"
#include "in.h"
#include "str.h"
using namespace std;
using namespace str;
using namespace in;
using namespace dt;


string ReplaceExactWord(string str, string OldWord, string NewWord)
{
    short pos = 0;
    while ((pos = str.find(OldWord)) != string::npos)
    {

        str = str.replace(pos, OldWord.length(), NewWord);

    }

    return str;
}

string PrintDateFormat(stDate Date, string Format = "dd/mm/yyyy")
{
    string Formatted = "";
    Formatted = ReplaceExactWord(Format, "dd", to_string(Date.day));
    Formatted = ReplaceExactWord(Formatted, "mm", to_string(Date.month));
    Formatted = ReplaceExactWord(Formatted, "yyyy", to_string(Date.year));

    return Formatted;
}




int main()
{
    string strDate = ReadString("Enter Date dd/mm/yyyy : ");

    stDate Date = StringToStDate(strDate);

    cout << PrintDateFormat(Date, "dd-mm-yyyy") << endl;
    cout << PrintDateFormat(Date, "dd/mm/yyyy") << endl;
    cout << PrintDateFormat(Date, "dd,mm,yyyy") << endl;
    cout << PrintDateFormat(Date, "yyyy/mm/dd") << endl;



    return 0;
}

