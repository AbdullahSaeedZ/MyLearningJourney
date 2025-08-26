#include<iostream>
#include<vector>
using namespace std;


class clsA
{
public:
	//Parameterized Constructor
	clsA(int value)
	{
		x = value;
	}

	int x;

	void Print()
	{
		cout << "The value of x=" << x << endl;
	}

};


int main()

{
	// now this is a vector that will contain saperate objects.
	vector <clsA> v1;

	short NumberOfObjects = 5;




	// No need to give each object a separate name when using a vector
	// You can access each object using its index and their order inside the vector
	// clsA(i) this is called a temporary object (cuz no name given) used to instantiate object then vector saves a copy then the temp object gets destroyed.

	// inserting a new object at the end of vector
	for (int i = 0; i < NumberOfObjects; i++)
	{
		

		v1.push_back(clsA(i)); //i is the value that constructor will take and put in x variable in each new object added to the vector.
	}

	// printing object content
	for (int i = 0; i < NumberOfObjects; i++) // or can use ranged for loop.
	{
		v1[i].Print(); // accessing Print function of [i] object in v1 vector.

	}

	return 0;

}
