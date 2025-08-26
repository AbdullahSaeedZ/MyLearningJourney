#include<iostream>
#include<vector>

using namespace std;

class clsA
{
public:

	// default constructor to use in the dynamic allocation
	clsA() {}

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
	short NumberOfObjects = 5;


	// Dynamically allocate an array in heap memory of Size 5 (NumberOfObjects) using new keyword

	 // saves 5 slots in heap for objects, we tell him its an array by using [] with a temporary object(no name given). 
	 // we didnt put constructor value here, our goal is just to save slots, so for this step we have constructor overloading (the default constructor) otherwise it wont work and will ask for values to pass.
	 // new , will take address of first slot and saves it in the pointer as the way to reach the array later.
	clsA* arrA = new clsA[NumberOfObjects];


	// calling the parameterized constructor for each index of array
	for (int i = 0; i < NumberOfObjects; i++) {
		arrA[i] = clsA(i);
	}





	// printing contents of array
	for (int i = 0; i < NumberOfObjects; i++) {
		arrA[i].Print();
	}

	delete[] arrA;



	return 0;

}
