#include <iostream>
using namespace std;


bool IsMatrixScalar(int matrix1[3][3])
{
	// check that diagonal elements are same numbers and the rest are 0

	int FirstElement = matrix1[0][0];
	

	for (int row = 0; row < 3; row++)
	{
		for (int col = 0; col < 3; col++)
		{

			if (row == col && matrix1[row][col] != FirstElement) // for checking diagonal elements if all are same numbers
				return false;

			if (row != col && matrix1[row][col] != 0) // for the rest elements to be 0s
				return false;

		}

	}

	return true;
}

void PrintMatrixResult(int matrix1[3][3])
{
	if (IsMatrixScalar(matrix1))
		cout << "\nYes, matrix is scalar" << endl;
	else
		cout << "\nNo, matrix is not scalar" << endl;
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


	// this a scalar matrix (the shape of diagonal but numbers are same and rest are 0s)
	int matrix1[3][3] =
	{
		{9, 0, 0 },
		{0, 9, 0 },
		{0, 0, 9 }
	};

	cout << "\nMatrix 1:" << endl;
	PrintMatrix(matrix1);

	PrintMatrixResult(matrix1);


	return 0;
}