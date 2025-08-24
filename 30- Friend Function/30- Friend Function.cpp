#include <iostream>
using namespace std;


// Friend function is a normal function of any data type, outside the class, that has access to all class members even the private ones.


class clsA
{
private:

    int _AprvtVar1 = 10;

protected:

    int _AprctdVar2 = 20;

public:

    int _ApblcVar3 = 30;


    friend int Sum(clsA A1); // declare the function as friend to have access of all this class members even the private.
};


// can be any type, string or whatever.
// now it is a friend function of clsA, not a member of clsA
// can be more than one function to be friend
int Sum(clsA A1) 
{
    return A1._AprvtVar1 + A1._AprctdVar2 + A1._ApblcVar3;
}



int main()
{
    
    clsA A1;

    cout << Sum(A1) << endl;



    return 0;
}

