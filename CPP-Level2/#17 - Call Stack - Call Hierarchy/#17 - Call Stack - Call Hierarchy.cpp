#include<iostream>
using namespace std;


//check the picture on Github to see explaination of call stack of functions.
//we can access and see call stack by right clicking on a function then a window will show up, you will see written calls to Function1 which means who called Function1

void Function4() 
{    
	cout << "Hi I'm function4 " << endl; 
}

void Function3() 
{   
	Function4();
}

void Function2() 
{    
	Function3(); 
}

void Function1() 
{    
	Function2();
} 

int main()
{
	Function1();

	return 0;
}