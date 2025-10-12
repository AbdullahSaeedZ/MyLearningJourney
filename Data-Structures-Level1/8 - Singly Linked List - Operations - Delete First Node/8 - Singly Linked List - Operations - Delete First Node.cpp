#include <iostream>
using namespace std;

class Node
{
public:
    int value;
    Node* next;
};

void InsertAtEnd(Node*& head, int Value) 
{

    Node* new_node = new Node();

    new_node->value = Value;
    new_node->next = NULL;

    if (head == NULL)
    {
        head = new_node;
        return;
    }

    Node* LastNode = head;
    while (LastNode->next != NULL)
    {
        LastNode = LastNode->next;
    }

    LastNode->next = new_node;
    return;
}



// Delete First Node in Linked List
// =================================================================

// Suppose we have a Linked List like this:
// Head → [1] → [2] → [3] → NULL
// Goal: delete the first node [1]
// -----------------------------------------------------------------

// Step 1: Identify the node to delete
// The first node is the one that Head points to directly
// nodeToDelete = Head;  // node [1]
// -----------------------------------------------------------------

// Step 2: Update Head pointer
// Make Head point to the next node instead of the first node
// Head = Head->next;  // Now Head points to [2]
// -----------------------------------------------------------------

// Step 3: Delete the first node from memory
// delete nodeToDelete;  // delete node [1]
// or
// free(nodeToDelete);   // in C language
// -----------------------------------------------------------------

// Step 4: Final result:
// Head → [2] → [3] → NULL
// Node [1] has been successfully deleted


void DeleteFirstNode(Node*& head) 
{
    if (head == NULL)
    {
        return;
    }

    Node* nodeToDelete = head; // make this as first node (to be deleted)
    head = nodeToDelete->next; // make head point to node 2 , instead of head pointing to node 1
    delete nodeToDelete;//free from memory

}



void PrintList(Node* head)
{
    cout << "\n";
    while (head != NULL)
    {
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
    InsertAtEnd(head, 4);
    InsertAtEnd(head, 5);
    InsertAtEnd(head, 6);
    PrintList(head);


    DeleteFirstNode(head);

    PrintList(head);

    system("pause>0");

}