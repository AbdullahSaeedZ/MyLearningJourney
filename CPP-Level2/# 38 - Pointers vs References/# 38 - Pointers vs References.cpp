#include <iostream>
using namespace std;


//                                    Pointers vs References
// Reference will give another name for a variable, like an alias but both name are for same address.
// poitnters will create a new slot with new address cointaing the address of another variable.


int main()
{
    

    int a = 10;
    int& x = a;   //reference x is now preserved for only a and cant make new reference of another variable with x.
    
    cout << &a << endl; 
    cout << &x << endl; 
    cout << a << endl;   
    cout << x << endl; 
    
    int* p = &a; 
    cout << p << endl;   
    cout << *p << endl; 
    
    int b = 20;   
    p = &b;       // note here unlike reference, in the same pointer we used to store address of a, now we can point it to another variable (b).
                  // for example, compiler wont accept if we write &x = b. but it will accept it with pointers.
    
    cout << b << endl;
    cout << p << endl;  
    cout << *p << endl;

    // so with the pointer, we accessed two different addresses. we couldnt do it with & reference.

    return 0;
}

