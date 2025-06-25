#include <iostream>   
#include <string>     
#include <cstdlib>    // Include cstdlib for rand() and srand() functions.
#include <ctime>      // Include ctime for the time() function.

using namespace std;  


int RandomNumber(int From, int To)
{
    // Generate a random number between 0 and (To - From) using rand(),
    
    int randNum = rand() % (To - From + 1) + From;
    return randNum;  
}

int main() {
    
    // This ensures that we get a different sequence of random numbers on each run.
    // this is like a delcaration to start using the random function.
    // we have to declare it in the main function to generate random values each run, if we declare it in other functions than the main, it will generate the same numbers every time.
    srand((unsigned)time(NULL));

    
    cout << RandomNumber(1, 10) << endl;
    cout << RandomNumber(1, 10) << endl;
    cout << RandomNumber(1, 10) << endl;

    return 0;  
} 