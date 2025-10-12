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

void FillArrayWithKeys(string Array[100], int& Length)
{
    Length = ReadPositiveNumber("Enter how many Keys do you need: ");

    for (int Counter = 0; Counter < Length; Counter++)
    {
        Array[Counter] = GenerateKey();
    }
}

void PrintArray(string Array[100], int Length)
{

    for (int Counter = 0; Counter < Length; Counter++)
    {
        cout << "Array [" << Counter << "] : " << Array[Counter] << endl;
    }

    cout << endl;
}

int main()
{
    srand((unsigned)time(NULL));

    string Array[100];
    int Length;
    FillArrayWithKeys(Array, Length);

    cout << "Array Elements:" << endl;
    PrintArray(Array, Length);
}

