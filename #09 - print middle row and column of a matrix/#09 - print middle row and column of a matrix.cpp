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

void PrintMatrixMidRow(int matrix[3][3], int Rows, int cols)
{
	int Mid = Rows / 2;
	for (int col = 0; col < cols; col++)
	{
		printf("%02d    ", matrix[Mid][col]);
	}
}

void PrintMatrixMidCol(int matrix[3][3], int Rows, int cols)
{
	int Mid = cols / 2;
	for (int row = 0; row < Rows; row++)
	{
		printf("%02d    ", matrix[row][Mid]);
	}
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

	// matrix is a 2-dimensional array

	int matrix[3][3];

	cout << "\nMatrix:" << endl;
	RandomNumsMatrix(matrix);
	PrintMatrix(matrix);

	cout << "\nMid Row of Matrix:" << endl;
	PrintMatrixMidRow(matrix, 3, 3);

	cout << "\n\nMid Column of Matrix:" << endl;
	PrintMatrixMidCol(matrix, 3, 3);

	cout << "\n\n";


	return 0;
}