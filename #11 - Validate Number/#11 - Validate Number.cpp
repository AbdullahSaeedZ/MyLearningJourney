#include <iostream>
using namespace std;


int main()
{
    int Number = 0;

        cout << "Enter a number" << endl;
        cin >> Number;

        while (cin.fail())
        {
            // if other than numbers entered system will fail.

            cin.clear();                // to clear the failure state.

            cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');    // to ignore what was entered before, to clean the buffer.
            //              ^ this portion will clear all the buffer
            // some ppl write numbers which mean delete this much from the buffer, while that one will clear all the buffer.

            cout << "Invalid input! Please enter a number." << endl;
            cin >> Number;
        }

    


    return 0;
}

