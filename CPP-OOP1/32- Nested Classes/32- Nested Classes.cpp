#include <iostream>
using namespace std;


// since class is a data type, we can declare any data type inside a class, then we have nested classes.
// the main class is called enclosing, and the inside class is called Inner class.

class clsPerson // enclosing class
{
    // declare address class here or anywhere needed
    // we can do whatever applies to classes normally as we wish

    class clsAddress // inner class, a member of the enclosing class
    {
        string _AddressLine1;
        string _AddressLine2;
        string _City;
        string _Country;

       

    public:
      
        clsAddress(string AddressLine1, string AddressLine2, string City, string Country)
        {
            _AddressLine1 = AddressLine1;
            _AddressLine2 = AddressLine2;
            _City = City;
            _Country = Country;
        }


        void setAddressLine1(string AddressLine1)
        {
            _AddressLine1 = AddressLine1;
        }

        string AddressLine1()
        {
            return _AddressLine1;
        }


        void setAddressLine2(string AddressLine2)
        {
            _AddressLine2 = AddressLine2;
        }

        string AddressLine2()
        {
            return _AddressLine2;
        }


        void setCity(string City)
        {
            _City = City;
        }

        string City()
        {
            return _City;
        }


        void setCountry(string Country)
        {
            _Country = Country;
        }

        string Country()
        {
            return _Country;
        }


        void Print()
        {
            cout << "\nAddress: \n" << endl;
            cout << _AddressLine1 << endl;
            cout << _AddressLine2 << endl;
            cout << _City << endl;
            cout << _Country << endl;
        }
    };

public:

    // use the class here
    string _FullName;
    clsAddress Address;

    clsPerson(string FullName, string AddressLine1, string AddressLine2, string City, string Country)
        : Address(AddressLine1, AddressLine2, City, Country) // pass those parameters to the inner class constructor
    {
        _FullName = FullName;
    }


    void setFullName(string FullName)
    {
        _FullName = FullName;
    }

    string FullName()
    {
        return _FullName;
    }


    // here it is not overloading or overriding or hiding, cuz each print functions will be called differently through the object.(see in main()).
    void Print()
    {
        cout << "\nAddress: \n" << endl;
        cout << _FullName << endl;
        cout << Address.AddressLine1() << endl;
        cout << Address.AddressLine2()<< endl;
        cout << Address.City() << endl;
        cout << Address.Country() << endl;
    }
    
};



int main()
{
    clsPerson Person1("Abdullah Alzahrani", "bldg1", "43st", "DMM", "SA");


    //access the nested class
    Person1.Address.Print();

    cout << "\n\n" << endl;
    
    Person1.Print();
    
    // Each Print function is independent for its class
    // Person1.Print() calls the enclosing class Print
    // Person1.Address.Print() calls the nested class Print
    // The object used determines which Print runs; no hiding occurs
    
    
    return 0;
}

