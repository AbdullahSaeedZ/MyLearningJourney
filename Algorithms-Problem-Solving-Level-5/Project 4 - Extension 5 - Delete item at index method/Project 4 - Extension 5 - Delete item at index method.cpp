#include <iostream>
#include "clsDynamicArray.h"
using namespace std;

int main()
{

    clsDynamicArray <int> DyArr(5);

    DyArr.SetItem(0, 10);
    DyArr.SetItem(1, 20);
    DyArr.SetItem(2, 30);
    DyArr.SetItem(3, 40);
    DyArr.SetItem(4, 50);

    cout << "Is empty: " << DyArr.IsEmpty() << endl;
    cout << "Size: " << DyArr.Size() << endl;

    cout << "\narray items: " << endl;
    DyArr.PrintItems();

    /* cout << "\n\nresize from 5 items to 2: " << endl;
     DyArr.ReSize(2);
     DyArr.PrintItems();

     cout << "\n\nresize from 2 items to 10: " << endl;
     DyArr.ReSize(10);
     DyArr.PrintItems();*/

    cout << "\n\nValue of index 1: " << DyArr.GetItemValueByIndex(1) << endl;

    cout << "\nSize: " << DyArr.Size() << endl;
    cout << "items after reversing:" << endl;
    DyArr.Reverse();
    DyArr.PrintItems();

   /* cout << "\n\nitems after clearing:" << endl;
    DyArr.Clear();
    DyArr.PrintItems();*/

    DyArr.DeleteItemByIndex(2);
    cout << "\n\nSize: " << DyArr.Size() << endl;
    cout << "items after deleteing index 2:" << endl;
    DyArr.PrintItems();

    return 0;
}