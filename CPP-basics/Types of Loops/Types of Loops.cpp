#include <iostream>
using namespace std;


int main()
{
    (initialization; condition; updation)    //if true, it will loop

    for (int i = 0; i < 5; i++) 
    {
        cout << "Hello World\n";
    }






    while (condition)  //if true, it will loop
    {
        // Body of the loop
        // update expression
    }

    int i = 1;

    while (i <= 5) 
    {
        cout << i << " ";

        // Updation
        i++;
    }






    do 
    {
        // Body of the loop                                              
        // Update expression
    } while (condition);          //if true, it will loop



    // Initialization
    int i = 1;

    // while loop that starts with i = 1 and ends
    // when i is greater than 5.
    do
    {
        cout << i << " ";

        // Updation
        i++;
    } while (i <= 5);









    for (int i = 0; i < 5; i++) {

        // Terminating before reaching i = 4
        if (i == 2) break;
        cout << "Hi" << endl;
    }




    for (int i = 0; i < 5; i++) {

        // Skipping when i equals 2
        if (i == 2) continue;
        cout << "Hi" << endl;
    }
}

