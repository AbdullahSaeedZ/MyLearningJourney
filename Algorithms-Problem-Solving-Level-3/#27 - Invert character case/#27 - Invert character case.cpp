#include <iostream>
#include <string>
#include <cctype>
using namespace std;

char ReadChar(string Message)
{
    char c = ' ';

    cout << Message << endl;
    cin >> c;

    return c;
}

char InvertCharCase(char c)
{
    return (isupper(c)) ? tolower(c) : toupper(c);
}

int main()
{
    char c = ReadChar("enter a character to invert case:");

    cout << "Char after inverting:\n" << InvertCharCase(c) << endl;



    return 0;
}

