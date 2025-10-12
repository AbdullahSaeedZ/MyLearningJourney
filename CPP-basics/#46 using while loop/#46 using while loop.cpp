#include <iostream>
using namespace std;


void PrintLetters()
{
    int Counter = 65;
    while (Counter <= 90)
    {
        cout << char(Counter) << endl;
        Counter++;
    }

}


int main()
{
    
    PrintLetters();


    return 0;
}

