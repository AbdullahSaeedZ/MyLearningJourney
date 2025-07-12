#include <iostream>
#include <fstream>
using namespace std;


int main()
{

    fstream MyFile;

    // ios::out is for output operations (overwriting to the file and create it if not created).
    // ios::app is for appending to the end of the file.
    // Using ios::out | ios::app together means:
    // - If the file does not exist, it will be created.
    // - If the file exists, it will be opened in append mode, keeping the existing content and adding new content at the end.


    MyFile.open("The File.txt", ios::out | ios::app);  // iod::out is already built inside the ios::app , so we can just use ios::app and it will work.


    if (MyFile.is_open()) 
    {
        MyFile << "This is the first line\n";
        MyFile << "this is the second line\n";

       
        MyFile.close();

    }


    // Using bitwise OR (|) to combine ios::out and ios::app flags:
// ios::out enables writing  (e.g., 0001)
// ios::app enables appending (e.g., 0010)
// Bitwise OR merges them: 0001 | 0010 = 0011
// This single combined value tells the file to open for writing in append mode
// without erasing existing content.
    



    return 0;
}
