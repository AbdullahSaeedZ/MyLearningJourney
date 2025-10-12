#include <iostream>
using namespace std;

// Interface is the contract and the inside pure virtual functions are the terms of the contract.
// the idea is to have certain methods we need other classes to have when they are created, otherwise those classes wont be allowed to exist without having All the terms.
// interface class have only pure functions.
// we cant create objects from interface classes, cuz those pure functions have no implementation (code body), they are only for inheritance.


// Interface (in C++): a class where all member functions are pure virtual (no implementation, usually no data members).
// Abstract class: any class that has at least one pure virtual function; it may also contain normal functions and data members.



// this is called: Abstract class / Interface / Contract.
class clsMobile
{
    // once we declare a virtual function then make it equal to = 0; it is called Pure virtual function, the zero is only the way to define pure, zero is not for assigning any value.
    // these pure virtual functions must be overridden in sub classes, otherwise sub classes wont be created.

    virtual void  Dial(string PhoneNumber) = 0;
    virtual void  SendSMS(string PhoneNumber,string Text) = 0;
    virtual void  TakePicture() = 0;
};


class clsApple : public clsMobile
{
public:

    // now apply the terms of the contract, override the pure virtual functions.
    // override not overload, meaning we need to have the same signature of pure functions (same name, parameters and everything)

    void  Dial(string PhoneNumber)
    {
        // here write the implementation
    }

    void  SendSMS(string PhoneNumber, string Text)
    {

    }

    void  TakePicture()
    {
        cout << "\nPicture Taken!" << endl;
    }

    // then we can add any extra members

};


class clsSamsung : public clsMobile
{
public:

    void  Dial(string PhoneNumber)
    {
        // here write the implementation
    }

    void  SendSMS(string PhoneNumber, string Text)
    {

    }

    void  TakePicture()
    {
        cout << "\nPicture Taken!" << endl;
    }

    // then we can add any extra members

};

int main()
{
    
    clsMobile M1; // cant create object of interface class.

    clsApple iPhone15;
    iPhone15.TakePicture();

    clsSamsung Note10;
    Note10.TakePicture();

    return 0;
}

