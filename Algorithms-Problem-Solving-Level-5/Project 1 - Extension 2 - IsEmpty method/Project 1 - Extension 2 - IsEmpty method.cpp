#include <iostream>
#include "clsDblLinkedList.h"
using namespace std;

int main()
{
    clsDblLinkedList <int> List;

   /* List.InsertAtBeginning(1);
    List.InsertAtBeginning(2);
    List.InsertAtBeginning(3);*/

    cout << "inserting at beginning:" << endl;
    List.PrintList();


    if (List.IsEmpty())
    {
        cout << "\nList is empty" << endl;
    }
    else
    {
        cout << "\nList is not empty" << endl;
    }

    return 0;
}