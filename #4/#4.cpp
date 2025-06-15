#include <iostream>
using namespace std;

struct stInfo
{
    int Age;
    bool DrivingLicense;

};

stInfo ReadInputs()
{
    stInfo UserInfo;

    cout << "Please enter your age: " << endl;
    cin >> UserInfo.Age;
    cout << "Do you have a driving license ? (1 for yes and 0 for no): " << endl;
    cin >> UserInfo.DrivingLicense;

    return UserInfo;
}

bool IsAccepted(stInfo Info)
{
    
    return (Info.Age > 21 && Info.DrivingLicense == true);
}

void PrintResult(stInfo Info)
{
    if (IsAccepted(Info))
    {
        cout << "You are hired! " << endl;
    }
    else
    {
        cout << "You are rejected! " << endl;
    }

}

int main()
{
    
    PrintResult(ReadInputs());

    return 0;
}

