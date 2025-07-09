#include <iostream>
using namespace std;


int main()
{
    // each element in the array has its own address in the memory
    int array[4] = { 1, 2, 3, 4 };

    int* p = array;  // once we declare a pointer to the array, it takes address of array[0]

    cout << "Addresses are:" << endl; 

    cout << p << endl;        // this will show array[0]
    cout << p + 1 << endl;    // this will show array[1]
    cout << p + 2 << endl;    // this will show array[2]
    cout << p + 3 << endl;    // this will show array[3]


    cout << "\nValues are :" << endl; // showing values is always done using (*)

    cout << *(p) << endl;             
    cout << *(p + 1) << endl;
    cout << *(p + 2) << endl;
    cout << *(p + 3) << endl;


    //or it can also be used with for loop:

    for (int Counter = 0; Counter < 4; Counter++)
    {
        cout << "\nAddress of array element " << Counter << " : ";
        cout << p + Counter << endl;

        cout << "Value of array element " << Counter << " : ";
        cout << *(p + Counter) << endl;
        
        cout << endl;
    }
    




    return 0;

}

