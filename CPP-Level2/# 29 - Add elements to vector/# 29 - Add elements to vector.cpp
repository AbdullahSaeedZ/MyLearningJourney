#include <iostream>
#include <vector>
using namespace std;

int main()
{
    vector <int> vNumbers;

    // this how to add a value inside the vector using this function (or method?).
    vNumbers.push_back(10);
    vNumbers.push_back(20);
    vNumbers.push_back(30);
    vNumbers.push_back(40);
    vNumbers.push_back(50);
    vNumbers.push_back(60);

    cout << "\nVector numbers are: ";

    for (int& item : vNumbers)
    {
        cout << item << " ";
    }


    cout << endl;




    return 0;
}

