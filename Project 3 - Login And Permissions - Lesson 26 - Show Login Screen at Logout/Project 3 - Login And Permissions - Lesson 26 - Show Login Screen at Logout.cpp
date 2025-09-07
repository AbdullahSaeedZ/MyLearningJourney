#include <iostream>
#include "clsLoginScreen.h"
using namespace std;


// Circular dependency = mutual dependency
// Happens when two classes or files depend on each other simultaneously
// Example: clsMainScreen includes clsLoginScreen
// And clsLoginScreen includes clsMainScreen
// This causes an infinite loop at compile time => Compilation error


// below is the solution

int main()
{

    while (true)
    {
        clsLoginScreen::ShowLoginScreen();
    }


    return 0;
}