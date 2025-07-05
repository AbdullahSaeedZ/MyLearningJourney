#pragma once

// #include "C:\Users\asz14\Documents\CPP-Level2\MyLibrary\MyLib.h"

#include <iostream>
#include <cstdlib>    
#include <ctime>
#include <string>


namespace MyLib
{


    std::string Tabs(short N)
    {
        std::string t = "\t";

        for (short Counter = 1; Counter <= N; Counter++)
        {
            t += "\t";
        }
        return t;
    }

    short ReadPositiveNumInRange(std::string Message, short From, short To)
    {
        int Number = 0;
        do
        {
            std::cout << Message << std::endl;
            std::cin >> Number;

            if (std::cin.fail())
            {
                // if other than numbers entered system will fail.
                std::cin.clear();                // to clear the failure
                std::cin.ignore(10000, '\n');    // to ignore what was entered before, to clean the buffer
                std::cout << "Invalid input! Please enter a number." << std::endl;
                continue;
            }

        } while (Number < From || Number > To);

        return Number;
    }

    int ReadPositiveNumber(std::string Message)
    {
        int Number = 0;
        do
        {
            std::cout << Message << std::endl;
            std::cin >> Number;

            if (std::cin.fail())
            {
                // if other than numbers entered system will fail.
                std::cin.clear();                // to clear the failure
                std::cin.ignore(10000, '\n');    // to ignore what was entered before, to clean the buffer
                std::cout << "Invalid input! Please enter a number." << std::endl;
                continue;
            }

        } while (Number <= 0);

        return Number;
    }

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

    // Random Generating

   // srand((unsigned)time(NULL));
   
    int RandomNumber(int From, int To)
    {
        int randNum = rand() % (To - From + 1) + From;
        return randNum;
    }

    enum enCharType { SmallLetter = 1, CapitalLetter = 2, SpecialCharacter = 3, Digit = 4 };
    char GetRandomCharacter(enCharType Type)
    {

        if (Type == enCharType::CapitalLetter)
            return char(RandomNumber(65, 90));

        else if (Type == enCharType::Digit)
            return char(RandomNumber(49, 57));

        else if (Type == enCharType::SmallLetter)
            return char(RandomNumber(97, 122));

        else
            return char(RandomNumber(33, 47));

    }

    std::string GetRandomWord(enCharType CharType, short Length)
    {
        std::string Word = "";

        for (int Counter = 1; Counter <= Length; Counter++)
        {
            Word.append(1, GetRandomCharacter(CharType));
        }

        return Word;
    }

    std::string GenerateKey()
    {
        std::string Key = "";

        for (int Counter = 1; Counter <= 4; Counter++)    // 4 is number of slots (how many words in this key to be generated.
        {
            if (Counter == 4) // to eliminate the "-" in the end and exit function.
            {
                return Key = Key + GetRandomWord(enCharType::CapitalLetter, 4);
            }

            Key = Key + GetRandomWord(enCharType::CapitalLetter, 4) + "-";

        }

        return Key;
    }

    void GenerateKeys(int RequiredKeys)
    {
        for (int Counter = 1; Counter <= RequiredKeys; Counter++)
        {
            std::cout << "Key [" << Counter << "] : " << GenerateKey() << std::endl;
        }

    }

    // Arrays

    void ReadArray(int Array[100], int& Length)
    {
        Length = ReadPositiveNumber("Enter how many elements do you need: ");

        std::cout << "Enter value of elements: " << std::endl;

        for (int Counter = 0; Counter < Length; Counter++)
        {
            std::cout << "Element [" << Counter + 1 << "] : " << std::endl;
            std::cin >> Array[Counter];
        }
    }


    void SemiDynamicUserInputArray(int Array[100], int& Length)
    {
        Length = 0;
        bool AddMore = true;

        do
        {
            AddArrayElement(Array, Length, ReadPositiveNumber("Enter a number:"));
            std::cout << "Do you want to add more numbers? [0] No - [1] Yes" << std::endl;;
            std::cin >> AddMore;

        } while (AddMore);
    }

    void PrintArray(int Array[100], int Length)
    {

        for (int Counter = 0; Counter < Length; Counter++)
        {
            std::cout << Array[Counter] << " ";
        }

        std::cout << std::endl;
    }

    void FillRandomNumsInArray(int Array[100], int& Length)
    {
        std::cout << std::endl;
        Length = ReadPositiveNumber("Enter how many elements do you need:");
        std::cout << std::endl;

        for (int Counter = 0; Counter < Length; Counter++)
        {
            Array[Counter] = RandomNumber(1, 100);
        }
    }

    void FillArrayWith1toN(int Array[100], int& Length)
    {
        Length = ReadPositiveNumber("Enter how many Numbers do you need: ");

        for (int Counter = 0; Counter < Length; Counter++)
        {
            Array[Counter] = Counter + 1;
        }
    }

    void FillArrayWithKeys(std::string Array[100], int& Length)
    {
        Length = ReadPositiveNumber("Enter how many Keys do you need: ");

        for (int Counter = 0; Counter < Length; Counter++)
        {
            Array[Counter] = GenerateKey();
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

    void AddArrayElement(int Array[100], int& Length, int Num)
    {
        Length++;
        Array[Length - 1] = Num;
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
            if (IsPrimeNum(Array1[Counter]))
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
            Swap(Array[RandomNumber(0, Length - 1)], Array[RandomNumber(0, Length - 1)]);
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
