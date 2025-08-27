#include <iostream>
#include "clsString.h"
using namespace std;


int main()
{
	
	clsString S1;
	S1.setStrValue("Fawaz koko");
	S1.Print1stLettersOfWords();
	

	clsString::Print1stLettersOfWords("Abdullah Saeed");
	cout << clsString::InvertLetterCase('h');
	

	cout << S1.CountLetterInString("abdullah", 'l', true);


	return 0;
}

