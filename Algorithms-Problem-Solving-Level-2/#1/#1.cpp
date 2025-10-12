#include <iostream>
using namespace std;


void PrintHeader()
{
    cout << "\n\n\t\t\t Multiplication Table from 1 to 10\n" << endl;

    for (int Counter = 1; Counter <= 10; Counter++)
    {
        cout << "\t" << Counter;

    }

    cout << "\n____________________________________________________________________________________" << endl;
}

void PrintTable()
{
    PrintHeader();

    for (int Counter = 1; Counter <= 10; Counter++)  //printing rows
    {
        if (Counter == 10)
        {
            cout << Counter << "  |  ";
        }
        else
        {
            cout << Counter << "   |  ";
        }


        for (int Num = 1; Num <= 10; Num++) //printin columns
        {
            cout << Num * Counter << "\t";
        }

        cout << endl;
    }
}


int main()
{
    
    PrintTable();

    return 0;
}

