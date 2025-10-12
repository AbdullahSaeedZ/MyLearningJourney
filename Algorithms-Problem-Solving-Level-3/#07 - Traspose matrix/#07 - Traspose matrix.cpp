#include <iostream>
#include <iomanip>
using namespace std;

void FillOrderedNumsInMatrix(int matrix[3][3])
{
    int Counter = 0;
    for (int row = 0; row < 3; row++)
    {
        for (int col = 0; col < 3; col++)
        {
            matrix[row][col] = ++Counter;

        }
    }

}

void TransposeMatrix(int matrix[3][3])
{
    int counter = 0;
    for (int col = 0; col < 3; col++)   // just used row counter for columns and vice versa.
    {
        for (int row = 0; row < 3; row++)
        {
            matrix[row][col] = ++counter;
        }
    }

}

void PrintMatrix(int matrix[3][3])
{
   
    for (int row = 0; row < 3; row++)
    {
        for (int col = 0; col < 3; col++)
        {
            cout << setw(3) << matrix[row][col] << "   ";
        }
        cout << endl;
    }
}


int main()
{

    int matrix[3][3];
    FillOrderedNumsInMatrix(matrix);
    cout << "This is an ordered 3x3 matrix:" << endl;
    PrintMatrix(matrix);

    cout << "This is a transposed matrix:" << endl;
    TransposeMatrix(matrix);
    PrintMatrix(matrix);

    return 0;
}