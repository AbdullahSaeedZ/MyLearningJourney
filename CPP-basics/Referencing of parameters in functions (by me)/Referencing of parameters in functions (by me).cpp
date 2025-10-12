#include <iostream>
using namespace std;



//Referencing using & with the parameter will apply the change desired on the original value of the variable used (in this case MyName).
// so this mark will make the function use the reference (adress of the varable in memory) and apply the change on it.

void AddPrefixToName(string& Name)
{
    // since i used the (&) mark, i dont redeclare the variable Name, here i only modified the variable, if i redeclare then the referencing wont work
    Name = "Mr. " + Name;
    cout << Name << endl;

    /* this is called by reference. the default is by value which means it wont use the reference of inputted variable,
    it will keep the change inside the function and wont affect the original variable */
}


int main()
{  // below variable contains only Abdullah
    string MyName = "Abdullah";
   
   /* now if i apply the function, Abdullah will be changed based on the function and result will be modified in the original variable (MyName).
     cuz the function used the reference of the Original variable.*/

    AddPrefixToName(MyName);

   // it will print MyName with the new value because of referrencing the parameter in the function creating phase.
    cout << MyName << endl;


    // if i didnt use referencing, the value will change when i call the function and will be saved in the function only and the original variable wont be changed.
    return 0;
}

