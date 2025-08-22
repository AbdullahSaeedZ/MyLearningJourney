#include <iostream>
using namespace std;



class clsA
{
private:
    int APvtVar1;
    int APvtFunc1()
    {
        return 1;
    }

protected:
    int APrtdVar2;
    int APrtdFunc2()
    {
        return 2;
    }

public:
    int APblcVar3;
    int APblcFunc3()
    {
        return 3;
    }

};

// Inheritance Visibility Modes

// Public Inheritance (B : public A)
// Using public and protected from A inside B;
// turns them into public for objects, public and protected for later derived classes (C can access too).

// Private Inheritance (B : private A)
// Using public and protected from A inside B;
// turns them into private (hides everything of A) for B objects and later derived classes (C cannot access neither inside nor outside).

// Protected Inheritance (B : protected A)
// Using public and protected from A inside B;
// turns them into protected (in class access) for derived classes, objects cannot access.

/*
Public inheritance   : public + protected go to sub classes (stay public/protected).
Private inheritance  : public + protected go only inside the first sub class, then disappear (objects can't access) (no further inheritance can see).
Protected inheritance: public + protected go to all sub classes, but only as protected (objects can't access).
*/

 
class clsB : private clsA
{
public:

    int BPblcFunc4()
    {
        cout << clsA:: << endl;
        return 4;
    }
};

class clsC : public clsB
{
public:

    int CPblcFunc5()
    {
        cout << clsA::
    }

};


int main()
{
    
    clsA A1;
    

    clsB B2;
    B2.

    clsC C3;
    C3.


    return 0;
}

