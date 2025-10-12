#include <iostream>
#include <vector>
using namespace std;


int main()
{
    // vector is a dynamic array which means we dont need to initialize a size for it , it will start with zero size and increase once values are added.

    // declaration:
    // std::vector <data type> vector_name;

    vector <int> vNumbers = { 1, 2, 3, 4, 5 };



    cout << "Vectors values: ";

    // easier to use ranged loop:
    // note here the by-reference, if not used, the ranged loop in every time will take the value from the collection then make a copy to the item variable.
    // in structures and other stuff, the program will become slower due to the copying process of such amount of information.
    // when using the by-reference, the item variable is directly connected to the memory address of the vector value and will become it. in this way there is no copying process which will make the program fast.

    for (int &item : vNumbers)
    {
        cout << item << " ";
    }

    cout << endl;


    return 0;
}

