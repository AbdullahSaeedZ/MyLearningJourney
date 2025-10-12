#include <iostream>
using namespace std;

void ReadGrade(short int& Mark)
{
    cout << "Pleasse enter your mark:" << endl;
    cin >> Mark;
}

void CheckGrade(short int Mark)
{
    if (Mark >= 90)
    {
        cout << "A" << endl;
    }
    else if (Mark >= 80)
    {
        cout << "B" << endl;
    }
    else if (Mark >= 70)
    {
        cout << "C" << endl;
    }
    else if (Mark >= 60)
    {
        cout << "D" << endl;
    }
    else if (Mark >= 50)
    {
        cout << "E" << endl;
    }
    else
    {
        cout << "F" << endl;
    }
}


int main()
{
    short int Mark;
    ReadGrade(Mark);
    CheckGrade(Mark);

    return 0;
}
