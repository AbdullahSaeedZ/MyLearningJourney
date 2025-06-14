#include <iostream>
using namespace std;

enum enNumType {Even = 1, Odd = 2};

int ReadNumber()
{
    int Num;
    cout << "Enter a number:" << endl;
    cin >> Num;

    return Num;
}

enNumType CheckNumType(int Num)
{
    int Result = Num % 2;

    if (Result == 0)
        return enNumType::Even;
    else
        return enNumType::Odd;
    
}

void PrintNumType(enNumType NumberType)
{
    if (NumberType == enNumType::Even)
        cout << "The number is Even " << endl;
    else
        cout << "The number is Odd" << endl;

}




int main()
{
    PrintNumType(CheckNumType(ReadNumber()));

    return 0;
}

