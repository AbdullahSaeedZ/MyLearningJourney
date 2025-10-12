#include <iostream>
using namespace std;


void PrintArray(int Array[100], int Length)
{

    for (int Counter = 0; Counter < Length; Counter++)
    {
        cout << Array[Counter] << " ";
    }

    cout << endl;
}


bool IsArrayPalindrome(int Array[100], int Length)
{
    for (int Counter = 0; Counter < Length /2; Counter++)
    {
        if (Array[Counter] != Array[Length - 1 - Counter])
        {
            return false;
        }
    }
    return true;
} 

int main()
{
    int Array1[100] = { 10, 20, 30, 30, 20, 10}, Length1 = 6;
 


    cout << "Array1 elements:" << endl;
    PrintArray(Array1, Length1);

    if (IsArrayPalindrome(Array1, Length1))
    {
        cout << " \nyes array is palindrome." << endl;
    }
    else
    {
        cout << "\nNo array is not palindrome." << endl;
    }

    

    return 0;
}