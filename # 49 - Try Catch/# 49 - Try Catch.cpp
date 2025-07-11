#include <iostream>
#include <vector>
using namespace std;

// exception is the situation when the program crashes cuz the compiler couldnt handle the code given.
// example you are writing cout << Numbers.at(4);  but the vector has only 2 elements, so the program will crash and will give exception
// exceptions if not handled, program crashes, but if handled will work as we want using try-catch.


int main()
{

    vector <int> Numbers = { 1, 2, 3 };

    // try this code to see exception:
    
    /*   cout << Numbers.at(6);  */

    // Exception handling makes the program so slow, so dont use it too much, only use it when needed.
    // Exception handling :
   
    try
    {
        cout << Numbers.at(6); // here put the code that u suspect that it will crash

    }
    catch (...) // in brackets we can determine which errors to be handled, but this is for another level and later will be explained.
    {
        cout << "out of bond\n"; // if the profram crashes, then the exception will be handled with this code

    }


    return 0;
}