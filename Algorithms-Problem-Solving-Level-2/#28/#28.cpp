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
    } while (Num <= 0);

    return Num;
}

int RandomNumber(int From, int To)
{
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

void ReadArray(int Array[100], int& Length)
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

    cout << endl << endl;
}

void CopyArray(int Original[100], int Copy[100], int Length)
{
    for (int Counter = 0; Counter < Length; Counter++)
    {
        Copy[Counter] = Original[Counter];
        cout << Copy[Counter] << " ";
    }

    cout << endl << endl;
}

int main()
{
    srand((unsigned)time(NULL));

    int Array[100], Array2[100], Length;

    ReadArray(Array, Length);

    cout << "Array 1 elements: " << endl;
    PrintArray(Array, Length);

    cout << "Array 2 elements: " << endl;
    CopyArray(Array, Array2, Length);



    return 0;
}