#include <iostream>
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



void PrintLetterInverted(int Num)
{
    int Letter = Num + 64;

    for (int Row = Letter; Row >= 65; Row--)
    {
        for (int Counter = Row; Counter >= 65; Counter--)
        {
            cout << char(Row);
        }

        cout << endl;
    }

}


int main()
{

    PrintLetterInverted(ReadPositiveNumber("Enter a number"));

    return 0;

}



