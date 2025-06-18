#include <iostream>
using namespace std;

int ReadGrade()
{
    int Mark;
    cout << "Enter your Mark:" << endl;
    cin >> Mark;

    return Mark;
}

char CheckGrade(int Mark)
{
    if (Mark >= 90)
        return 'A';
    else if (Mark >= 80)
        return 'B';
    else if (Mark >= 80)
        return 'C';
    else if (Mark >= 80)
        return 'D';
    else if (Mark >= 80)
        return 'E';
    else
        return 'F';
}

void PrintGrade(char Check)
{
    cout << "Your grade is: " << Check << endl;
}


int main()
{
    PrintGrade(CheckGrade(ReadGrade()));

    return 0;
}

