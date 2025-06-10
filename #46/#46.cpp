#include <iostream>
using namespace std;

void PrintAZ()
{
      // in ASCI code the letters are A =65 then to Z=90.
    

    for (int Counter = 65; Counter <= 90; Counter++)
    {
        
        cout << char(Counter) << endl;    //this function turns integer into letters using ASCI code.
    }
}

int main()
{
    PrintAZ();

    return 0;
}

