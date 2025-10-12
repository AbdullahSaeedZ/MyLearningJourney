#include <iostream>
using namespace std;


int MySum(int a, int b)
{
	int s = 0;
	s = a + b;
	return s;
}


//<-- this red point is called a breakpoint, the program will run to this point then will stop then we start tracing line by line and see values to find any error, to proceed to the next line, we press F11 
// after the program stops at the breakpoint, a yellow arrow will appear to indicate that the current line is not yet executed and waiting to press f11 to run.


// we can put more than one breakpoint, after the first point while we trace, we can press F5 to skip the tracing and run the rest of the code to the next breakpoint

int main()
{
	int arr1[5] = { 200,100,50,25,30 };
	int a, b, c;
	a = 10;
	b = 20;
	a++;
	++b;
	c = a + b;
	cout << a << endl;
	cout << b << endl;
	cout << c << endl;

	for (int i = 1; i <= 5; i++)
	{
		cout << i << endl;
		a = a + a * i;
	}

	// we can put more than one breakpoint, after the first point while we trace, we can press F5 to skip the tracing and run the rest of the code to the next breakpoint
	
	c = MySum(a, b);
	cout << c;

	return 0;
}
	// in debug menu, we can disable all breakpoints then we can run the program without stopping at the points, better than deleting the points when we might need them later in the same place.