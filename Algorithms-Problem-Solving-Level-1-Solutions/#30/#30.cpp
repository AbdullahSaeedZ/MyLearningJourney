#include <iostream>
using namespace std;

int ReadPositiveNumber(string Message)  // this a generic function that can be used anywhere and message modification is done without getting inside its details
{
    int Number = 0;
    do 
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number < 0);

    return Number;
}

int GetFactorial(int Number)
{
    int Factorial = 1;
    for (Number; Number >= 1; Number--)
    {
        Factorial = Factorial * Number;
    }

    return Factorial;
}

void PrintFactorial(int Factorial)
{
    cout << "Factorial is: " << Factorial << endl;
}

int main()
{
    PrintFactorial(GetFactorial(ReadPositiveNumber("Enter a positive number:")));

        return 0;
}

