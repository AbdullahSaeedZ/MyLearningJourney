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

int CountFreqInMatrix(int matrix[3][3], int Number)
{
	
	int Freq = 0;

	for (int row = 0; row < 3; row++)
	{
		for (int col = 0; col < 3; col++)
		{
			if (matrix[row][col] == Number)
				Freq++;
		}
	}

	return Freq;
}

int main()
{
	srand((unsigned)time(NULL));

	// matrix is a 2-dimensional array

	int matrix[3][3];
	RandomNumsMatrix(matrix);

	cout << "Matrix1:" << endl;
	PrintMatrix(matrix);

	int Number = ReadPositiveNumber("\nEnter the number to count in matrix:");
	cout << "\nNumber " << Number << " frequency in matrix is: " << CountFreqInMatrix(matrix, Number) << endl;


	return 0;
}