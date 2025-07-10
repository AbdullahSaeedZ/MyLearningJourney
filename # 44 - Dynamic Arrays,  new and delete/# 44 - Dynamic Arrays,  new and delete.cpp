#include <iostream>
using namespace std;

// why using dynamic allocation with pointers and new-delete???
// if we do it in a static allocation way (variables not deleted in run time) then program will be slow and will use a lot of memory
// wo with this dynamic allocation, we get of the array after finishing for better performance!

// maybe you will say: why dont we use vectors and clear function to delete the vector?
// well, clear function will clear the values of the vector, but will keep the space in memory (capacity), if we test using capacity function after the clear, we will notice that capacity is not deleted! 

int main()
{
    // this is how to control length of array dynamically without preserving un wanted memory space:
    int Num = 0;
    cout << "how many student do you want?" << endl;
    cin >> Num;

    int* p;
    p = new int[Num]; // allocate memory for an array to be used, the length is as the user entered.

    for (int Counter = 0; Counter < Num; Counter++)
    {
        cout << "\nEnter grade of student number " << Counter + 1 << " : ";
        cin >> *(p + Counter);
    }

    for (int Counter = 0; Counter < Num; Counter++)
    {
        cout << "\nStudent Number " << Counter + 1 << " grade is: " << *(p + Counter) << endl;
    }

    delete[] p;



    return 0;
}

