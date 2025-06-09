#include <iostream>
using namespace std;

void ReadMonth(short int& Month)
{
    cout << "Enter the number of Month in a year: " << endl;
    cin >> Month;
}

void PrintMonth(short int Month)
{   

    switch (Month)
    {
        case 1 : 
            cout << "It is January!" << endl;
            break;
        case 2: 
            cout << "It is February!" << endl;
            break;
        case 3: 
            cout << "It is March!" << endl;
            break;
        case 4:
            cout << "It is April!" << endl;
            break;
        case 5: 
            cout << "It is May!" << endl;
            break;
        case 6:
            cout << "It is June!" << endl;
            break;
        case 7:
            cout << "It is July!" << endl;
            break;
        case 8: 
            cout << "It is August!" << endl;
            break;
        case 9: 
            cout << "It is September!" << endl;
            break;
        case 10:
            cout << "It is October!" << endl;
            break;
        case 11:
            cout << "It is November!" << endl;
            break;
        case 12:
            cout << "It is December!" << endl;
            break;
        default: cout << "Wrong Number, Try Again!" << endl;

    }


}

int main()
{
    short int Month;
    ReadMonth(Month);
    PrintMonth(Month);

    return 0;
}

