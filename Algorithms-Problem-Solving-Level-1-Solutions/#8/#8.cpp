#include <iostream>
using namespace std;

enum enStatus {Fail = 0, Pass = 1};

int ReadMark()
{
    int Mark;
    cout << "Enter your mark: " << endl;
    cin >> Mark;

    return Mark;
}

bool CheckMark(int Mark)
{
    if (Mark >= 50)
        return enStatus::Pass;
    else
        return enStatus::Fail;
}

void PrintStatus(int Mark)
{
    if (CheckMark(Mark))
        cout << "You Passed!!" << endl;
    else
        cout << "You Failed!!" << endl;

}


int main()
{
    PrintStatus(ReadMark());

    return 0;
}

