#include <iostream>
using namespace std;

/*
1 - A copy constructor initializes a new object by copying data members from an existing object.
2 - This process is called copy initialization (or member-wise initialization).
3 - Member-wise: each member of the new object is copied from the corresponding member of the source object.
4 - You can explicitly define a copy constructor, but if you don’t, the compiler provides a default one.
5 - In most cases, you don’t need to write your own copy constructor unless special handling is required.
6 - Types of constructors: default constructor, parameterized constructor, and copy constructor.
7 - A class can have multiple constructors (constructor overloading) using function overloading.
*/


class clsAddress
{
private:

    string _AddressLine1;
    string _AddressLine2;
    string _POBox;
    string _ZipCode;

public:

   
    clsAddress(string AddressLine1, string AddressLine2, string POBox, string ZipCode)
    {
        _AddressLine1 = AddressLine1;
        _AddressLine2 = AddressLine2;
        _POBox = POBox;
        _ZipCode = ZipCode;
    }

    // copy constructor.
    // we used & to avoid making a copy, and to avoid recursion then stack overflow.
    clsAddress(clsAddress& OldObject)
    {

        // we use getters of the old object
        _AddressLine1 = OldObject.AddressLine1();
        _AddressLine2 = OldObject.AddressLine2();
        _POBox = OldObject.POBox();
        _ZipCode = OldObject.ZipCode();
    }


    // Setters and getters for each private member
    void SetAddressLine1(string AddressLine1)
    {
        _AddressLine1 = AddressLine1;
    }

    string AddressLine1()
    {
        return _AddressLine1;
    }

    void SetAddressLine2(string AddressLine2)
    {
        _AddressLine2 = AddressLine2;
    }

    string AddressLine2()
    {
        return _AddressLine2;
    }

    void SetPOBox(string POBox)
    {
        _POBox = POBox;
    }

    string POBox()
    {
        return _POBox;
    }

    void SetZipCode(string ZipCode)
    {
        _ZipCode = ZipCode;
    }

    string ZipCode()
    {
        return _ZipCode;
    }



    void Print()
    {
        cout << "\nAddress Details:\n";
        cout << "------------------------";
        cout << "\nAddressLine1: " << _AddressLine1 << endl;
        cout << "AddressLine2: " << _AddressLine2 << endl;
        cout << "POBox       : " << _POBox << endl;
        cout << "ZipCode     : " << _ZipCode << endl;
    }


};

int main()
{
    

    clsAddress Address1("Queen Alia Street", "B 303 ", "11192", "5555");
    Address1.Print();

    clsAddress Address2 = Address1;
    Address1.Print();


    system("pause>0");

    return 0;
}