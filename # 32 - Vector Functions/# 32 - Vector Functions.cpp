#include <iostream>
#include <vector>
using namespace std;


int main()
{
   
	vector <int> vNumbers;

	vNumbers.push_back(10);
	vNumbers.push_back(20);
	vNumbers.push_back(30);
	vNumbers.push_back(40);
	vNumbers.push_back(50);
	vNumbers.push_back(60);
	vNumbers.push_back(70);

	// if we use clear() , then some function wont work like front and back , cuz vector is empty so there will be no elements to show and program will fail, better use IF to check emptiness.


	cout << "first element: " << vNumbers.front() << endl;
	cout << "last element: " << vNumbers.back() << endl;

	// to show the size (how many elements):
	cout << "size of vector: " << vNumbers.size() << endl;

	// to check if vector is empty or not:
	cout << "is vector empty: " << vNumbers.empty() << endl;

	// to show how many space in memory allocated for the vector:
	cout << "capacity of vector in memory: " << vNumbers.capacity() << endl << endl << endl;

	//to understand capacity more, vector handles capacity of elements in memory in a different way:

	vector <int> Test;

	for (int Counter = 1; Counter <= 10; Counter++)
	{
		Test.push_back(Counter);
		cout << "\ncapacity of vector in memory: " << Test.capacity() << endl;
		cout << "number in vector: " << Test.back() << endl;
	}

	//note that at first vector capacity of elements is 1, then when more added and limit is reached, the vector capacity will get bigger by more than 1.


	return 0;
}

