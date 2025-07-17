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

bool AreMatricesTypical(int matrix1[3][3], int matrix2[3][3])
{
	
	for (int row = 0; row < 3; row++)
	{
		for (int col = 0; col < 3; col++)
		{
			if (matrix1[row][col] != matrix2[row][col])
				return false;
		}
	}

	return true;
}

void PrintMatrixResult(int matrix1[3][3], int matrix2[3][3])
{
	if (AreMatricesTypical(matrix1, matrix2))
		cout << "\nYes, both matrices are typical" << endl;
	else
		cout << "\nNo, both matrices are not typical" << endl;
}

void PrintMatrix(int matrix[3][3])
{


	for (int row = 0; row < 3; row++)
	{
		for (int colmn = 0; colmn < 3; colmn++)
		{
			printf("%02d   ", matrix[row][colmn]);
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
	

	cout << "\nMatrix 2:" << endl;
	RandomNumsMatrix(matrix2);
	PrintMatrix(matrix2);
	

	PrintMatrixResult(matrix1, matrix2);


	return 0;
}