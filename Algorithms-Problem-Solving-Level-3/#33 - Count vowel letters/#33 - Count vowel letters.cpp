#include <iostream>
#include <string>
#include <cctype>
using namespace std;


bool IsVowel(char letter)
{
    char v = tolower(letter);
    return ((v == 'a') || (v == 'e') || (v == 'i') || (v == 'o') || (v == 'u'));
}

short CountVowelInString(string str)
{
    short count = 0;

    for (short i = 0; i < str.length(); i++)
    {
        if (IsVowel(str[i]))
            count++;
    }

    return count;
}


int main()
{
    string str = "Abdullah Saeed";
    cout << str << endl;
    
    cout << "\nNumber of vowels is: " << CountVowelInString(str) << endl;
   


    return 0;
}