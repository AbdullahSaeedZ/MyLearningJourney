#include <iostream>
using namespace std;


bool IsMatrixIdentity(int matrix1[3][3])
{
	// check that diagonal elements are 1 and the rest are 0

	for (int row = 0; row < 3; row++)
	{
		for (int col = row; col == row; col++)
		{

			if (row == col && matrix1[row][col] != 1) // for diagonal elements 
				return false;

			if (row != col && matrix1[row][col] != 0) // for the rest elements
				return false;

		}
		
	}

	return true;
}

void PrintMatrixResult(int matrix1[3][3])
{
	if (IsMatrixIdentity(matrix1))
		cout << "\nYes, matrix is identity" << endl;
	else
		cout << "\nNo, matrix is not identity" << endl;
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
	

	// this a diagonal matrix (the shape of 1s and rest are 0s)
	int matrix1[3][3] = 
	{
		{1, 0, 0 },
		{0, 1, 0 },
		{0, 0, 1 }
	};

	cout << "\nMatrix 1:" << endl;
	PrintMatrix(matrix1);

	PrintMatrixResult(matrix1);


	return 0;
}