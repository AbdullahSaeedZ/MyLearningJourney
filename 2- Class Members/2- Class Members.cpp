#include <iostream>
using namespace std;

// content of a claas is called Members.

//members are two types:
// 1- Data Members: any variable declared inside the class that holds or can hold data, in our case FirstName and LastName.
// 2- Function Members(Methods): any functin or procedure delcared inside the class, in our case FullName().

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

    clsPerson Person1;

    Person1.FirstName = "Abdullah";
    Person1.LasName = "Alzahrani";

    cout << Person1.FullName() << endl;


    return 0;
}