#include <iostream>
using namespace std;

int main()
{
    
    short int D, H, M, S;

    cout << "Please enter the task time in Days, Hours, Minutes and Seconds: " << endl;
    cin >> D >> H >> M >> S;

    float InSeconds = (D * 86400) + (H * 3600) + (M * 60) + S;

    cout << "Task duration in seconds is: " << InSeconds << endl;

    return 0;
}
