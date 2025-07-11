#include <iostream>
#include <vector>
using namespace std;


// vector iterators are used to print values of a victor using for loop.

int main()
{
    vector <int> Numbers = { 10, 20, 30, 40 };

    // Declare the vector iterator (must be same data type of vector)
    vector <int>::iterator iter;

    //using the iterator in for loop

    // the .begin() will take value of first element in vector
    // the .end() will take some value after the last element in vector, so we use it in the for loop to control 
    // those are functions to use in loop of vectors and with iterators.

    for (iter = Numbers.begin(); iter != Numbers.end(); iter++) // iter++ will not add 1 to iter, iter is an iterator so the ++ will make it store the next element value of vector
    {
        cout << "Value of element: " << * iter << " ";
        cout << "Address of element: " << &(*iter) << " ";
        cout << "Address of the iter variable: " << & iter << " " << endl;
    }

    // to show value of the iterator we use (*), cuz iterator is kind of a pointer (it is actually an object but acting as pointer) but for vectors
    // so to show address of the each element we cant write iter then see the address.
    // here we wrote &iter , the result will be showing the address of variable iter itself in the stack.
    // to show address of the element itself we use &(*iter) , we say show address of the value pointed.
    
    
    cout << endl << endl;


    return 0;
}

