#include <iostream>
using namespace std;

// once we declare new objects of one class, new memory slots will be used for the new objects and their Only Data Members, but no extra mempry for the function members.
// the functions members will be shared for all the objects that have the same class.
// so new memorty slots for new objects and its data members and no new memory slots for functions members as they will be shared with every new object.
// that is because data members will have different data from one object to another, but since functions members have no data stored, they will be shared for better memory usage.

class clsPerson
{
    
private: 

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
   
    clsPerson Person1, Person2;

    Person1.FirstName = "Abdullah";
    Person1.LasName = "Alzahrani";
    
    Person2.FirstName = "koko";
    Person2.LasName = "Alzahrani";


    cout << Person1.FullName() << endl;
    cout << Person2.FullName() << endl;


    return 0;
}