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

int GetDigitFreqInNum(int Num, int Digit)
{
    int Freq = 0, Remainder = 0;

    while (Num > 0)
    {
        Remainder = Num % 10;

        if (Remainder == Digit)
        {
            Freq += 1;
        }

        Num = Num / 10;
    }

    return Freq;
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

int GetReverseNum(int Num)
{
    int New = 0, Remainder = 0;

    while (Num > 0)
    {
        Remainder = Num % 10;      
        Num = Num / 10;            
        New = New * 10 + Remainder;  

    }
    return New;
}

bool IsPerfectNum(int Num)
{
    int Sum = 0;

    for (int Counter = 1; Counter < Num; Counter++)
    {
        if (Num % Counter == 0)
        {
            Sum += Counter;
        }
    }

    return Sum == Num;    // if its true it returns true, if not, it returns false
}

void Swap(int& A, int& B)
{
    int Temp;

    Temp = A;
    A = B;
    B = Temp;
}

// Random Generating

srand((unsigned)time(NULL));
int RandomNumber(int From, int To)
{
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

enum enCharType { SmallLetter = 1, CapitalLetter = 2, SpecialCharacter = 3, Digit = 4 };
char GetRandomCharacter(enCharType Type)
{

    if (Type == enCharType::CapitalLetter)
        return char(RandomNumber(65, 90));

    else if (Type == enCharType::Digit)
        return char(RandomNumber(49, 57));

    else if (Type == enCharType::SmallLetter)
        return char(RandomNumber(97, 122));

    else
        return char(RandomNumber(33, 47));

}

string GetRandomWord(enCharType CharType, short Length)
{
    string Word = "";

    for (int Counter = 1; Counter <= Length; Counter++)
    {
        Word.append(1, GetRandomCharacter(CharType));
    }

    return Word;
}

string GenerateKey()
{
    string Key = "";

    for (int Counter = 1; Counter <= 4; Counter++)    // 4 is number of slots (how many words in this key to be generated.
    {
        if (Counter == 4) // to eliminate the "-" in the end and exit function.
        {
            return Key = Key + GetRandomWord(enCharType::CapitalLetter, 4);
        }

        Key = Key + GetRandomWord(enCharType::CapitalLetter, 4) + "-";

    }

    return Key;
}

void GenerateKeys(int RequiredKeys)
{
    for (int Counter = 1; Counter <= RequiredKeys; Counter++)
    {
        cout << "Key [" << Counter << "] : " << GenerateKey() << endl;
    }

}

// Arrays

void ReadArray(int Array[100], int& Length)
{
    Length = ReadPositiveNumber("Enter how many elements do you need: ");

    cout << "Enter value of elements: " << endl;

    for (int Counter = 0; Counter < Length; Counter++)
    {
        cout << "Element [" << Counter + 1 << "] : " << endl;
        cin >> Array[Counter];
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

void FillArrayWith1toN(int Array[100], int& Length)
{
    Length = ReadPositiveNumber("Enter how many Numbers do you need: ");

    for (int Counter = 0; Counter < Length; Counter++)
    {
        Array[Counter] = Counter + 1;
    }
}

int GetFreqOfNumInArray(int Array[100], int NumToCheck, int Length)
{
    int Freq = 0;

    for (int Counter = 0; Counter < Length; Counter++)
    {
        if (Array[Counter] == NumToCheck)
        {
            Freq++;
        }
    }

    return Freq;
}

int FindMaxArray(int Array[100], int Length)
{
    int Max = Array[0];

    for (int Counter = 0; Counter < Length; Counter++)
    {
        if (Array[Counter] > Max)
        {

            Max = Array[Counter];
        }
    }

    return Max;
}

int FindMinArray(int Array[100], int Length)
{
    int Min = Array[0];

    for (int Counter = 0; Counter < Length; Counter++)
    {
        if (Array[Counter] < Min)
        {

            Min = Array[Counter];
        }
    }

    return Min;
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

void CopyArray(int Original[100], int Copy[100], int OriginalLength)
{
    for (int Counter = 0; Counter < OriginalLength; Counter++)
    {
        Copy[Counter] = Original[Counter];
    }
}

void CopyPrimeNumInArray(int Original[100], int Length, int Copy[100], int& Length2)
{
    int Length2Counter = 0;

    for (int Counter = 0; Counter < Length; Counter++)
    {
        if (IsPrimeNum(Original[Counter]))
        {
            Copy[Length2Counter] = Original[Counter];
            Length2Counter++;
        }
    }
    Length2 = Length2Counter;
}

void ShuffleArrayElements(int Array[100], int Length)
{


    for (int Counter = 0; Counter < Length; Counter++)
    {
        Swap(Array[RandomNumber(0, Length - 1)], Array[RandomNumber(0, Length - 1)]);
    }

}