#include <iostream>
#include "clsDblLinkedList.h"
using namespace std;

int main()
{
    clsDblLinkedList <int> List;

    List.InsertAtBeginning(1);
    List.InsertAtBeginning(2);
    List.InsertAtBeginning(3);
    List.InsertAtBeginning(4);
    List.InsertAtBeginning(5);

    cout << "inserting at beginning:" << endl;
    List.PrintList();

    clsDblLinkedList <int>::Node *N1 = List.GetNodeByIndex(1);

    cout << "\nvalue of index 1:" << endl;
    cout << N1->_Value << endl;


    return 0;
}