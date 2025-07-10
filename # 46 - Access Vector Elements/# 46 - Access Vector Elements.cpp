#include <iostream>
#include <vector>
using namespace std;




int main()
{
	
	vector <int> Numbers = { 1, 2, 3, 4, 5 };

	//accessing elements using .at(i)

	cout << "\n\nAccess using .at(i):" << endl;
	cout << "Element at index 0: " << Numbers.at(0) << endl;
	cout << "Element at index 1: " << Numbers.at(1) << endl;
	cout << "Element at index 2: " << Numbers.at(2) << endl;
	cout << "Element at index 3: " << Numbers.at(3) << endl;
	cout << "Element at index 4: " << Numbers.at(04) << endl;

	// accessing using [i]

	cout << "\n\nAccess using [i]:" << endl;
	cout << "Element at index 0: " << Numbers[0] << endl;
	cout << "Element at index 1: " << Numbers[1] << endl;
	cout << "Element at index 2: " << Numbers[2] << endl;
	cout << "Element at index 3: " << Numbers[3] << endl;
	cout << "Element at index 4: " << Numbers[4] << endl;







	return 0;
}

