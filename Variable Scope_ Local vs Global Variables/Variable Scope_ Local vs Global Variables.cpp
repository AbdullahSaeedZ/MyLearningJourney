#include <iostream>
using namespace std;
// variable scope means where it is created and used and it is limited by that.


int X = 100;      //this is a Global variable cuz it is created outside any function and can be called anywhere.

void MyAge()
{
    short int X = 100;   // this is a local variable and his scope is inside this procedure only.
                         // the name is same as the global variable (X) but it is not an issue cuz they have different scopes.
    cout << X << endl;
}


int main()
{
    short int X = 200; // this one is also a local variable so no issue if i name it X as same as the variable in other functions.
    cout << X << endl; // this will print X from main function.
    MyAge();           // this will print X from the procedure.

    cout << ::X << endl;   // this will print the Global variable, by using (::) then the name of the gloval variable.

    ::X = 5000; // this is also the way to modify the global variable;
    cout << ::X << endl;

    return 0;
    
}

/* every variable has 3 things when created > Name, Value and reference. reference is where this variable is saved in the memory
so if i ceate two variables in the same scope with same name i wont be allowed cuz he will check the reference then see this name 
has the same reference then he will reject it. in the example above the global and local variables have same naming but different scopes
thus i was able to create them. */