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
    } while (Number <= 0);

    return Number;
}


int RandomNumber(int From, int To)
{
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

void FillRandomNumsInArray(int Array[100], int& Length)
{
    cout << endl;
    Length = ReadPositiveNumber("Enter how many elements do you need:");
    cout << endl;

    for (int Counter = 0; Counter < Length; Counter++)
    {
        Array[Counter] = RandomNumber(1, 100);
    }
}

void PrintArray(int Array[100], int Length)
{

    for (int Counter = 0; Counter < Length; Counter++)
    {
        cout << Array[Counter] << " ";
    }

    cout << endl;
}

void CopyArrayInReverseOrder(int Original[100], int Copy[100], int OriginalLength)
{

    for (int Counter = 0; Counter < OriginalLength; Counter++)
    {
        Copy[Counter] = Original[OriginalLength - 1 - Counter];
    }
}



int main()
{
    srand((unsigned)time(NULL));

    int Array1[100], Array2[100], Length;
    FillRandomNumsInArray(Array1, Length);

    cout << "\nArray 1 elements:" << endl;
    PrintArray(Array1, Length);

    CopyArrayInReverseOrder(Array1, Array2, Length);

    cout << "\nArray 2 elements after copying array 1 in reversed order:" << endl;
    PrintArray(Array2, Length);

    

    return 0;
}