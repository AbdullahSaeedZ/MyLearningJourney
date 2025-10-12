#include <iostream>
#include <string>
#include <cctype>
using namespace std;


bool IsVowel(char letter)
{
    char v = tolower(letter);
    return ((v == 'a') || (v == 'e') || (v == 'i') || (v == 'o') || (v == 'u'));
}

void PrintVowelsInString(string str)
{
    for (int i = 0; i < str.length(); i++)
    {
        if (IsVowel(str[i]))
            cout << str[i] << "   ";
    }
}

int main()
{
    string str = "Abdullah Saeed";
    cout << str << endl;


    cout << "\nVowels in string are: ";
    PrintVowelsInString(str);


    return 0;
}