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


void AddArrayElement(int Array[100], int& Length, int Num)
{
    Length++;
    Array[Length - 1] = Num;
}

void CopyOddNumArrayUsingAddArrayElement(int Array1[100], int Length1, int Array2[100], int& Length2)
{
    for (int Counter = 0; Counter < Length1; Counter++)
    {
        if (Array1[Counter] % 2 != 0)
        AddArrayElement(Array2, Length2, Array1[Counter]);
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


int main()
{
    srand((unsigned)time(NULL));
    
    int Array1[100], Array2[100], Length1 = 0, Length2 = 0;
    FillRandomNumsInArray(Array1, Length1);

    CopyOddNumArrayUsingAddArrayElement(Array1, Length1, Array2, Length2);

    cout << "\nArray 1 elements:" << endl;
    PrintArray(Array1, Length1);

    cout << "\nArray 2 Odd numbers:" << endl;
    PrintArray(Array2, Length2);

}

