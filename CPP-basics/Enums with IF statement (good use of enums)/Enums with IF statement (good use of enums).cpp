#include <iostream>
using namespace std;

enum enCarMake{Toyota=1 , Honda=2, Kia=3, Ford=4};

void ReadInput(short int& Input)
{
    cout << "Choose the Maker Number: " << endl;
    cout << "(1) Toyota" << endl;
    cout << "(2) Honda" << endl;
    cout << "(3) Kia" << endl;
    cout << "(4) Ford" << endl;
    cout << "*************" << endl;
    cout << "Your choice is?" << endl;
    cout << "*************" << endl;
    cin >> Input;
}

void PrintCars(short int Input)
{
    enCarMake CarInput = (enCarMake)Input;

    if (CarInput == enCarMake::Toyota)
    {
        cout << "Available cars from this maker are: " << endl;
        cout << "Camry - Corolla - Land - Yaris" << endl;

    }
    else if (CarInput == enCarMake::Ford)
    {
        cout << "Available cars from this maker are: " << endl;
        cout << "Mustang - Edge - Explorer - Shelby" << endl;
    }
    else if (CarInput == enCarMake::Honda)
    {
        cout << "Available cars from this maker are: " << endl;
        cout << "Accord - City - Civic" << endl;
    }
    else if (CarInput == enCarMake::Kia)
    {
        cout << "Available cars from this maker are: " << endl;
        cout << "K3 - K4 - K5 - K6"  << endl;
    }
    else
    {
        cout << "Wrong Input, Try Again!" << endl;
    }


}

int main()
{
    short int Input;
    ReadInput(Input);
    PrintCars(Input);
}

