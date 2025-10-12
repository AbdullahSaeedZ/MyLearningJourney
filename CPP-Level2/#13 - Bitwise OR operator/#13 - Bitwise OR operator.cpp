#include <iostream>
using namespace std;


int main()
{
    
    // OR logical operator:
    cout << "Result:" << (12 || 25);


    cout << endl;


    // bitwise OR operator
    cout << "Result:" << (12 | 25);

    //  so 12 and 25 in binary are:
    //  00001100 
    //  00011001
    //  --------   after applying || logical operator between each digit of the two bits, a new binary line will result:
    //  00011101   = Number 29



    cout << endl;

    return 0;
}
