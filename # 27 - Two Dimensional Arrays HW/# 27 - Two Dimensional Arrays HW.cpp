#include <iostream>
using namespace std;

void MultiplicationTable(int x[100][100])
{
    for (int row = 0; row < 10; row++)
    {
        for (int colmn = 0; colmn < 10; colmn++)
        {
            x[row][colmn] = (row + 1) * (colmn + 1);
        }
    }
}


void Print2DimensionalArray(int x[100][100])
{
    for (int row = 0; row < 10; row++)
    {
        for (int colmn = 0; colmn < 10; colmn++)
        {
            printf("%02d ", x[row][colmn]);
        }

        cout << endl;
    }
}

int main()
{
    int x[100][100];

    MultiplicationTable(x);
    Print2DimensionalArray(x);

    

    return 0;
}

