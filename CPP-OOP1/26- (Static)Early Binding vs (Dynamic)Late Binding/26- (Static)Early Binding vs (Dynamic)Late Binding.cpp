#include <iostream>
using namespace std;

// Static = Early Binding,  Dynamic = Late Binding

class clsPerson
{

public:

  virtual  void Print()

  {
        cout << "Hi, i'm a person!\n ";

  }

};

class clsEmployee : public clsPerson
{
public:
    void Print()
    {
        cout << "Hi, I'm an Employee\n";
    }
};

class clsStudent : public clsPerson
{
public:
    void Print()
    {
        cout << "Hi, I'm a student\n";
    }
};


int main()

{

    clsEmployee Employee1;
    clsStudent  Student1;
    // Early (Static) Binding: occurs at compile time, before program execution (runtime).
    // It's the default behavior in C++ when not using pointers or virtual functions.
    // The compiler determines which function to call and links it to its memory address during compilation.

    Employee1.Print();
    Student1.Print();



    clsPerson* Person1 = &Employee1;
    clsPerson* Person2 = &Student1;

    //Late-Dynamic Binding: at runtime after compilation (that is why called late) cuz its a pointer and the compiler doesnt know what are the addresses (addresses given in runtime).
    // in some languages like Java, this is the default behavior.
    Person1->Print();
    Person2->Print();


  
    return 0;
}