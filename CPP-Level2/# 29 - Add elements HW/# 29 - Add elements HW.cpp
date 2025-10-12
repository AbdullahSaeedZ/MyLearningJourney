#include <iostream>
#include <vector>


using namespace std;


// in vectors we must use & , unlike arrays here by reference is not the default.
void AddElementInVector(vector <int>& vNumbers)
{
    int Number = 0;
    string Again = " ";
    do
    {
        cout << "Please enter a number: ";
        cin >> Number;
        vNumbers.push_back(Number);

        cout << "do you want to enter another number? ";
        cin >> Again;

    } while (Again == "Yes" || Again == "yes");
}

void PrintVectorElements(vector <int>& vNumbers)
{

    cout << "\nvector Numbers are: " << endl;

    for (int& item : vNumbers)
    {
        
        printf("%04d  \n", item);
    }
}

int main()
{
    
    vector <int> vNumbers;

    AddElementInVector(vNumbers);
    PrintVectorElements(vNumbers);


    return 0;
}

