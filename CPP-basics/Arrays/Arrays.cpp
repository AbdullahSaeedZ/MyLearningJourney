#include <iostream>
using namespace std;


int main()
{
    //array is a variable creted nrmally but we decalre its Index size [4] , then we assgin those 4 values. each value of them has an index number starting from 0.
    // each elemnt (value) inside the index is saved in the memory with its own space and reference or address.

    int X[4] = { 34, 54, 32 ,21 }; 

    cout << "the forth value in X array is: " << X[3] << " which is index 3" << endl;

    // we can use those indexes to to addition or whatever we want , we use them as variables.
    cout << "Adding index 3 and 0 = " << X[3] + X[0] << endl;

    float Y[2];  //here the 2 means how many values to have or how many indexes.
    Y[0] = 3.2;  //here 0 is the index numbering which starts from 0
    Y[1] = 2.8;
    
    
    cout << Y[1];

    return 0;

}

