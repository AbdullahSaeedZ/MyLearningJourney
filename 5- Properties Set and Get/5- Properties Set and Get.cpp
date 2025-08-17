#include <iostream>
using namespace std;


// properties set and get are methods used to set a value to a variable and to get this value from the variable.
// this is used cuz we dont want to give values inside the class declaration, it is prohibited(best practice), so instead we use set and get for each variable.
// so, what is a property in a class ? it is a public function used to get or set to a private variable.
// we always declare variables in the private section, public is only for methods and then the methods can operate with the private variables.


// why this complication ? it has usefull features that we will explore later and will improve reuseability, such as tracking old values of _FirstName data entry validation and so on.

class clsPerson
{
private:

    // when naming private variables, it is a best practice to start with underscore for easier reach
    // all private members are global members for the class, meaning can be accessed any where in the class

    string _FirstName;
    string _LastName;

public:

    // Property set:
    void setFirstName(string str)
    {
        _FirstName = str;
    }

    // property get:
    string FirstName()
    {
        return _FirstName;
    }



    void setLastName(string str)
    {
        _LastName = str;
    }

    string LastName()
    {
        return _LastName;
    }



    string FullName()
    {
        return _FirstName + " " + _LastName;
    }
};

int main()
{
    

    clsPerson Person1;

    Person1.setFirstName("Abdullah"); 
    Person1.setLastName("Alzahrani");

    cout << "First Name: " << Person1.FirstName() << endl;
    cout << "Last Name: " << Person1.LastName() << endl;
    cout << "Full Name: " << Person1.FullName() << endl;




    return 0;
}
