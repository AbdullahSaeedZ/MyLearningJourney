#include <iostream>
#include <iomanip>
using namespace std;

int RandomNumber(int From, int To)
{
	int randNum = rand() % (To - From + 1) + From;
	return randNum;
}

void RandomNumsMatrix(int matrix[3][3])
{
	for (int row = 0; row < 3; row++)
	{
		for (int colmn = 0; colmn < 3; colmn++)
		{
			matrix[row][colmn] = RandomNumber(1, 100);
		}
	}
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

void SaveSumOfMatrixColsToArray(int matrix[3][3], int array[3])
{
	for (int Counter = 0; Counter < 3; Counter++)
	{
		array[Counter] = SumMatrixCol(matrix, Counter, 3);
	}
}

void PrintMatrix(int matrix[3][3])
{
	cout << "The following is a 3x3 random matrix:" << endl;

	for (int row = 0; row < 3; row++)
	{
		for (int colmn = 0; colmn < 3; colmn++)
		{
			cout << setw(3) << matrix[row][colmn] << "     ";
		}

		cout << endl;
	}
}

void PrintSumOfMatrixCols(int array[3])
{
	cout << "The following are the sum of each column in the matrix: " << endl;

	for (int row = 0; row < 3; row++)
	{
		cout << "col " << row + 1 << " sum = " << array[row] << endl;
	}
}

int main()
{
	srand((unsigned)time(NULL));

	// matrix is a 2-dimensional array

	int matrix[3][3], SumResults[3];

	RandomNumsMatrix(matrix);
	PrintMatrix(matrix);
	SaveSumOfMatrixColsToArray(matrix, SumResults);
	PrintSumOfMatrixCols(SumResults);

	return 0;
}