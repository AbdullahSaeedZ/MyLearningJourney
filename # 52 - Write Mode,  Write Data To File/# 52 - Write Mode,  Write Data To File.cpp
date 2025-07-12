#include <iostream>
#include <fstream>
using namespace std;


int main()
{
    
    fstream MyFile;

    // this method creates a new file or open existed file with that name.
    MyFile.open("The File.txt", ios::out);  // .open(name of the file, mode desired) out mode is for writing inside the file.


    if (MyFile.is_open()) // to make sure that the open method has worked
    {
        MyFile << "This is the first line\n";
        MyFile << "this is the second line\n";

        // after finishing, we must close it, otherwise it will be busy when we try to open it again.
        MyFile.close();

    }


  
    // run the code to execute then see file in solution explorer > right click on project name > open folder in file explorer.



    return 0;
}

