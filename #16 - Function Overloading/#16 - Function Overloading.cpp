#include<iostream>
using namespace std;

// Function overloading is a type of polymorphism. Polymorphism means (literally “many forms”) which lets you use the same name for different behaviors.
// Function Overloading is to use one name for multiple functions.
// when calling the function, the compiler will choose which function to execute based on ONLY two things: 1- Number of parameters  2- Type of these parameters
// these two will determine which function to be used, regardless of the naming of parameters, only the number and type of parameters.
// not all languages support overloading.


double  MySum(double a, double b) 
{
	return (a + b);
} 

int MySum(int a, int b)
{ 
	return (a + b); 
} 

int MySum(int a, int b, int c)
{ 
	return (a + b + c); 
} 

int MySum(int a, int b, int c, int d)
{ 
	return (a + b + c + d);
} 

int main()
{    
	cout << MySum(10, 20) << endl;
	cout << MySum(10.1, 20.1) << endl;
	cout << MySum(10, 20, 30) << endl;
	cout << MySum(10, 20, 30, 40) << endl;

	MySum()
	
	return 0; 
}