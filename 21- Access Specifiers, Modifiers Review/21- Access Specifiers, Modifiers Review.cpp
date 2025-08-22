#include <iostream>
using namespace std;

/*
Private: Accessible only within the same class.
Protected : Accessible within the same class and all derived classes.
Public : Accessible within the same class, all derived classes, and from outside(e.g., in main function).
*/


class clsA
{
private: 
    int APrivateVar;


protected:
    int AProtectedVar;
    string ProtectedNameFunction()
    {
        return "Protected Function";
    }

public:

    int APublicVar;
    string PublicEmailFunction()
    {
        return "Public Email Function";
    }
};


class clsB : public clsA
{


public:

    // the sub class B can access its own members + class A protected and public members.
    // protected members of class A can be accessed inside the class B, not by any objects, only classes.
    // accessing is done by using escape scope.

    void PublicTestFunction()
    {
        cout << clsA::ProtectedNameFunction << endl;
    }

    int BPublicVar;

};


int main()
{
    clsB B;

    // B object can ONLY access all PUBLIC members of base and sub class;
    B.



    return 0;
}
