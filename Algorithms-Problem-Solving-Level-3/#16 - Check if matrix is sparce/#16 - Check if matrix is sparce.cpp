#include <iostream>
using namespace std;


int CountFreqInMatrix(int matrix1[3][3], int Number)  // from last problem (reusability)
{

	int Freq = 0;

	for (int row = 0; row < 3; row++)
	{
		for (int col = 0; col < 3; col++)
		{
			if (matrix1[row][col] == Number)
				Freq++;
		}
	}

	return Freq;
}


bool IsMatrixSparce(int matrix1[3][3])
{
	short MatrixHalfSize = ceil((float)(3 * 3) / 2);

	return (CountFreqInMatrix(matrix1, 0) >= MatrixHalfSize); //if number of 0s is equal or more than half size of matrix, return true
}

void PrintMatrixResult(int matrix1[3][3])
{
	if (IsMatrixSparce(matrix1))
		cout << "\nYes, matrix is Sparce" << endl;
	else
		cout << "\nNo, matrix is not Sparce" << endl;
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


	// this a Sparce matrix (the number of 0s is more than other numbers)
	int matrix1[3][3] =
	{
		{0, 0, 12 },
		{5, 5, 1 },
		{0, 0, 9 }
	};

	cout << "\nMatrix 1:" << endl;
	PrintMatrix(matrix1);

	PrintMatrixResult(matrix1);


	return 0;
}