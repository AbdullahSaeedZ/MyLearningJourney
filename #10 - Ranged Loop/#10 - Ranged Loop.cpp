#include <iostream>
using namespace std;



int main()
{
    int Array1[] = { 1, 2, 3, 4, 5 };


    // this is called Ranged Loop, first we declare the item type that we want to look for inside the COLLECTION which is Array1
    //then the loop will start and will take the item and take it from the collection and execute the code until the end of the collection then will stop.

    for (int Item : Array1)
    {
        cout << Item << endl;
    }

    cout << endl;

    // we can do it like this, it doesnt have to be an array.
    // this is a set of items.

    for (int Item : { 1, 2, 3, 4, 5 })
    {
        cout << Item << endl;
    }

    return 0;
}

