#include <iostream>
#include <string>
#include <cctype>
using namespace std;

struct stCharInfo 
{

    int NumUpper = 0, NumLower = 0, CountNum = 0, CountPunct = 0, Length = 0;
};

string AskPassword(string Message, short From, short To)
{
    string Pass = " ";
    do
    {
        cout << Message << endl;
        cin >> Pass;

       

    } while (Pass.length() < From || Pass.length() > To);

    return Pass;
}

stCharInfo GetCharInfo(string Pass)
{
    stCharInfo Info;
    Info.Length = Pass.length();

    for (int i = 0; i < Pass.length(); i++)
    {
        if (isupper(Pass.at(i)))
            Info.NumUpper++;
        
        else if (islower(Pass.at(i)))
            Info.NumLower++;

        else if (ispunct(Pass.at(i)))
            Info.CountPunct++;

        if (isdigit(Pass.at(i)))
            Info.CountNum++;

        
    }

    return Info;
}

void ShowInfo(stCharInfo Info)
{
    cout << "\n\nNumbers: " << Info.CountNum << endl;
    cout << "Punctuations: " << Info.CountPunct << endl;
    cout << "Lowercase letters: " << Info.NumLower << endl;
    cout << "Uppercase letter: " << Info.NumUpper << endl;
    cout << "Length: " << Info.Length << endl;
}


void ValidatePassword(stCharInfo Info)
{
    ShowInfo(Info);

    if (Info.CountNum >= 1 && Info.CountPunct >= 1 && Info.NumLower >= 1 && Info.NumUpper >= 1 && Info.Length >= 8)
        cout << "\nStrong Password" << endl;
    else
        cout << "\nWeak Password!!" << endl;
}

int main()
{
    

    ValidatePassword(GetCharInfo(AskPassword("Enter a password (15 Max)", 1, 15)));


    return 0;
}

