
#include <iostream>
using namespace std;


int MySum(int a, int b)
{
	int s = 0;
	s = a + b;
	return s;
}

//step into: will move step by step 
//step over: when the line has a function for example, it will skip getting inside it and just apply the function without stepping into it
//step out: will step out of the breakpoint to the next one, or when accidently stepped into a function, you can step out which will execute then get out of the function

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

	c = MySum(a, b);
	cout << c;

	return 0;
}
