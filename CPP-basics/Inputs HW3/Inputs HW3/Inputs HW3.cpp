#include <iostream>
using namespace std;

int main()

{
	short int Age;

	cout << "Enter Your Age:";
	cin >> Age;

	short int FutureAge = Age + 5;

	cout << "After 5 years you will be " << FutureAge << " years old." << endl;


	return 0;
}