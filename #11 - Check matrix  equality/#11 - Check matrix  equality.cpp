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
			matrix[row][colmn] = RandomNumber(1, 10);
		}
	}
}

int SumMatrixElements(int matrix[3][3])
{
	int sum = 0;
	for (int row = 0; row < 3; row++)
	{
		for (int col = 0; col < 3; col++)
		{
			sum += matrix[row][col];
		}
	}

	return sum;
}

bool AreMatricesEqual(int matrix1[3][3], int matrix2[3][3])
{
		return (SumMatrixElements(matrix1) == SumMatrixElements(matrix2));
}

void PrintMatrixEquality(int matrix1[3][3], int matrix2[3][3])
{
	if (AreMatricesEqual(matrix1, matrix2))
		cout << "\nYes, both matrices are equal" << endl;
	else
		cout << "\nNo, both matrices are not equal" << endl;
}

void PrintMatrix(int matrix[3][3])
{


	for (int row = 0; row < 3; row++)
	{
		for (int colmn = 0; colmn < 3; colmn++)
		{
			cout << setw(3) << matrix[row][colmn] << "     ";
		}

		cout << endl;
	}
}

int main()
{
	srand((unsigned)time(NULL));


	int matrix1[3][3], matrix2[3][3];

	cout << "\nMatrix 1:" << endl;
	RandomNumsMatrix(matrix1);
	PrintMatrix(matrix1);
	cout << "\nSum of matrix elements = " << SumMatrixElements(matrix1) << endl;

	cout << "\nMatrix 2:" << endl;
	RandomNumsMatrix(matrix2);
	PrintMatrix(matrix2);
	cout << "\nSum of matrix elements = " << SumMatrixElements(matrix2) << endl;

	PrintMatrixEquality(matrix1, matrix2);


	return 0;
}