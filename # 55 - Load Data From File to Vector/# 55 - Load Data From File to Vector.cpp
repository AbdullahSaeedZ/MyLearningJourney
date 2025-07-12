#include <iostream>
#include <vector>
#include <string>
#include <fstream>
using namespace std;


void LoadFileToVector(string FilePath, vector <string>& vFileContent)
{
    fstream File;
    File.open(FilePath, ios::in);

    if (File.is_open())
    {
        string Line;

        while (getline(File, Line))
        {
            vFileContent.push_back(Line);
        }

        File.close();
    }

}


int main()
{
    
    vector <string> FileContent;

    LoadFileToVector("The File.txt", FileContent);  // file must be in the project folder

    for (string& item : FileContent)
    {
        cout << item << endl;
    }


    return 0;
}

