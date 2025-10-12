#include <iostream>
using namespace std;


// A constructor is a special function that has the same name as the class, has no return type, and is always defined inside the class.
// If not explicitly declared, the compiler provides a default constructor automatically.

// The constructor is called once when an object is created.
// One common use case: initializing data (e.g., loading initial values from a database).
// Best practice: never leave an object uninitialized.

// Parameterized Constructor: a constructor that takes parameters.
// This is the preferred way to initialize member data.


class clsAddress
{ 
private: 

    string _AddressLine1; 
    string _AddressLine2;
    string _POBox;
    string _ZipCode;

public:  

    // if we didnt declare the constructor, then the compiler will declare an empty one with no parameters and call it once an object is created, it is called a default constructor.

    // so here we OVERRIDE the default constructor, meaning we kill the default one then we declare a new one with needed parameters.
    clsAddress(string AddressLine1, string AddressLine2, string POBox, string ZipCode)
    {
        _AddressLine1 = AddressLine1; 
        _AddressLine2 = AddressLine2;  
        _POBox = POBox;    
        _ZipCode = ZipCode;
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
    // the object will not be created without filling the constructors parameters

    clsAddress Address1("Queen Alia Street", "B 303 ", "11192", "5555"); 
    Address1.Print();

    system("pause>0");
    
    return 0; 
}