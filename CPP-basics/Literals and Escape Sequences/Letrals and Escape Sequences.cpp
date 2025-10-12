// Letrals are values used to be stored in the memory like letters, numbers and else.
//example is 5 , 3.5 , 'b' , "Abdullah" and so on. we cant assign values to these terms, they arevalues themselves! there are types of these letrals.

// one type of letrals is Escape sequnces like \n which means a new line. they comr after a backslash like \t or \a or \\ and many more.

#include <iostream>

using namespace std;

int main()
{
	cout << "M1\M2\n";
	// it will print M1M2 because the complier will read the backslash as undefined Escape sequence, we want backslash? we write \\ and will print M1\M2

	cout << "M1\\M2\n";
	// here it will be read as backslash

	cout << "M1\tM2" << endl;
	// here the \t is a tab which will give a space.

	cout << "my name is \"Abdullah\" ";
	// the \" will give a double qutation

	cout << "\a";
	// the \a will make a bell sound

	return 0;
}