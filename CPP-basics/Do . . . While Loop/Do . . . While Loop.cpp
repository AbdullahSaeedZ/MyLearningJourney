#include <iostream>
using namespace std;


int main()
{
	
	// Do-While loop: first the code body of do is runing then the while condition is checked, if true then loop is starting, if false then exit.

	int Number;

	do
	{
		cout << "Enter a positive number: " << endl;
		cin >> Number;

	} while (Number < 0);


	return 0;
}

