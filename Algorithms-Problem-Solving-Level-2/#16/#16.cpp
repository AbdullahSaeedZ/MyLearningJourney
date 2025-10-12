#include <iostream>
using namespace std;


void PrintLetterAtoZ()
{
    for (int L1 = 65; L1 <= 90; L1++)
    {

        for (int L2 = 65; L2 <= 90; L2++)
        {
            for (int L3 = 65; L3 <= 90; L3++)
            {
                cout << char(L1);
                cout << char(L2);
                cout << char(L3) << endl;
            }
        }
        
       
    }

}


int main()
{

    PrintLetterAtoZ();

    return 0;

}

