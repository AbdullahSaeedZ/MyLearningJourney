#include <iostream>
#include <string>
#include <vector>
#include <fstream>
using namespace std;

void LoadVectorToNewFile(string FilePath, const vector <string>& VectorContent)
{
    fstream File;
    File.open(FilePath, ios::out); // ios::out  to create a file if not created.

    if (File.is_open())
    {
        for (const string& Line : VectorContent)
        {
            if (Line != "")   //to ignore if vector element is empty (due to capacity nature)
            {
                File << Line << endl;
            }
        }

        File.close();
    }
}

int main()
{
    vector <string> Names = { "Abdullah", "Fahad", "Saud" };

    LoadVectorToNewFile("New FIle.txt", Names);



    return 0;
}

