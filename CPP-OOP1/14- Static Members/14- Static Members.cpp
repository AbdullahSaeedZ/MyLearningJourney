#include <iostream>
using namespace std;


// we learned that static variables in any function will be destroyed and removed from memory once the function does its job.
// but static variables will remain in memory for the whole life of program even though the function did it job and got destroyed.


// static data member in a class has the same concept, it is useful when we create more than one object of the same class and we want to have a shared variable among those objects.

class clsA
{

public:


    int Var = 0;
    static int Counter; // this is a one global variable to the objects created from this class.

    clsA()
    {
        Counter++;
    }

    void Print()
    {
        cout << "\nVar: " << Var << endl;
        cout << "Counter: " << Counter << endl;
    }

};

int clsA::Counter = 0; // to be able to use static member, we must initialize it before the wanted function. (C++ behaviour).

int main()
{
    
    clsA Ob1, Ob2, Ob3; //once we created the objects, the constructors ran and counter increased at once.

    Ob1.Var = 10;
    Ob2.Var = 20;
    Ob3.Var = 30;


    Ob1.Print();
    Ob2.Print();
    Ob3.Print();
    
    // since the static member is global in the class, it is accessible from any object of the same class.

    cout << "\n\nAfter chabging counter value by accessing the static member from any object:" << endl;
    Ob2.Counter = 500;

    Ob1.Print();
    Ob2.Print();
    Ob3.Print();

    
    return 0;
}

