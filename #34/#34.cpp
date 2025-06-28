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

int FindNumIndexInArray(int Array[100], int NumToFind, int Length)
{

    for (int Counter = 0; Counter < Length; Counter++)
    {
        if (Array[Counter] == NumToFind)
        {
            return Counter;
        }
       
    }

    return 0;
}


int main()
{
    srand((unsigned)time(NULL));

    int Array[100], Length;
    FillRandomNumsInArray(Array, Length);

    cout << "\nArray elements:" << endl;
    PrintArray(Array, Length);

    int NumToFind = ReadPositiveNumber("\nEnter a number to search for:");
    cout << "\nNumber you are looking for is: " << NumToFind << endl;


    int NumPosition = FindNumIndexInArray(Array, NumToFind, Length);
    if (NumPosition == 0)
    {
        cout << "Number was not found!" << endl;
    }
    else
    {
        cout << "the number is found in index: " << NumPosition << endl;
        cout << "The number`s order is: " << NumPosition + 1 << endl;
    }

    return 0;
}

