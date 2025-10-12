#include <iostream>
#include <vector>
#include <string>
#include <fstream>
using namespace std;

void CreateFile(string FileName)
{
    // trying to read a file with this name, if file not created it will fail and no imapct happens.

    ifstream CheckFile(FileName);  // ifstream opens in ios::in by default

    if (CheckFile.is_open())
        return;
    else
        ofstream NewFile(FileName); // ofstream opens in ios::out by default
}

void PrintFile(const string FilePath)
{
    fstream File;
    File.open(FilePath, ios::in);

    string Line;

    if (File.is_open())
    {
        while (getline(File, Line))
        {
            cout << Line << endl;
        }

        File.close();
    }
}

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

void DeletFileRecord(string FilePath, string Record)
{
    vector <string> Temp;
    LoadFileToVector(FilePath, Temp);

    for (string &item : Temp)
    {
        if (item == Record)
        {
            item = "";
        }
    }

    LoadVectorToNewFile(FilePath, Temp);

}


void DeleteFileLine(string FilePath, unsigned short LineNumber)
{
    vector <string> Temp;
    LoadFileToVector(FilePath, Temp);

    Temp.at(LineNumber - 1) = "";

    LoadVectorToNewFile(FilePath, Temp);
}

void DeleteStringInFile(string FilePath, string str)  
{  
    vector<string> Temp;  
    LoadFileToVector(FilePath, Temp);  

    size_t Index;  

    for (string& item : Temp)  
    {  
        Index = item.find(str);  

        while (Index != string::npos)  
        {  
            item.erase(Index, str.length()); // Corrected: Removed "+ 1" to match the erase function's expected arguments  
            Index = item.find(str); // Update Index to find the next occurrence of the string  
        }  
    }  

    LoadVectorToNewFile(FilePath, Temp);  
}


int main()
{
    
    CreateFile("Names.txt");

    DeleteStringInFile("Names.txt", "Saeed");

    PrintFile("Names.txt");

   

    

    


    return 0;
}

