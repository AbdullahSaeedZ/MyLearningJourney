#include <iostream>
#include <string>
#include <cctype>
using namespace std;

void Check(string s1, string s2)
{
    for (string i = s2.begin(); i != s2.end(); i++)
    {
        
        if (s2.find(s1) == string::npos)
        {
            cout << "Not found" << endl;
        }
        else
        {
            cout << "found at position: " << s2.find(s1) << endl;
        }
        
    }
}

int main()
{
    string s1 = "abs";
    string s2 = "fdsj abs";

    Check(s1, s2);
  

    return 0;
}
