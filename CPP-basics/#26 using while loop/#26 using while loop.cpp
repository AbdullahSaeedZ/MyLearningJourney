#include <iostream>
using namespace std;


void ReadNumber(int &Number)
{
    cout << "Please enter a number: " << endl;
    cin >> Number;

    int Counter = 1;

    while (Counter <= Number)
    {
        cout << Counter << endl;
        Counter++;

    }
}



int main()
{
    
    int Number;
    ReadNumber(Number);

    return 0;
}

