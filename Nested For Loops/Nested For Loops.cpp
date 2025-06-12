#include <iostream>
using namespace std;


int main()
{
    // 5 Homeworks for Nested For Loop:



   /* for (int Letter = 65; Letter <= 90; Letter++)
    {
        
        for (int L = 65; L <= 90; L++)
        {
            cout << char(Letter);
            cout << char(L) << endl;

        }

    }*/


    /*for (int StarRow = 10; StarRow >= 1; StarRow--)
    {
        
        
        for (int Column = 1; Column <= StarRow; Column++)
        {
            cout << "*";
            
        }

       
        cout << endl;
    }*/


    /*for (int Num1 = 10; Num1 >= 1; Num1--)
    {
        for (int Num2 = 1; Num2 <= Num1; Num2++)
        {
            
            cout << Num2;

        }
        
        cout << endl;
    }
    */


   /* for (int Num1 = 1; Num1 <= 10; Num1++)
    {
        for (int Num2 = 1; Num2 <= Num1; Num2++)
        {
            cout << Num2;
        }

        cout << endl;
    }*/


    for (int Letter = 65; Letter <= 70; Letter++)
    {
        for (int L = 65; L <= Letter; L++)
        {
            cout << char(L);
        }

        cout << endl;
    }






    return 0;
}

