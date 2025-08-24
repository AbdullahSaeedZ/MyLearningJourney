#include <iostream>
using namespace std;


// Friend class is a second class (no need for inheritance) that has access to all first class members, even the private members. 
// the access is on the classes level, no object can access private or protected members.
// it is a one-way friendship, meaning that the first class cant see private members of the second class, unless we declare it.

// this concept partially breaks the encapsulation, cuz it gives another access to the content of the class not by objects only.

class clsA
{
private:

    int _AprvtVar1 = 10;

protected:

    int _AprtctVar2 = 20;

public:

    int _ApblcVar3 = 30;


    friend class clsB;  // this is how we declare classes as friend and give them full access. we can write it in private, protected or public area. 
};

class clsB
{

public:

    void Display(clsA A1)
    {

        // accessing private members of another class.
        cout << "value of clsA private member = " << A1._AprvtVar1 << endl;
        cout << "value of clsA protected member = " << A1._AprtctVar2 << endl;
        cout << "value of clsA public member = " << A1._ApblcVar3 << endl;
    }

};




int main()
{
    clsA A1;

    clsB B1;

    // no access by objects. try the dot.
    B1.Display(A1);
    



    return 0;
}

