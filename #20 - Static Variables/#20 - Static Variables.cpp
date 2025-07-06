#include<iostream>
using namespace std;


// Variable Number here is a local variable and once the function is done the variable will be no longer exsisted. cuz it is not static.
// when we run the function many times, the result will be the same.
void MyFunc()
{ 
	int Number = 1;
	
	cout << "Value of Number: " << Number << "\n";
	
	Number ++; 
} 


// in the same function, if we make the variable static it will act similarly like a global variable, when the function fincishes, the variable will stil exist and when calling the same function again
// the value of the variable will be updated from the last function or last update on the static variable.
void MyStaticVariableFunc()
{
	static int Number = 1;

	cout << "Value of Number: " << Number << "\n";

	Number++;
}

int main()
{    
	MyFunc();
	MyFunc(); 
	MyFunc();

	cout << endl;
	
	MyStaticVariableFunc();
	MyStaticVariableFunc();
	MyStaticVariableFunc();
	
	return 0; 
}