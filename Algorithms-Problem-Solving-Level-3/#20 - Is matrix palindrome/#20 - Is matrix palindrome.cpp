#include <iostream>
#include "MyLib.h"
using namespace std;
using namespace MyLib;

bool IsMatrixPalindrome(int matrix[4][4], int Rows, int Cols)
{
    for (int r = 0; r < Rows; r++)
    {
        for (int c = 0; c < Cols / 2; c++)
        {
            if (matrix[r][c] != matrix[r][Cols - 1 - c])
                return false;
        }
    }

    return true;
}



int main()
{
    int matrix[4][4] =
    {
        {1, 2, 2, 1},
        {5, 5, 5, 5},
        {7, 3, 3, 7},
        {7, 3, 3, 7}
    };

    cout << "Matrix:" << endl;
    PrintMatrix(matrix);

    if (IsMatrixPalindrome(matrix, 4, 4))
        cout << "Yes, it is palindrome" << endl;
    else
        cout << "No, it is not palindrome" << endl;



    return 0;
}

