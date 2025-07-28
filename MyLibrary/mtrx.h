#pragma once


#include <iostream>
#include <iomanip>
#include "str.h"
#include "in.h"
#include "rnd.h"
#include "num.h"



namespace mtrx
{
    void PrintMatrix(int matrix[3][3])
    {
        cout << "This is an ordered 3x3 matrix:" << endl;
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                cout << setw(3) << matrix[row][col] << "   ";
            }
            cout << endl;
        }
    }

    void FillRandomNumsMatrix(int matrix[3][3])
    {
        for (int row = 0; row < 3; row++)
        {
            for (int colmn = 0; colmn < 3; colmn++)
            {
                matrix[row][colmn] = rnd::RandomNumber(1, 10);
            }
        }
    }

    int CountFreqInMatrix(int matrix[3][3], int Number)
    {

        int Freq = 0;

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (matrix[row][col] == Number)
                    Freq++;
            }
        }

        return Freq;
    }

    int SumMatrixRow(int array[3][3], int RowNumber, int SizeOfColmn)
    {
        int sum = 0;

        for (int colmn = 0; colmn < SizeOfColmn; colmn++)
        {
            sum += array[RowNumber][colmn];
        }

        return sum;
    }

    int SumMatrixCol(int matrix[3][3], int colNumber, int SizeOfRows)
    {
        int sum = 0;

        for (int row = 0; row < SizeOfRows; row++)
        {
            sum += matrix[row][colNumber];
        }

        return sum;
    }

    bool IsNumInMatrix(int matrix[3][3], int Number)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (matrix[row][col] == Number)
                    return true;
            }
        }

        return false;
    }

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



}