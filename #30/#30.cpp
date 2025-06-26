#include <iostream>
#include <cstdlib>    
#include <ctime>
#include <string>
using namespace std;

int ReadPositiveNumber(string Message)
{
    int Num = 0;
    do
    {
        cout << Message << endl;
        cin >> Num;
    } while (Num <= 0 || Num > 100);

    return Num;
}

int RandomNumber(int From, int To)
{
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

void FillRandomNumsInArray(int Array[100], int Length)
{

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

    cout << endl << endl;
}

void Sum2Array(int Array[100], int Array2[100], int Array3[100], int Length)
{
    for (int Counter = 0; Counter < Length; Counter++)
    {
        Array3[Counter] = Array[Counter] + Array2[Counter];
    }
}


int main()
{
    srand((unsigned)time(NULL));

    int Array[100], Array2[100], Array3[100]; 
    int Length = ReadPositiveNumber("\nEnter how many elements do you need:\n");

    FillRandomNumsInArray(Array, Length);
    FillRandomNumsInArray(Array2, Length);

    Sum2Array(Array, Array2, Array3, Length);
    
    cout << "Array1 elements: ";
    PrintArray(Array, Length);

    cout << "Array2 elements: ";
    PrintArray(Array2, Length);

    cout << "Sum of the two arrays: ";
    PrintArray(Array3, Length);

    return 0;
}