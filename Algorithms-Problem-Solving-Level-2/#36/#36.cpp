#include <iostream>
#include <cstdlib>    
#include <ctime>
#include <string>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number < 0);

    return Number;
}

void AddArrayElement(int Array[100], int& Length, int Num)
{
    Length++;
    Array[Length - 1] = Num;
}

// called semi-dynamic cuz at first we declared the array with 100 index, then the user chooses how many elements to use.
// in the full dynamic, the user will choose how many elements and then the array will be created based on that.

void SemiDynamicUserInputArray(int Array[100], int& Length)
{
    Length = 0;
    bool AddMore = true;

    do
    {
        AddArrayElement(Array, Length, ReadPositiveNumber("Enter a number:"));
        cout << "Do you want to add more numbers? [0] No - [1] Yes" << endl;;
        cin >> AddMore;

    } while (AddMore);
}

void PrintArray(int Array[100], int Length)
{

    for (int Counter = 0; Counter < Length; Counter++)
    {
        cout << Array[Counter] << " ";
    }

    cout << endl;
}

int main()
{
    int Array[100], Length;
    SemiDynamicUserInputArray(Array, Length);


    cout << "Array Length: " << Length << endl;
    cout << "Array elements: ";
    PrintArray(Array, Length);


    return 0;
}

