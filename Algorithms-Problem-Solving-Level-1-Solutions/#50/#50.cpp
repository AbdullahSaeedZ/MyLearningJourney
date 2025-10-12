#include <iostream>
using namespace std;


int ReadPIN(string Message)
{
    int PIN = 0;

    cout << Message << endl;
    cin >> PIN;

    return PIN;
}

bool CheckPIN()
{
    int CorrectPIN = 1234;
    int PIN;
    int Counter = 3;
    

    do
    {
        PIN = ReadPIN("Enter Your PIN code:");


        if (PIN == CorrectPIN)
        {
            return 1;
        }
        else
        {

            system("color 4F");
            cout << "Wrong PIN, you have " << Counter - 1 << " tries !!" << endl;
            Counter--;
        }

        

    } while (Counter >= 1 && PIN != CorrectPIN);

    return 0;
}



int main()
{
    if (CheckPIN())
    {
        system("color 2F");
        cout << "Your Balance is: " << 7500 << " SAR" << endl;
    }
    else
    {
        system("color 4F");
        cout << "Your account is blocked !!" << endl;
    }

    return 0;
}
