#include <iostream>
#include <string>
#include <cctype>
using namespace std;


short CountLetterInString(string str, char Letter, bool MatchCase = true)
{
    short Count = 0;
    
        for (short i = 0; i < str.length(); i++)
        {
            if (MatchCase)
            {
                if (tolower(str[i]) == tolower(Letter))
                    Count++;

            }
            else
            {
                if (str[i] == Letter)
                    Count++;
            }
        }

    return Count;
}

int main()
{
    string str = "Abdullah Alzahrani";
    cout << str << endl;

    char letter;
    cout << "enter a letter:" << endl;
    cin >> letter;

    cout << "\nLetter " << letter << " count = " << CountLetterInString(str, letter , false) << endl;
    cout << "\nLetter " << (char)toupper(letter) << " or " << (char)tolower(letter) << " count = " << CountLetterInString(str, letter, true) << endl;



    return 0;
}

