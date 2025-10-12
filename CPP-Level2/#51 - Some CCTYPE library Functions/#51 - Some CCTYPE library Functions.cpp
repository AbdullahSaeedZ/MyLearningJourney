#include <iostream>
#include <string>
#include <cctype>
using namespace std;

// using <cctype> functions to validate string characters.

int main()
{
	char x;
	char y;

	x = toupper('a');
	y = tolower('B');

	cout << "converting a to A: " << x << endl;
	cout << "converting B to b: " << y << endl;

	// Digits (A to Z)
	// returns zero if not, and non zero means yes
	cout << "is the letter uppercase: " << isupper(x) << endl;

	// lower case (a to z)
	// returns zero if not, and non zero means yes
	cout << "is the letter lowercase: " << islower(y) << endl;

	// Digits (0 to 9)
	// returns zero if not, and non zero means yes
	cout << "is the char digit: " << isdigit(x) << endl;


	// punctuation characters are !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~
	// returns zero if not, and non zero means yes
	cout << "is the char punctuation: " << ispunct(x) << endl;





	return 0;
}

