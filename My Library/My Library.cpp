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

enum enPrimeNoPrime { Prime = 1, NotPrime = 2 };
enPrimeNoPrime CheckNumber(int Number)
{
    float M = round(Number / 2);
    for (int Counter = 2; Counter <= M; Counter++)
    {
        if (Number % Counter == 0)
            return enPrimeNoPrime::NotPrime;

    }

    return enPrimeNoPrime::Prime;
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