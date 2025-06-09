#include <iostream>
using namespace std;


void ReadPIN(int& PIN)
{
    cout << "Enter your PIN code:" << endl;
    cin >> PIN;
}

void PrintBalance(int PIN)
{
    int PINCode = 1234;

    if (PIN == PINCode)
    {    
        cout << "Your Balance is: 7500 SAR" << endl;
    }
    else
    {
        cout << "Wrong PIN" << endl;
    }

}


int main()
{
    int PIN;
    ReadPIN(PIN);
    PrintBalance(PIN);

    return 0;
}

