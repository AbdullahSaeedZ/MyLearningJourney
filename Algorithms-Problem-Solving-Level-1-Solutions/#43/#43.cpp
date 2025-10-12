#include <iostream>
using namespace std;

struct stTaskduration {
    int Day, Hour, Minute, Second;
};

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number <= 0);

    return Number;
}



stTaskduration SecondsToDuration(int TaskInSeconds)
{
    stTaskduration TaskDuration;
    int SecondsLeft;

    TaskDuration.Day = floor(TaskInSeconds / 86400);
    SecondsLeft = TaskInSeconds % 86400;

    TaskDuration.Hour = floor(SecondsLeft / 3600);
    SecondsLeft = SecondsLeft % 3600;

    TaskDuration.Minute = floor(SecondsLeft / 60);
    SecondsLeft = SecondsLeft % 60;

    TaskDuration.Second = SecondsLeft;

    return TaskDuration;
}

void PrintTaskDuration(stTaskduration TaskDuration)
{
    cout << "D" << TaskDuration.Day << " : H" << TaskDuration.Hour << " : M" << TaskDuration.Minute << " : S" << TaskDuration.Second << endl;
}


int main()
{
    int TaskInSeconds = ReadPositiveNumber("Enter time duration in seconds:");
    PrintTaskDuration(SecondsToDuration(TaskInSeconds));

    return 0;

}

