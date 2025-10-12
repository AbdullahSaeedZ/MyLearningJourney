#pragma once

#include <iostream>
using namespace std;

namespace num
{

    short GetDigitFreqInNum(int Num, int Digit)
    {
        short Freq = 0, Remainder = 0;

        while (Num > 0)
        {
            Remainder = Num % 10;

            if (Remainder == Digit)
            {
                Freq += 1;
            }

            Num = Num / 10;
        }

        return Freq;
    }

    bool IsPrimeNum(int Number)
    {
        float M = round(Number / 2);
        for (int Counter = 2; Counter <= M; Counter++)
        {
            if (Number % Counter == 0)
                return false;

        }

        return true;
    }

    int GetReverseNum(int Num)
    {
        int New = 0, Remainder = 0;

        while (Num > 0)
        {
            Remainder = Num % 10;
            Num = Num / 10;
            New = New * 10 + Remainder;

        }
        return New;
    }

    bool IsPerfectNum(int Num)
    {
        int Sum = 0;

        for (int Counter = 1; Counter < Num; Counter++)
        {
            if (Num % Counter == 0)
            {
                Sum += Counter;
            }
        }

        return Sum == Num;    // if its true it returns true, if not, it returns false
    }

    void Swap(int& A, int& B)
    {
        int Temp;

        Temp = A;
        A = B;
        B = Temp;
    }




}