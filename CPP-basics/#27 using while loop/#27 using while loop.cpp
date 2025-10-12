#include <iostream>
using namespace std;

void ReadInput(int& Number)
{
    cout << "Enter a number: " << endl;
    cin >> Number;

    int Counter = 1;
    while (Counter <= Number)
    {
        cout << Number << endl;
        Number--;

    }

}




int main()
{
    
    int Number;
    ReadInput(Number);


    return 0;
}

