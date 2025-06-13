#include <iostream>
using namespace std;


int ReadNumberInRange(int From, int To)
{
    int Number;
    cout << "Please enter a number between " << From << " and " << To << endl;
    cin >> Number;

    while (Number < From || Number > To)
    {
        cout << "Wrong number!! Please enter a number between " << From << " and " << To << endl;
        cin >> Number;
    }

    

    return Number;
}



int main()
{
    
    // WHILE loop is same as the idea of FOR loop, but in WHILE loop we dont know when to end the loop.

    int Number;
    cout << "Please enter a positive number: " << endl;
    cin >> Number;


    // the parameter of while is Condition, if condition is true then the body will work and wont exit the body untill condition is false.
    while (Number < 0)
    {
        cout << "Wrong number!! Enter a positive number:" << endl;
        cin >> Number;
    }

    cout << "Correct!! you entered number " << Number << endl;


    // we create a function to use this validation any time, this is an example:

    cout << "You entered : " << ReadNumberInRange(5, 20) << endl;



    return 0;

}

