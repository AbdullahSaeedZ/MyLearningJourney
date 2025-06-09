#include <iostream>
using namespace std;

void ReadMark(short int& Mark)
{
    cout << "Please enter your mark:" << endl;
    cin >> Mark;
}

void PrintResult(short int Mark)
{
    if (Mark >= 50)
    {
        cout << "Pass" << endl;
    }
    else
    {
        cout << "Fail" << endl;
    }
}


int main()
{
    short int Mark;
    ReadMark(Mark);
    PrintResult(Mark);

    return 0;
}

