#include <iostream>
#include "MyLib.h"
using namespace std;
using namespace MyLib;

int GetMinNumInMatrix(int matrix[3][3])
{
    int Num = matrix[0][0];
    for (int row = 0; row < 3; row++)
    {
        for (int col = 0; col < 3; col++)
        {
            if (matrix[row][col] < Num)
                Num = matrix[row][col];

        }
    }

    return Num;
}

int GetMaxNumInMatrix(int matrix[3][3])
{
    int Num = matrix[0][0];
    for (int row = 0; row < 3; row++)
    {
        for (int col = 0; col < 3; col++)
        {
            if (matrix[row][col] > Num)
                Num = matrix[row][col];

        }
    }

    return Num;
}

int main()
{
    srand((unsigned)time(NULL));

    int matrix[3][3];
    FillRandomNumsMatrix(matrix);

    cout << "\nMatrix:" << endl;
    PrintMatrix(matrix);

    cout << "\nMin number is: " << GetMinNumInMatrix(matrix) << endl;

    cout << "\nMax number is: " << GetMaxNumInMatrix(matrix) << endl;




    return 0;
}

