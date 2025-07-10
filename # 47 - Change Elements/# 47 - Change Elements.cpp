#include <iostream>
#include <vector>
using namespace std;



int main()
{

	vector <int> Numbers = { 1, 2, 3, 4, 5 };

	cout << "\ninitial vector values : " << endl;

	// use const and & for better performance when printing
	for (const int& i : Numbers) 
	{
		cout << i << " ";
	}



	cout << "\n\nupdated vector values:" << endl;

	for (int& i : Numbers)
	{
		i = 20;
		cout << i << " ";
	}

	cout << "\n\nupdated vector values:" << endl;

	Numbers[0] = 99;
	Numbers[3] = 11;
	Numbers.at(4) = 32;

	for (const int& i : Numbers)
	{
		cout << i << " ";
	}

	cout << endl << endl;

	return 0;
}

