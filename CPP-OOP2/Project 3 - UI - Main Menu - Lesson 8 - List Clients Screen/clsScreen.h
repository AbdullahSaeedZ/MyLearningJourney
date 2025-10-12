#pragma once
#include <iostream>
using namespace std;


class clsScreen
{

protected:
    static void _DrawScreenHeader(string Title, string SubTitle = "")
    {
        cout << "___________________________________________" << endl;
        cout << Title << endl;
        if (SubTitle != "")
        {
            cout << SubTitle << endl;
        }
        cout <<"___________________________________________\n\n";
    }


};

