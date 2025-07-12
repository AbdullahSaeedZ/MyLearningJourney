#include <iostream>
#include <fstream>
#include <string>
using namespace std;


int main()
{
    

    fstream MyFile;
    MyFile.open("The File.txt", ios::in); //ios::in  is the reading mode.

    string Print; // declare a variable to use for printing

    if (MyFile.is_open())
    {
        while (getline(MyFile, Print))  //get line will open the file then take first line and store inside Print variable, once all lines printed, getline will give false result then loop will end.
        {
            cout << Print << endl;
        }

    }




    return 0;
}

