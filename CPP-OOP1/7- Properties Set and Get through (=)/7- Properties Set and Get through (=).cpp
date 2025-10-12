#include <iostream>
using namespace std;


class clsPerson
{
private:

   
    string _FirstName;
  

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

    // property declaration, assign get and put to the setter and getter functions names, then give it any name, better to call it a relevant name such as FirstName.
    // this new property will map get to the getter and put to the setter.

    __declspec(property(get = FirstName, put = setFirstName )) string PropertyName;
};

int main()
{


    clsPerson Person1;

    Person1.setFirstName("Abdullah");
    cout << "First Name: " << Person1.FirstName() << endl;


    // instead of the above, we use the new property we created:

    Person1.PropertyName = "koko";
    cout << "First Name using the property: " << Person1.PropertyName << endl;

    // we still used getter and setter, but we created a property (shortcut) to make it easier when setting or getting.



    return 0;
}