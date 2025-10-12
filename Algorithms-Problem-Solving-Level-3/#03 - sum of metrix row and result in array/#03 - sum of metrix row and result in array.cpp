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

int SumMatrixRow(int matrix[3][3], int RowNumber, int SizeOfColmn)
{
	int sum = 0;

	for (int colmn = 0; colmn < SizeOfColmn; colmn++)
	{
		sum += matrix[RowNumber][colmn];
	}

	return sum;
}

void SaveSumToArray(int matrix[3][3], int array[3])
{


	for (int row = 0; row < 3; row++)
	{
		array[row] = SumMatrixRow(matrix, row, 3);
		
	}
}

void PrintSumOfMatrixRows(int array[3])
{


	cout << "\nThe sum of each row in the marix: " << endl;

	for (int row = 0; row < 3; row++)
	{
		cout << "Row " << row + 1 << " Sum = " << array[row] << endl;
	}
}

int main()
{
	srand((unsigned)time(NULL));

	// matrix is a 2-dimensional array

	int Matrix[3][3], SumResults[3];

	RandomNumsMatrix(Matrix);
	PrintMatrix(Matrix);
	SaveSumToArray(Matrix, SumResults);
	PrintSumOfMatrixRows(SumResults);
	

	return 0;
}