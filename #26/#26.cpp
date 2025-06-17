#include <iostream>
using namespace std;

int ReadNumber()
{
    int N;
    cout << "Enter a number to start counting to: " << endl;
    cin >> N;

    return N;
}

void CountingUsingForLoop(int N)
{
    cout << "Counting will start from 1 to " << N << endl;
    for (int Counter = 1; Counter <= N; Counter++)
    {
        cout << Counter << endl;
    }
}

void CountingUsingDoLoop(int N)
{
    cout << "Counting will start from 1 to " << N << endl;

    int Counter = 1;

    do
    {
        cout << Counter << endl;
        Counter++;
    } while (Counter <= N);

}

void CountingUsingWhileLoop(int N)
{
    cout << "Counting will start from 1 to " << N << endl;

    int Counter = 1;
    while (Counter <= N)
    {
        cout << Counter << endl;
        Counter++;
    }

}


int main()
{
    int N = ReadNumber();

    CountingUsingForLoop(N);
    CountingUsingDoLoop(N);
    CountingUsingWhileLoop(N);

    return 0;
}
