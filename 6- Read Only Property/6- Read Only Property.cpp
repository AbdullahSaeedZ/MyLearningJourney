#include <iostream>
using namespace std;


class clsPerson
{
private:

    // Constant will make it read only for everyone , but get method will make it read only outside the class through object but you can change its value from inside the class
    int _ID = 20;   // we assign a value here, cuz we dont want it to be changed later, ReadOnly 


    string _FirstName;
    string _LastName;

public:

    // Property set:
   
    // NO setID() 

    // property get, , it is ReadOnly Property cuz we dont have set property.
    int ID()
    {
        return _ID;
    }


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
    // no one can edit the ID value


    cout << "ID: " << Person1.ID() << endl;
    cout << "First Name: " << Person1.FirstName() << endl;
    cout << "Last Name: " << Person1.LastName() << endl;
    cout << "Full Name: " << Person1.FullName() << endl;




    return 0;
}