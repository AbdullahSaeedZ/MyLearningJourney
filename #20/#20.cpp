#include <iostream>
#include <cstdlib>    
#include <ctime>
using namespace std;


int RandomNumber(int From, int To)
{
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

enum enInput {SmallLetter = 1, CapitalLetter = 2, SpecialCharacter = 3, Digit = 4};


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

int main()
{
    srand((unsigned)time(NULL));

    cout << GetRandom(enInput::SmallLetter) << endl;
    cout << GetRandom(enInput::CapitalLetter) << endl;
    cout << GetRandom(enInput::SpecialCharacter) << endl;
    cout << GetRandom(enInput::Digit) << endl;

    return 0;
}

