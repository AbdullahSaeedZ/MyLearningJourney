#include <iostream>
using namespace std;


// Destructor is the last method executed before the object is destructed.
// as we know once a function is executed and has done its purpose, it gets deleted from the memory stack (destructed), in the case of classes, destructor will run right before the object is finished.
// it is a clean up behavior, like doing a certain task at the end.

class clsPerson
{
public:

	clsPerson()
	{
		cout << "Im the constructor" << endl;
	}

	//use ~ (tilde) to create the destructor, and the same name of the class, Can not have parameters, can not create more than one destructor.
	~clsPerson()
	{
		cout << "Im the destructor" << endl;
	}

};


void Func1()
{
	// Person1 is created on the stack
	// Constructor runs when created, destructor runs when Func1 ends

	clsPerson Person1;

}


void Func2()
{
	// Dynamically allocate an object on the heap

	clsPerson* Test = new clsPerson;


	// At this point only the constructor runs.
   // The destructor will NOT run automatically when Func2 ends,
   // because the object is still alive in the heap.

   // To avoid memory leaks, we must delete it manually:

   // delete Test;
}

int main()
{
	// Stack allocation: constructor runs at start of scope, 
	// destructor runs at end of scope
	Func1();
	
	// for testing, func2 will dynamically allocate a new object in the heap using a pointer, this will make the object runs only the constructor, even though the compiler finished executing func2.
	Func2();
	
	// this means the object is still open in the heap and not yet destroyed, we need to use DELETE to ensure we destructe the object in the heap, this is just to explain the idea.


	return 0;
}

