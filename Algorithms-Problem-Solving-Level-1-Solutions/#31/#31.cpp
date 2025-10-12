#include <iostream>
using namespace std;

struct stPowers {
    int PowerOf2;
    int PowerOf3;
    int PowerOf4;
};

int ReadNumber()
{
    int N = 0;
    cout << "Enter a number: " << endl;
    cin >> N;

    return N;
}

stPowers CalculatePower(int N)
{
    stPowers Result;

    Result.PowerOf2 = N * N;
    Result.PowerOf3 = N * N * N;
    Result.PowerOf4 = N * N * N * N;

    return Result;
}

void PrintResult(int N)
{
    cout << N << "^2 = " << CalculatePower(N).PowerOf2 << endl;
    cout << N << "^3 = " << CalculatePower(N).PowerOf3 << endl;
    cout << N << "^4 = " << CalculatePower(N).PowerOf4 << endl;
}


int main()
{
    PrintResult(ReadNumber());

    return 0;
}

