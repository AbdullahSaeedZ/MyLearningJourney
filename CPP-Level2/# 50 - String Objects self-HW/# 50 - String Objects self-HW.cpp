#include <iostream>
#include <string>
#include <cctype>
using namespace std;

void Check(string s1, string s2)
{
    int all = 0;
    for (int i = 0; i != s2.length(); i++)
    {

        for (int j = 0; j != s1.length(); j++)
        {
            if (s2.at(i) == s1.at(j))
            {
                cout << "Letter " << s1.at(j) << " is at position " << s2.find(s2.at(i)) << " in s2." << endl;
                all++;
            }

        }

    }

    if (all == s1.length())
    {
        cout << "all letters of s1 are in s2" << endl;
    }
    else
        cout << "all letters of s1 are not in s2" << endl;

}

int main()
{
    string s1 = "abs";
    string s2 = "fdajbgsf";

    Check(s1, s2);


    return 0;
}
