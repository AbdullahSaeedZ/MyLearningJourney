#include <iostream>
using namespace std;

// class comes from Classification, as we classify based on objects.
//class is a data type same as int float etc.
//it is used like a structure but we can include functions as members of the class.
// in structures, we can add functions but the defference will be explained later.

// a class method is a function or procedure inside a class.


class clsPerson
{
    // everything inside this class is by default un accessible from outside its scope, meaning if i say in the main, person1. after the dot nothing will appear cuz its private.
    // in order to make the members accessible, we write Public then anything after public will be ready to be used in the main.

private: // if we dont write private, it is private by default.

    int x;

public:
    string FirstName;
    string LasName;

    string FullName()
    {
        return FirstName + " " + LasName;
    }
};




int main()
{
    // Person1 here is an object, also called an instance of clsPerson class
    // in other words, Object is a variable created with a class data type

    clsPerson Person1;
    
    Person1.FirstName = "Abdullah";
    Person1.LasName = "Alzahrani";

    cout << Person1.FullName() << endl;
    
    
    return 0;
}
