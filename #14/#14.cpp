#include <iostream>
using namespace std;

struct UserNumbers {

    int Number1;
    int Number2;
};

UserNumbers ReadNumber()
{
    UserNumbers Numbers;

    cout << "Enter a number: " << endl;
    cin >> Numbers.Number1;
    cout << "Enter a number: " << endl;
    cin >> Numbers.Number2;

    return Numbers;
}

UserNumbers Swap(UserNumbers Numbers)
{
    int Temp;
    Temp = Numbers.Number1;
    Numbers.Number1 = Numbers.Number2;
    Numbers.Number2 = Temp;

    return Numbers;
}

void PrintNumbers(UserNumbers Numbers)
{
    cout << "Before swapping: " << endl;
    cout << Numbers.Number1  << endl << Numbers.Number2 << endl;

    cout << "After swapping: " << endl;
    cout << Swap(Numbers).Number1 << endl << Swap(Numbers).Number2 << endl;
}

int main()
{
    PrintNumbers(ReadNumber());

    return 0;
}
