#include <iostream>
using namespace std;

class Node
{
public:
    int value;
    Node* next;
};

void InsertAtBeginning(Node*& head, int value)
{
    // Allocate memory to a node
    Node* new_node = new Node();

    // insert the data
    new_node->value = value;
    new_node->next = head;

    // Move head to new node
    head = new_node;

}

// Suppose we have a Linked List like this:
// Head → [1] → [2] → [3] → NULL

// Goal: insert a new node [500] at the END of the list

// -------------------------------------------------

// 1) Create the new node
// newNode = [500 | Next = NULL]
// It's separate at first, not connected to the list.

// -------------------------------------------------

// 2) Find the last node in the list
// In this case, the last node is [3], 
// because [3]->next = NULL

// -------------------------------------------------

// 3) Link the last node (3) to the new node
// node3->next = newNode
// Meaning: [3] → [500]

// -------------------------------------------------

// 4) Final result:
// Head → [1] → [2] → [3] → [500] → NULL



void InsertAtEnd(Node*& head, int Value) {

    Node* new_node = new Node();

    new_node->value = Value;
    new_node->next = NULL;

    if (head == NULL) {
        head = new_node;
        return;  // if list is empty, then head will point to the new node then return and end function.
    }

    Node* LastNode = head;  // head as a start point, till we reach last node by the while loop.
    while (LastNode->next != NULL)// this is for finding last node (which is pointing to null).
    {
        LastNode = LastNode->next;
    }

    LastNode->next = new_node;  // now we found the last node, we make it point to the new node which points to null.
    return;
}

void PrintList(Node* head)

{
    cout << "\n";
    while (head != NULL) {
        cout << head->value << " ";
        head = head->next;
    }
}

int main()
{
    Node* head = NULL;

    InsertAtEnd(head, 1);
    InsertAtEnd(head, 2);
    InsertAtEnd(head, 3);
    InsertAtBeginning(head, 0);

    PrintList(head);

    system("pause>0");

}