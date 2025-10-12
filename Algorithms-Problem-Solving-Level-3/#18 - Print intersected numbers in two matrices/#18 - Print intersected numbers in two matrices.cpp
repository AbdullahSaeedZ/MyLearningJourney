#include <iostream>
#include "MyLib.h"
using namespace std;
using namespace MyLib;

void PrintIntersectedNumsInMatrices(int matrix1[3][3], int matrix2[3][3])
{
    for (int row = 0; row < 3; row++)
    {
        for (int col = 0; col < 3; col++)
        {
            if (IsNumInMatrix(matrix2, matrix1[row][col]))
                cout << matrix1[row][col] << "    ";
        }
    }
}

int main()
{
    srand((unsigned)time(NULL));

    int matrix1[3][3], matrix2[3][3];

    FillRandomNumsMatrix(matrix1);
    FillRandomNumsMatrix(matrix2);

    cout << "\nMatrix1:" << endl;
    PrintMatrix(matrix1);

    cout << "\nMatrix2:" << endl;
    PrintMatrix(matrix2);

    cout << "\nIntersected numbers are:" << endl;
    PrintIntersectedNumsInMatrices(matrix1, matrix2);

    system("pause>0");



    return 0;
}

