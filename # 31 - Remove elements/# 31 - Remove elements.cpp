#include <iostream>
#include <vector>

using namespace std;


int main()
{
    
    vector <int> vNumbers;

    vNumbers.push_back(10);
    vNumbers.push_back(20);
    vNumbers.push_back(30);
    vNumbers.push_back(40);

    // to check size of the vector:

    cout << "size of vector: " << vNumbers.size() << endl;

    // this is how to remove elements from the vector, since vectors use stack data structure, the last in is fisrt out !!
    vNumbers.pop_back();
    vNumbers.pop_back();
    vNumbers.pop_back();
    
    // or to fully empty the vector: 

    vNumbers.clear();


    // if the stack is empty and i do pop, the program will fail.
    // so when popping, it is better to check first using if-statement:

    if (!vNumbers.empty()) // this function checks if it is empty or not, returns boolen.
    {
        vNumbers.pop_back();
    }

    // or :

    if (vNumbers.size() > 0)
    {
        vNumbers.pop_back();
    }

   
    cout << "\nNumbers in vector: \n" << endl;

    for (int& item : vNumbers)
    {
        cout << item << endl;
    }

    cout << "size of vector after popping: " << vNumbers.size() << endl;

    return 0;
}

