#include <iostream>
using namespace std;

struct Numbers {
    int Number1;
    int Number2;
};

Numbers ReadNumbers()
{
    Numbers UserInput;

    cout << "Please enter a number: " << endl;
    cin >> UserInput.Number1;
    cout << "Please enter a number: " << endl;
    cin >> UserInput.Number2;

    return UserInput;
}

int CheckMax(Numbers UserInput)
{
    if (UserInput.Number1 > UserInput.Number2)
        return UserInput.Number1;
    else
        return UserInput.Number2;
}

void PrintMax(Numbers UserInput)
{
    cout << "The max number is: " << CheckMax(UserInput) << endl;
}

int main()
{
    PrintMax(ReadNumbers());

    return 0;
}
