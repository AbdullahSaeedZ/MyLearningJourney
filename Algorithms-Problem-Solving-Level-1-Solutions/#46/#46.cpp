#include <iostream>
using namespace std;

void PrintLetters()
{
    for (int Counter = 65; Counter <= 90; Counter++)
    {
        cout << char(Counter) << endl;

    }
}

int main()
{
    PrintLetters();

    return 0;
}

