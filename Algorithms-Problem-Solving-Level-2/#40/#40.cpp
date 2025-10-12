#include <iostream>
using namespace std;

void AddArrayElement(int Array[100], int& Length, int Num)
{
    Length++;
    Array[Length - 1] = Num;
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

void CopyDistinctArrayUsingAddArrayElement(int Array1[100], int Length1, int Array2[100], int& Length2)
{
    for (int Counter = 0; Counter < Length1; Counter++)
    {
        if(!IsNumInArray(Array2, Length2, Array1[Counter]))
        AddArrayElement(Array2, Length2, Array1[Counter]);
    }
}

void PrintArray(int Array[100], int Length)
{

    for (int Counter = 0; Counter < Length; Counter++)
    {
        cout << Array[Counter] << " ";
    }

    cout << endl;
}

int main()
{
    int Array1[10] = { 10, 10, 10, 50, 50, 70, 70, 70, 70, 90 }, Length1 = 10, Array2[10], Length2 = 0;

    CopyDistinctArrayUsingAddArrayElement(Array1, Length1, Array2, Length2);

    cout << "Array1 elements:" << endl;
    PrintArray(Array1, Length1);

    cout << "Array2 distinct elements:" << endl;
    PrintArray(Array2, Length2);


    return 0;
}

