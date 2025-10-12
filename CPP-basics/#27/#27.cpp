#include <iostream>
using namespace std;


int ReadInput()
{
    int N;
    cout << " Enter a number: " << endl;
    cin >> N;
    cout << endl;

    return N;
}

void Counter(int UserInput)
{
    int Start = UserInput;

    for (Start; Start >= 1; Start--)
    {
        cout << Start << endl;
    }

}


int main()
{
    int UserInput = ReadInput();
    Counter(UserInput);

    return 0;
}

