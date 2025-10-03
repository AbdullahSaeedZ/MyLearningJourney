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

    cout << "\nvalue of item 3:" << endl;
    cout << List.GetNodeValueByIndex(5) << endl;


    return 0;
}