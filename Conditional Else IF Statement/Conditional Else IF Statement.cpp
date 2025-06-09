#include <iostream>
using namespace std;


int main()
{
    int time = 22;


    //Else if is basically repeated IF statements. it can go as long as i want, 5 or 20 or even more of repeated IF-statements.
    if (time < 10)
    {
        cout << " good morning" << endl;  // if this is true then only this body will print 
    }
    else if (time < 20)
    {
        cout << "good day" << endl;   //if this is true then only this body will print
    }
    else
    {
        cout << "good evening" << endl;  // if this is true then only this body will print
    }

    return 0;
}

