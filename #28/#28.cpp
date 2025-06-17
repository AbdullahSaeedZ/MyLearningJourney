#include <iostream>
using namespace std;

enum NumberType {Even = 1, Odd =2};

int ReadNumber()
{
    int N;
    cout << "Enter a number to print sum of its odd numbers: " << endl;
    cin >> N;

    return N;
}

NumberType CheckNumberType(int Number)
{
    if (Number % 2 == 0)
        return NumberType::Even;
    else
        return NumberType::Odd;

}

void CountingUsingForLoop(int N)
{
    int Sum = 0;
    for (int Counter = 1; Counter <= N; Counter++)
    {
        if (CheckNumberType(Counter) == NumberType::Odd)
        {
            Sum += Counter;
        }
    }
    cout << "Sum is : " << Sum << endl;
}

void CountingUsingDoLoop(int N)
{
    int Sum = 0;
    int Counter = 1;
    do
    {
        if (CheckNumberType(Counter) == NumberType::Odd)
        {
            Sum += Counter;
        }
        Counter++;
    } while (Counter <= N);

    cout << "Sum is : " << Sum << endl;

}

void CountingUsingWhileLoop(int N)
{
    int Sum = 0;
    int Counter = 1;
    while (Counter <= N)
    {
        if (CheckNumberType(Counter) == NumberType::Odd)
        {
            Sum += Counter;
        }
        Counter++;
    }



    cout << "Sum is : " << Sum << endl;
}


int main()
{
    int N = ReadNumber();

    CountingUsingForLoop(N);
    CountingUsingDoLoop(N);
    CountingUsingWhileLoop(N);

    return 0;
}