#include <iostream>
#include <string>
using namespace std;


// using string library, we can declare an array that contains strings. that we will use in funcitons later.
string MonthsOfYear[13] = 
{
    // since index starts from 0, we give it an empty string vale to skipp it.
    "", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
};
void ShowMonths()
{
    cout << "[1]January\n[2]February\n[3]March\n[4]April\n[5]May\n[6]June\n[7]July\n[8]August\n[9]September\n[10]October\n[11]November\n[12]December" << endl;
}

int ReadPositiveNumber(string Message, int From, int To)
{
    int Number = 0;

    ShowMonths();

    cout << Message << endl;
    cin >> Number;

    while (Number < From || Number > To)
    {
        cout << "Wrong Number, enter a valid Number" << endl;
        cin >> Number;
    }

    return Number;
}

string GetMonth(int Number)
{
    return MonthsOfYear[Number];     //this way, the number chosen will be used to call the array and save its string value in this function to e printed later. 
}


int main()
{
    cout << "You selected: " << GetMonth(ReadPositiveNumber("Choose from the menu a number:", 1, 12));

    return 0;
}

