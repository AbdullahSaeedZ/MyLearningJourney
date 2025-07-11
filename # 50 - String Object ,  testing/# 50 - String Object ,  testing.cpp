#include <iostream>
#include <string>
using namespace std;

int main()
{
    
  /*  string Name = "My name is abdullah";
    
    for (int i = 0; i <= Name.length(); i++)
    {
        cout << Name.substr(0, i) << endl;
    }*/



    string Email = "Aboood@gmail.com";
    

    for (int i = 2; i < Email.find("@"); i++)
    {
        Email.at(i) = '*';
    }

    cout << Email << endl;

    return 0;
}
