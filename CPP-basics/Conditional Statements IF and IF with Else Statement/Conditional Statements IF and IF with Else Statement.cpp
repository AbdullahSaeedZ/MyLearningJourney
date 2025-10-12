#include <iostream>
using namespace std;


int main()
{
    
    int x = 10;


    if (x > 10)  // thi is the condtion, if it is true then the code inside the body will run, if false then the body is ignored.
    {
        cout << "this is IF body code, and it runs if the condition is true" << endl;
    }

    cout << "this is not part of the IF body code, so it will always run" << endl;

    int A = 10, B = 60;


    // another type is the if-else:

    if (A && B) // we can put any condition from logical operators.
    {
        cout << "Body of IF , it will work if the condition is true, if false it will be ignored and the else will run." << endl;

    }
    else
    {
        cout << "this is called Else body code, it will only run if the condition of IF is false." << endl;

    }


    return 0;
}

