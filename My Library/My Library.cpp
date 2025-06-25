#include <cstdlib>    
#include <ctime>
srand((unsigned)time(NULL));
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

int GetFreq(int Num, int Digit)
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

int GetReverse(int Num)
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


bool IsPerfect(int Num)
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

enum enInput { SmallLetter = 1, CapitalLetter = 2, SpecialCharacter = 3, Digit = 4 };
char GetRandom(enInput Type)
{

    if (Type == enInput::CapitalLetter)
        return char(RandomNumber(65, 90));

    else if (Type == enInput::Digit)
        return char(RandomNumber(49, 57));

    else if (Type == enInput::SmallLetter)
        return char(RandomNumber(97, 122));

    else
        return char(RandomNumber(33, 47));

}