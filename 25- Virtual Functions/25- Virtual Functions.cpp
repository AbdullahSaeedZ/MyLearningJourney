#include <iostream>
using namespace std;

// Basically, a virtual function is used in the base class in order to ensure that the function is overridden.This especially applies to cases where a pointer of base class points to an object of a derived class.

class clsPerson
{

public:

    // in upcasting, the base class pointer will point to the sub class memebr but will print the value of the base class, to fix this issue, we write Virtual next to the function we will override in sub classes.
    // this way we tell the compiler that we will override this function in sub classes, and need to call the new functions not the base class functions.

    virtual  void Print()
    {
        cout << "Hi, i'm a person!\n ";
    }

};

class clsEmployee : public clsPerson
{
public:

    // we override the base class function
    void Print()
    {
        cout << "Hi, I'm an Employee\n";
    }
};

class clsStudent : public clsPerson
{
public:

    // we override the base class function
    void Print()
    {
        cout << "Hi, I'm a student\n";
    }
};


int main()

{

    clsEmployee Employee1;
    clsStudent  Student1;

    Employee1.Print();
    Student1.Print();

    cout << "\nusing overridden functions with pointers and Virtual function:\n" << endl;

    // if we didnt write Virtual, then the pointers would have printed the string in the base class.
    clsPerson* Person1 = &Employee1;
    clsPerson* Person2 = &Student1;

    Person1->Print();
    Person2->Print();


  
    return 0;
}

// whats the pooooint ???
// run this main:

// making one function to print and just pass any object reference (speed and reuseability)
/*
void MyPrint(clsPerson* Person)
{
    Person->Print();
}

int main()
{
    clsPerson Person1;
    clsEmployee Employee1;
    clsStudent Student1;

    MyPrint(&Person1); // Hi, I'm an Person
    MyPrint(&Employee1); // Hi, I'm an Employee
    MyPrint(&Student1); // Hi, I'm a Student

    return 0;
}
*/