#include <iostream>
#include <iomanip> // need to include the manipulators library.
using namespace std;






int main()
{
    // Setw = set width.  it is a manipulator.

    // manipulate spaces on screen.
    // first prepare the header then the body.
    cout << "---------|--------------------------------|---------|" << endl;
    cout << "  Code   |               Name             |  Mark   |" << endl;
    cout << "---------|--------------------------------|---------|" << endl;

    // the body:
    cout << setw(9) << "C101" << "|" << setw(32) << "Intro to programming 1" << "|" << setw(9) << "99" << "|" << endl;
    cout << setw(9) << "C155" << "|" << setw(32) << "Intro to programming 2" << "|" << setw(9) << "65" << "|" << endl;
    cout << setw(9) << "C123" << "|" << setw(32) << "Intro to programming 3" << "|" << setw(9) << "88" << "|" << endl;
    cout << setw(9) << "C143" << "|" << setw(32) << "Intro to programming 4" << "|" << setw(9) << "65" << "|" << endl;

    // footer:
    cout << "-----------------------------------------------------" << endl;


    return 0;

}

