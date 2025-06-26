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

int SumAllArray(int Array[100], int Length)
{
    int Sum = 0;

    for (int Counter = 0; Counter < Length; Counter++)
    {
        Sum += Array[Counter];
    }

    return Sum;
}

float AvgAllArray(int Array[100], int Length)
{
    return (float)SumAllArray(Array, Length) / Length;
}

int main()
{
    srand((unsigned)time(NULL));

    int Array[100], Length;

    ReadArray(Array, Length);

    cout << "Array elements: ";
    PrintArray(Array, Length);

    cout << "Average of all Numbers is: " << AvgAllArray(Array, Length) << endl;



    return 0;
}