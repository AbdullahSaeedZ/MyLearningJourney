#include <iostream>
#include <cstdlib>    
#include <ctime>
#include <string>
using namespace std;


int RandomNumber(int From, int To)
{
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

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

int main()
{
    srand((unsigned)time(NULL));

    GenerateKeys(ReadPositiveNumber("Enter how many keys to generate: "));

    return 0;
    
}

// each function is generic and can be reused. this is a perfect example.