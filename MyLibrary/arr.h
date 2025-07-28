#pragma once


#include <iostream>
#include "str.h"
#include "in.h"
#include "rnd.h"
#include "num.h"

using namespace std;

namespace arr
{
    
    
    void ReadArray(int Array[100], int& Length)
    {
        Length = in::ReadPositiveNumber("Enter how many elements do you need: ");

        cout << "Enter value of elements: " << endl;

        for (int Counter = 0; Counter < Length; Counter++)
        {
            cout << "Element [" << Counter + 1 << "] : " << endl;
            cin >> Array[Counter];
        }
    }

    void AddArrayElement(int Array[100], int& Length, int Num)
    {
        Length++;
        Array[Length - 1] = Num;
    }

    void SemiDynamicUserInputArray(int Array[100], int& Length)
    {
        Length = 0;
        bool AddMore = true;

        do
        {
            AddArrayElement(Array, Length, in::ReadPositiveNumber("Enter a number:"));
            cout << "Do you want to add more numbers? [0] No - [1] Yes" << endl;;
            cin >> AddMore;

        } while (AddMore);
    }

    void PrintArray(int Array[100], int Length)
    {

        for (int Counter = 0; Counter < Length; Counter++)
        {
            cout << Array[Counter] << " ";
        }

        cout << endl;
    }

    void FillRandomNumsInArray(int Array[100], int& Length)
    {
        cout << endl;
        Length = in::ReadPositiveNumber("Enter how many elements do you need:");
        cout << endl;

        for (int Counter = 0; Counter < Length; Counter++)
        {
            Array[Counter] = rnd::RandomNumber(1, 100);
        }
    }

    void FillArrayWith1toN(int Array[100], int& Length)
    {
        Length = in::ReadPositiveNumber("Enter how many Numbers do you need: ");

        for (int Counter = 0; Counter < Length; Counter++)
        {
            Array[Counter] = Counter + 1;
        }
    }

    void FillArrayWithKeys(string Array[100], int& Length)
    {
        Length = in::ReadPositiveNumber("Enter how many Keys do you need: ");

        for (int Counter = 0; Counter < Length; Counter++)
        {
            Array[Counter] = rnd::GenerateKey();
        }
    }

    int GetFreqOfNumInArray(int Array[100], int NumToCheck, int Length)
    {
        int Freq = 0;

        for (int Counter = 0; Counter < Length; Counter++)
        {
            if (Array[Counter] == NumToCheck)
            {
                Freq++;
            }
        }

        return Freq;
    }

    bool IsNumEven(int Num)
    {
        if (Num % 2 != 0)
            return false;

        return true;
    }

    int GetFreqOfOddNumInArray(int Array[100], int Length)
    {
        int Freq = 0;

        for (int Counter = 0; Counter < Length; Counter++)
        {
            if (!IsNumEven(Array[Counter]))
            {
                Freq++;
            }
        }

        return Freq;
    }

    int FindNumIndexInArray(int Array[100], int Length, int NumToFind)
    {

        for (int Counter = 0; Counter < Length; Counter++)
        {
            if (Array[Counter] == NumToFind)
            {
                return Counter;
            }

        }

        return -1;
    }

    bool IsNumInArray(int Array[100], int Length, int NumToFind)
    {
        return FindNumIndexInArray(Array, Length, NumToFind) != -1;
    }

    int FindMaxArray(int Array[100], int Length)
    {
        int Max = Array[0];

        for (int Counter = 0; Counter < Length; Counter++)
        {
            if (Array[Counter] > Max)
            {

                Max = Array[Counter];
            }
        }

        return Max;
    }

    int FindMinArray(int Array[100], int Length)
    {
        int Min = Array[0];

        for (int Counter = 0; Counter < Length; Counter++)
        {
            if (Array[Counter] < Min)
            {

                Min = Array[Counter];
            }
        }

        return Min;
    }

    int SumAllArray(int Array[100], int Length)
    {
        int Sum = 0;

        for (int Counter = 0; Counter < Length; Counter++)
        {
            Sum += Array[Counter];
        }

        return Sum;
    }

    float AvgAllArray(int Array[100], int Length)
    {
        return (float)SumAllArray(Array, Length) / Length;
    }

    void CopyArray(int Original[100], int Copy[100], int OriginalLength)
    {
        for (int Counter = 0; Counter < OriginalLength; Counter++)
        {
            Copy[Counter] = Original[Counter];
        }
    }

    void CopyArrayUsingAddArrayElement(int Array1[100], int Length1, int Array2[100], int& Length2)
    {
        for (int Counter = 0; Counter < Length1; Counter++)
        {
            AddArrayElement(Array2, Length2, Array1[Counter]);
        }
    }

    void CopyOddNumArrayUsingAddArrayElement(int Array1[100], int Length1, int Array2[100], int& Length2)
    {
        for (int Counter = 0; Counter < Length1; Counter++)
        {
            if (Array1[Counter] % 2 != 0)
                AddArrayElement(Array2, Length2, Array1[Counter]);
        }
    }

    void CopyPrimeNumArrayUsingAddArrayElement(int Array1[100], int Length1, int Array2[100], int& Length2)
    {
        for (int Counter = 0; Counter < Length1; Counter++)
        {
            if (num::IsPrimeNum(Array1[Counter]))
                AddArrayElement(Array2, Length2, Array1[Counter]);
        }
    }

    void CopyDistinctArrayUsingAddArrayElement(int Array1[100], int Length1, int Array2[100], int& Length2)
    {
        for (int Counter = 0; Counter < Length1; Counter++)
        {
            if (!IsNumInArray(Array2, Length2, Array1[Counter]))
                AddArrayElement(Array2, Length2, Array1[Counter]);
        }
    }

    void CopyArrayInReverseOrder(int Original[100], int Copy[100], int OriginalLength)
    {

        for (int Counter = 0; Counter < OriginalLength; Counter++)
        {
            Copy[Counter] = Original[OriginalLength - 1 - Counter];
        }
    }

    void ShuffleArrayElements(int Array[100], int Length)
    {


        for (int Counter = 0; Counter < Length; Counter++)
        {
            num::Swap(Array[rnd::RandomNumber(0, Length - 1)], Array[rnd::RandomNumber(0, Length - 1)]);
        }

    }

    bool IsArrayPalindrome(int Array[100], int Length)
    {
        for (int Counter = 0; Counter < Length / 2; Counter++)
        {
            if (Array[Counter] != Array[Length - 1 - Counter])
            {
                return false;
            }
        }
        return true;
    }

    int CountPositiveNumsInArray(int Array[100], int Length)
    {
        int Freq = 0;

        for (int Counter = 0; Counter < Length; Counter++)
        {
            if (Array[Counter] >= 0)
            {
                Freq++;
            }
        }

        return Freq;

    }




}