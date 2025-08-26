#include<iostream>
using namespace std;

class clsA
{

public:
	int x;

	void Print()
	{
		cout << "The value of x=" << x << endl;
	}

};


//object sent by value, any update will not be reflected on the original object, and a copy will be created.
void Fun1(clsA A1)
{

	A1.x = 100;
}


//object sent by reference, any update will be reflected on the original object
void Fun2(clsA& A1)
{

	A1.x = 200;
}


int main()

{
	clsA A1;

	A1.x = 50;
	cout << "\nA.x before calling function1: \n";
	A1.Print();


	//Pass by value, object will not be affected.
	Fun1(A1);
	cout << "\nA.x after calling function1 byVal: \n";
	A1.Print();

	//Pass by value, object will be affected.
	Fun2(A1);
	cout << "\nA.x after calling function2 byRef: \n";
	A1.Print();

	return 0;

}

