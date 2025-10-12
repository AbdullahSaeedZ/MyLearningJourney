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

void ReadElements(int Elements[100] ,int &Length)
{
    Length = ReadPositiveNumber("Enter how many elements do you need: ");

    cout << "Enter value of elements: " << endl;

    for (int Counter = 0; Counter < Length; Counter++)
    {
        cout << "Element [" << Counter + 1 << "] : " << endl;
        cin >> Elements[Counter];
    }
}

void PrintElements(int Elements[100], int Length)
{
           
    for (int Counter = 0; Counter < Length; Counter++)
    {
        cout << Elements[Counter] << " ";
    }
  
    cout << endl;
}


int GetFreq(int Elements[100], int NumToCheck, int Length)
{
    int Freq = 0;

    for (int Counter = 0; Counter < Length; Counter++)
    {
        if (Elements[Counter] == NumToCheck)
        {
            Freq++;
        }
    }

    return Freq;
}

int main()
{
    int Length;
    int Elements[100];
    int NumToCheck;
    ReadElements(Elements, Length);
    
    NumToCheck = ReadPositiveNumber("Enter a number that you want to check:");


    cout << "Original values of elements: ";
    PrintElements(Elements, Length);


    cout << "Frequency of Number " << NumToCheck << " is " << GetFreq(Elements, NumToCheck, Length) << " Time(s)." << endl;



    return 0;
}

