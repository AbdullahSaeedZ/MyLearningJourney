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

bool IsNumEven(int Num)
{
    if (Num % 2 != 0)
        return false;

    return true;
}

int GetFreqOfOddNumInArray(int Array[100], int Length)
{
    int Freq = 0;

    for (int Counter = 0; Counter < Length; Counter++)
    {
        if (!IsNumEven(Array[Counter]))
        {
            Freq++;
        }
    }

    return Freq;
}

int main()
{
    srand((unsigned)time(NULL));
    
    int Array[100], Length = 0;
    FillRandomNumsInArray(Array, Length);

    cout << "\nArray elements: ";
    PrintArray(Array, Length);

    cout << "\nOdd numbers count is: " << GetFreqOfOddNumInArray(Array, Length);



    return 0;
}

