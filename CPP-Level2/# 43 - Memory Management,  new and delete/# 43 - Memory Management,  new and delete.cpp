#include <iostream>
using namespace std;
// during the run time of the program , the RAM will use some space in memory to store variables to be used in the run time, the less memory used the faster and better.
// dynamic memory allocation: control memory allocation in a dynamic way where in the run time (running code in main function) we can declare variables for a certain time then delete it for better performance.

int main()
{
    // here we declared two variables, if the run time takes for example 1 hour, the two variables will be in memory for that long time.
    int s;
    float t;

    // here is how we dynamically allocate memory, and can only done by using pointers:
    // declare the pointers:
    int* x;
    float* y;

    // then define them with (new) then the data type desired.
    // this way we preserved an address of an empty variable for pointer to be used.
    x = new int;
    y = new float;


    // now we give them values:
    *x = 10;
    *y = 5.5f; // it want float, better write f in the end, otherwise the compiler will see it as double.

    // we use them:
    cout << *x << endl;
    cout << *y << endl;

    // after their job is done, we get rd of them and will be no longer in the memory during the run time.
    delete x; // adderss in memory to be deleted
    delete y;

    // always when writing NEW , follow it with DELETE when done.
    
    // imagine using IF- statment and we want to activate it only one time, using normal variables they will be in memory the whole time,
    // but using pointer with new and delete, they will only be activated once condition is triggered then deleted.

    return 0;
}

