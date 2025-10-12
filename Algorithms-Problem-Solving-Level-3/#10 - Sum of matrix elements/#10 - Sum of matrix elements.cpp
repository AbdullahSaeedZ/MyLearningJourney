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


	int matrix[3][3];

	cout << "\nMatrix 1:" << endl;
	RandomNumsMatrix(matrix);
	PrintMatrix(matrix);

	cout << "\nSum of matrix elements = " << SumMatrixElements(matrix) << endl;
	




	return 0;
}