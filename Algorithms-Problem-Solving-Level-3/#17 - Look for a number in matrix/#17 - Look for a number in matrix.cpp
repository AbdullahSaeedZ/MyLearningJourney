#include <iostream>
#include <iomanip>
#include "MyLib.h"
using namespace std;
using namespace MyLib;

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

bool IsNumInMatrix(int matrix[3][3], int Number)
{
	for (int row = 0; row < 3; row++)
	{
		for (int col = 0; col < 3; col++)
		{
			if (matrix[row][col] == Number)
				return true;
		}
	}

	return false;
}

int main()
{
	srand((unsigned)time(NULL));

	// matrix is a 2-dimensional array

	int matrix[3][3];
	RandomNumsMatrix(matrix);

	cout << "Matrix1:" << endl;
	PrintMatrix(matrix);

	if (IsNumInMatrix(matrix, ReadPositiveNumber("\nEnter the number to find in matrix:")))
		cout << "Yes, it is there" << endl;
	else
		cout << "No, it is not there" << endl;
	


	return 0;
}