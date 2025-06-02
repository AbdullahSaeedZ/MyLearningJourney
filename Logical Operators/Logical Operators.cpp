#include <iostream>
using namespace std;

int main()
{

	bool A = 1, B = 0;

	cout << (A && B) << endl; // we used the logical operator AND which is && and output will be false 
	cout << (A || B) << endl; // we used the logical operator OR which is || and output will be true 
	cout << !A << endl; // we used the logical operator NOT which is ! and output will be false
	cout << !B << endl; // we used the logical operator NOT which is ! and output will be true
	cout << !(A && B) << endl; // we used NOT on the AND operator so output will be true
	cout << !(A || B) << endl; // we used NOT on the OR operator so output will be false



	return 0;
}

