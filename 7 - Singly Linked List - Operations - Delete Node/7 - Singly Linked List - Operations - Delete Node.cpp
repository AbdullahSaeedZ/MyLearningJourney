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

    if (head == NULL) {
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

void PrintList(Node* head)
{
    cout << "\n";
    while (head != NULL) {
        cout << head->value << " ";
        head = head->next;
    }
}

// Suppose we have a Linked List like this:
// Head → [1] → [2] → [3] → NULL

// Goal: delete node [2]

// -------------------------------------------------

// 1) Find the node BEFORE the one to delete
// In this case, node [1] comes before node [2]

// -------------------------------------------------

// 2) Change the link of [1]
// Instead of [1] pointing to [2],
// make it point directly to [3]
// prev(node1)->next = current(node2)->next

// -------------------------------------------------

// 3) Free memory of node [2] (optional in C++, required in manual memory management)
// delete current(node2);

// -------------------------------------------------

// 4) Final result:
// Head → [1] → [3] → NULL


void DeleteNode(Node*& head, int Value) 
{
    if (head == NULL)
    {
        return;
    }

    Node* Current = head, * Prev = head;

    if (Current->value == Value)  // if node to be deleted is the first one.
    {
        head = Current->next;
        delete Current;//free from memory
        return;
    }

    // Find the node to be deleted
    while (Current != NULL && Current->value != Value)  // moving prev and current through the list till we find the required node
    {
        Prev = Current;
        Current = Current->next;
    }

    // If the value is not present
    if (Current == NULL) return;

    // Remove the node
    Prev->next = Current->next;
    delete Current;//free from memory

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



    DeleteNode(head, 4);
    PrintList(head);

    system("pause>0");

}