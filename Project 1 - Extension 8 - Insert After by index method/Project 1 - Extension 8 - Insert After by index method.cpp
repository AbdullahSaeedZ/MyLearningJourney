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

    List.InsertAfter(1, 500);
    cout << "\nList after inserting node after index 1:" << endl;
    List.PrintList();


    return 0;
}