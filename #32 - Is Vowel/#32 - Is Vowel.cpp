#include <iostream>
#include <string>
#include <cctype>
using namespace std;


bool IsVowel(char letter)
{
    char v = tolower(letter);
    return ((v == 'a') || (v == 'e') || (v == 'i') || (v == 'o') || (v == 'u')) ;
}

int main()
{
    char letter = ' ';
    cout << "enter a character:" << endl;
    cin >> letter;

    if (IsVowel(letter))
        cout << "yes " << letter << " is a vowel" << endl;
    else
        cout << "No " << letter << " is not a vowel" << endl;



    return 0;
}

