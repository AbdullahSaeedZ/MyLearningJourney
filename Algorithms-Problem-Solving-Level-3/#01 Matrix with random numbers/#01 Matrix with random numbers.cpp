#include <iostream>
#include <iomanip>
using namespace std;

int RandomNumber(int From, int To)
{
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

void RandomNumsMatrix(int array[3][3])
{
	for (int row = 0; row < 3; row++)
	{
		for (int colmn = 0; colmn < 3; colmn++)
		{
			array[row][colmn] = RandomNumber(1, 100);
		}
	}
}


void PrintMatrix(int array[3][3])
{
	cout << "The following is a 3x3 random matrix:" << endl;

	for (int row = 0; row < 3; row++)
	{
		for (int colmn = 0; colmn < 3; colmn++)
		{
			cout << setw(3) << array[row][colmn] << "     ";
		}

		cout << endl;
	}
}

int main()
{
	srand((unsigned)time(NULL));

	// matrix is a 2-dimensional array

	int array[3][3];

	RandomNumsMatrix(array);
	PrintMatrix(array);

	return 0;
}

