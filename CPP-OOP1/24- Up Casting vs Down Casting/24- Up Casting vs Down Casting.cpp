#include <iostream>
using namespace std;


class clsPerson
{
public:

    string FullName = "Abdullah Alzahrani";
};


class clsEmployee : public clsPerson
{
public:

    string FullName = "koko";
    string Title = "CEO";
};



int main()
{
    
    clsEmployee Employee1;
    cout << Employee1.FullName << endl;

    // Up Casting is converting subclass object to it's base object
    // Since the subclass has members of base class and more
    // we can use a base class pointer to reference a subclass object
    // and access the shared members between them


    // الطفل ممكن يصير اب 
    clsPerson* Person1 = &Employee1;  // up cast, child memebrs pointed by parent class pointer

    cout << Person1->FullName << endl; // will use the shared variable, but prints the value that is in Person class
    cout << Person1->Title << endl; // it will access only base members that is in the base class


    //==================================================================


    // Down Casting is Converting Base object to subclass object
    // Since the sub class has more members than base class
    // we cant use a sub class pointer to reference a base class object
 

    clsPerson Person2;
    cout << Person2.FullName << endl;

    // الاب مو ممكن يصير طفل
    clsEmployee* Employee2 = &Person2; // down cast, parent memebers cant be pointed by child pointer.





    // in short words, (upcasting) we can create a base class pointer and points to any sub class, cuz all members of base exist in subs.
    // but (downcasting) cant make pointer of sub class to point to base class, cuz sub memebrs are not all in base.

    return 0;
}

