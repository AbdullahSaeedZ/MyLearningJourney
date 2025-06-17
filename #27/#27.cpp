#include <iostream>
using namespace std;

int ReadNumber()
{
    int N;
    cout << "Enter a number to start counting from to 1: " << endl;
    cin >> N;

    return N;
}

void CountingUsingForLoop(int N)
{
    cout << "Counting will start from " << N << " to 1:" << endl;
    for (N; N >= 1; N--)
    {
        cout << N << endl;
    }
}

void CountingUsingDoLoop(int N)
{
    cout << "Counting will start from " << N << " to 1:" << endl;

    do
    {
        cout << N << endl;
        N--;
    } while (N >= 1);

}

void CountingUsingWhileLoop(int N)
{
    cout << "Counting will start from " << N << " to 1:" << endl;

    
    while (N >= 1)
    {
        cout << N << endl;
        N--;
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