#include <iostream>
#include "clsDblLinkedList.h"
using namespace std;

int main()
{
    clsDblLinkedList <int> List;

    List.InsertAtBeginning(1);
    List.InsertAtBeginning(2);
    List.InsertAtBeginning(3);

    cout << "inserting at beginning:" << endl;
    List.PrintList();

    cout << "\nsize of the list: " << List.Size() << endl;


    List.Clear();
    cout << "\nsize of the list after clearing: " << List.Size() << endl;

    return 0;
}