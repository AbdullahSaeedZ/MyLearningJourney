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

void MultiplyTwoMatrixes(int matrix1[3][3], int matrix2[3][3], int matrix3[3][3])
{
	for (int row = 0; row < 3; row++)
	{
		for (int col = 0; col < 3; col++)
		{
			matrix3[row][col] = matrix1[row][col] * matrix2[row][col];
		}
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


	int matrix1[3][3], matrix2[3][3], results[3][3];

	cout << "\nMatrix 1:" << endl;
	RandomNumsMatrix(matrix1);
	PrintMatrix(matrix1);

	cout << "\nMatrix 2:" << endl;
	RandomNumsMatrix(matrix2);
	PrintMatrix(matrix2);

	cout << "\nResults:" << endl;
	MultiplyTwoMatrixes(matrix1, matrix2, results);
	PrintMatrix(results);




	return 0;
}