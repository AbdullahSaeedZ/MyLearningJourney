#include <iostream>
using namespace std;


void ReadInputs(short int& Age, bool &License)
{
	string Answer; // here i want to save the answer of Driving license question

	cout << "Enter your Age: " << endl;
	cin >> Age;
	cout << "Type yes if you have a Driving license: " << endl;
	cin >> Answer;

	License = (Answer == "Yes" || Answer == "yes");   // here i converted the answer into boolen to be matched to the parameter.
}

void Check(short int Age, bool License)
{
	if ((Age > 21) && (License == true))
	{
		cout << "Congrats! you are hired." << endl;
	}
	else
	{
		cout << "Sorry, you are rejected" << endl;
	}

}
int main()
{
	
	short int Age;
	bool License;

	ReadInputs(Age, License);
	Check(Age, License);
	
	return 0;


}

