#include <iostream>
using namespace std;

// just for revision of static members: https://chatgpt.com/share/67c8a85c-8124-8000-b854-863f63f35ac1


// this pointer, is pointing to the current object created of a class.
// once we instantiate an object, a this pointer is implicitly created.
// this pointer is used inside the class only.
// by using this pointer, we can access all members everywhere inside the class (private and all)

// cant access friend functions, cuz they are not members of the class.


// so main uses here are:
// 1) Using 'this' to distinguish member variables from constructor parameters
//    Example: this->ID = ID; ensures we assign the parameter ID to the member variable ID

// 2) Using 'this' to pass the current object to a static function
//    Example: Func1(*this); dereferences the 'this' pointer to pass the object itself
//    to a static function, since static functions do not have a 'this' pointer


class clsEmployee

{

public:
    int ID;
    string Name;
    float Salary;

    clsEmployee(int ID, string Name, float Salary)
    {
        this->ID = ID;     // one way to use THIS, is to help distinguish variables with the same name.
        this->Name = Name; // we say that we want Name variable of This (the current object of the current class) 
        this->Salary = Salary;

    }


    // in static functions, there is no this pointers, so if we want to pass pointer, we have to pass the pointer to it from other places like Func2
    // or just in main use the static function directly and give it the object without a pointer.
    static void Func1(clsEmployee Employee)  
    {

        Employee.Print();

    }

    void Func2()

    {
        Func1(*this); // since this is a pointer, then it has the address of the object, so here we want to pass the contnet not the address, use dereferencing (*).


    }

    void Print()
    {
        cout << ID << "  " << Name << "  " << Salary << endl;
        // cout << this->ID << "  " << this->Name << "  " << this->Salary << endl;

    }

};

int main(void)
{
    clsEmployee Employee1(101, "Ali", 5000);
    Employee1.Print();

    Employee1.Func2();


    // or directly without pointer:

    clsEmployee::Func1(Employee1);

    return 0;
}