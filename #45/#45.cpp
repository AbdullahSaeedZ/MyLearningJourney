#include <iostream>
using namespace std;

void ReadMonth(short int& Month)
{
    cout << "Enter the number of Month in a year: " << endl;
    cin >> Month;
}

void PrintMonth(short int Month)
{
    if (Month == 1)
    {
        cout << "It is January!" << endl;
    }
    else if (Month == 2)
    {
        cout << "It is February!" << endl;
    }
    else if (Month == 3)
    {
        cout << "It is March!" << endl;
    }
    else if (Month == 4)
    {
        cout << "It is April!" << endl;
    }
    else if (Month == 5)
    {
        cout << "It is May!" << endl;
    }
    else if (Month == 6)
    {
        cout << "It is June!" << endl;
    }
    else if (Month == 7)
    {
        cout << "It is July!" << endl;
    }
    else if (Month == 8)
    {
        cout << "It is August!" << endl;
    }
    else if (Month == 9)
    {
        cout << "It is September!" << endl;
    }
    else if (Month == 10)
    {
        cout << "It is October!" << endl;
    }
    else if (Month == 11)
    {
        cout << "It is November!" << endl;
    }
    else if (Month == 12)
    {
        cout << "It is December!" << endl;
    }
    else
    {
        cout << "Wrong Number, Try Again!" << endl;
    }
}

int main()
{
    short int Month;
    ReadMonth(Month);
    PrintMonth(Month);

    return 0;
}

