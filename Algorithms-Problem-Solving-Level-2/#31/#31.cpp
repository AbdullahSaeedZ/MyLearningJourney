#include <iostream>
#include <cstdlib>    
#include <ctime>
#include <string>
using namespace std;


int RandomNumber(int From, int To)
{
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);

    return Number;
}

void FillArrayWith1toN(int Array[100], int& Length)
{
    Length = ReadPositiveNumber("Enter how many Numbers do you need: ");

    for (int Counter = 0; Counter < Length; Counter++)
    {
        Array[Counter] = Counter + 1;
    }
}

void PrintArray(int Array[100], int Length)
{

    for (int Counter = 0; Counter < Length; Counter++)
    {
        cout << Array[Counter] << " ";
    }

    cout << endl;
}

void Swap(int &A, int &B)
{
    int Temp;

    Temp = A;
    A = B;
    B = Temp;
}



void ShuffleArrayElements(int Array[100], int Length)
{
    

    for (int Counter = 0; Counter < Length; Counter++)
    {
        Swap(Array[RandomNumber(0, Length - 1)], Array[RandomNumber(0, Length - 1)]);
    }

}



int main()
{
    srand((unsigned)time(NULL));

    int Array[100], Length;
    FillArrayWith1toN(Array, Length);

    cout << "\nArray elements before shuffle: " << endl;
    PrintArray(Array, Length);

    ShuffleArrayElements(Array, Length);

    cout << "\nArray elements after shuffle:" << endl;
    PrintArray(Array, Length);

    return 0;
}

