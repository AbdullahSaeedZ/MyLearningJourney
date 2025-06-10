#include <iostream>
using namespace std;

int ReadInput()
{
    int N;
    cout << "please enter a number: " << endl;
    cin >> N;
    cout << endl;

    return N;
}

void Counter(int UserInput)
{
    int Start;
    

    for (Start = 1; Start <= UserInput; Start++)
    {
        cout << Start << endl;
    }
}

int main()
{
    int UserInput = ReadInput();
    Counter(UserInput);
}


// i could have done it all in one procedure, but clean code is to have one function for one job. so here one finction to read then one procedure to print.