#include <iostream>
using namespace std;

void ReadInputs(int Array[10], int &Wanted)
{
    cout << "Enter numbers in the 10 array elements:" << endl;

    for (int Counter = 0; Counter < 10; Counter++)
    {
        cout << "Enter a number in the element No. " << Counter + 1 << " :" << endl;
        cin >> Array[Counter];
        
    }
    
    cout << "Choose a number from what you entered to show its position in arrays: " << endl;
    cin >> Wanted;
}

void PrintPosition(int Array[10], int Wanted)
{
    

    for (int Counter = 0; Counter <= 10; Counter++)
    {
       


        if (Wanted == Array[Counter])
        {
            cout << "The number " << Wanted << " is in the Array index No. " << Counter << endl;
            break;
        }
       
    }


    
}



int main()
{
    int Array[10];
    int Wanted;

    ReadInputs(Array, Wanted);
    PrintPosition(Array, Wanted);

    return 0;

}

