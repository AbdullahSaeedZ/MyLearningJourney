#include <iostream>
using namespace std;


int main()
{
    //&& is the AND logical operator
    cout << "Result: " << (12 && 25);   // those numbers are true since any number more than 0 is true, so result will be true.
    cout << endl;


    //here the & is a bitwise AND operator, which will convert the two numbers into binary numbers then will apply the AND logical operator on these two binary numbers
    //which will result in a new one binary number. in this case the new number is 8
    cout << "Result: " << (12 & 25);
    cout << endl;


    //  so 12 and 25 in binary are:
    //  00001100 
    //  00011001
    //  --------   after applying && logical operator between each digit of the two binarie, a new binary line will result:
    //  00001000   = Number 8

    return 0;
}

