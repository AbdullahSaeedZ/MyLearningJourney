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

bool IsPrimeNum(int Number)
{
    float M = round(Number / 2);
    for (int Counter = 2; Counter <= M; Counter++)
    {
        if (Number % Counter == 0)
            return false;

    }

    return true;
}

void CopyPrimeNumInArray(int Original[100], int Length, int Copy[100], int &Length2)
{
    int Length2Counter = 0;

    for (int Counter = 0; Counter < Length; Counter++)
    {
        if (IsPrimeNum(Original[Counter]))
        {
            Length2Counter++;
            Copy[Counter] = Original[Counter];
            cout << Copy[Counter] << " ";
        }
    }
    Length2 = Length2Counter;

    cout << endl << endl;
}

int main()
{
    srand((unsigned)time(NULL));

    int Array[100], Array2[100], Length, Length2;

    ReadArray(Array, Length);

    cout << "Array 1 elements: " << endl;
    PrintArray(Array, Length);

    cout << "Prime numbers in Array 2 (copied from array 1): " << endl;
    CopyPrimeNumInArray(Array, Length, Array2, Length2);
    



    return 0;
}