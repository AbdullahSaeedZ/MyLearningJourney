#include <iostream>
using namespace std;

struct Numbers {
    int Number1;
    int Number2;
    int Number3;
};

Numbers ReadNumbers()
{
    Numbers UserInput;

    cout << "Please enter a number: " << endl;
    cin >> UserInput.Number1;
    cout << "Please enter a number: " << endl;
    cin >> UserInput.Number2;
    cout << "Please enter a number: " << endl;
    cin >> UserInput.Number3;

    return UserInput;
}

int CheckMax(Numbers UserInput)
{
    if (UserInput.Number1 > UserInput.Number2 && UserInput.Number1 > UserInput.Number3)
        return UserInput.Number1;
    else if (UserInput.Number2 > UserInput.Number1 && UserInput.Number2 > UserInput.Number3)
        return UserInput.Number2;
    else
        return UserInput.Number3;
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
