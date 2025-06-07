#include <iostream>
using namespace std;

void ReadInputs(short int& D, short int& H, short int& M, short int& S)
{
    cout << "Please enter the task time in Days, Hours, Minutes and Seconds: " << endl;
    cin >> D >> H >> M >> S;
}

int CalculateTime(short int D, short int H, short int M, short int S) //data type of function must be int not short cuz result is high.
{   
    // if fprmula is simple, no need to declare a variable, just put it in the return, but if complex and needed then declare a variable.

    int InSeconds = (D * 86400) + (H * 3600) + (M * 60) + S; 
    return InSeconds;
}

void ShowResult(short int D, short int H, short int M, short int S)
{
    cout << "Task duration in seconds is: " << CalculateTime(D, H, M, S) << endl;
}
int main()
{
    
    short int D, H, M, S;
    ReadInputs(D, H, M, S);
    ShowResult(D, H, M, S);

    return 0;
}
